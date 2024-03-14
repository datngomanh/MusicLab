using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicLab.Repository;
using MusicLab.Repository.Models;
using MusicLab.Repository.Models.RequestModel;
using MusicLab.Repository.Models.ResponseModel;
using MusicLab.Repository.Repositories.Interfaces;

namespace MusicLab.Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IFollowArtistRepository _followArtistRepository;
        private readonly ISongArtistRepository _songArtistRepository;
        private readonly ISongRepository _songRepository;
        private readonly IMapper _mapper;

        public ArtistController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _artistRepository = unitOfWork.ArtistRepository;
            _followArtistRepository = unitOfWork.FollowArtistRepository;
            _songArtistRepository = unitOfWork.SongArtistRepository;
            _songRepository = unitOfWork.SongRepository;
            _mapper = mapper;
        }

        [HttpGet("/api/get-artist-by-id")]
        public async Task<IActionResult> GetArtistById(int artistId)
        {
            var rs = await _artistRepository.Find(x => x.Id == artistId).FirstOrDefaultAsync().ConfigureAwait(false);
            var rsMap = _mapper.Map<ArtistResponseModel>(rs);
            return Ok(rsMap);
        }

        [Authorize]
        [HttpGet("/api/get-follow-artists")]
        public async Task<IActionResult> GetFollowArtists(string username)
        {
            var rs = await _followArtistRepository.GetFollowArtist(username).ConfigureAwait(false);
            var rsMap = _mapper.Map<List<ArtistResponseModel>>(rs);
            return Ok(rsMap);
        }

        [HttpGet("/api/get-artists-by-keyword")]
        public async Task<IActionResult> GetArtistsByKeyWord(string keyword)
        {
            var rs = await _artistRepository.Find(x => x.Name.ToLower().Contains(keyword.ToLower()))
                .ToListAsync().ConfigureAwait(false);
            var rsMap = _mapper.Map<List<ArtistResponseModel>>(rs);
            return Ok(rsMap);
        }

        [Authorize]
        [HttpPost("/api/follow-artist")]
        public async Task<IActionResult> FollowArtist(FollowArtistRequestModel entity)
        {
            var follow = new FollowArtist
            {
                Username = entity.Username,
                ArtistId = entity.ArtistId,
                FollowDate = DateTime.Now,
            };
            try
            {
                await _followArtistRepository.Add(follow).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpDelete("/api/unfollow-artist")]
        public async Task<IActionResult> UnfollowArtist(FollowArtistRequestModel entity)
        {
            var followed = await _followArtistRepository.Find(x => x.Username == entity.Username && x.ArtistId == entity.ArtistId).FirstOrDefaultAsync().ConfigureAwait(false);
            if (followed == null) return BadRequest();
            try
            {
                await _followArtistRepository.Delete(followed).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("/api/get-follows-by-artist")]
        public async Task<IActionResult> GetFollowsByArtist(int artistId)
        {
            var follows = await _followArtistRepository.Find(x => x.ArtistId == artistId).CountAsync().ConfigureAwait(false);
            return Ok(follows);
        }

        [HttpGet("/api/get-listens-by-artist")]
        public async Task<IActionResult> GetListensByArtist(int artistId)
        {
            var songIds = await _songArtistRepository.Find(x => x.ArtistId == artistId).Select(x => x.SongId).Distinct().ToListAsync().ConfigureAwait(false);
            var listens = await _songRepository.Find(x => songIds.Contains(x.Id))
                .SumAsync(x => x.NumberOfListen)
                .ConfigureAwait(false);
            return Ok(listens);
        }
    }
}
