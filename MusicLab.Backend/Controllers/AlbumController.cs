using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicLab.Repository;
using MusicLab.Repository.Models.ResponseModel;
using MusicLab.Repository.Repositories.Interfaces;

namespace MusicLab.Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IMapper _mapper;

        public AlbumController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _albumRepository = unitOfWork.AlbumRepository;
            _mapper = mapper;
        }

        [HttpGet("/api/get-albums-by-keyword")]
        public async Task<IActionResult> GetAlbumsByKeyword(string keyword)
        {
            var rs = await _albumRepository.Find(x => x.Title.ToLower().Contains(keyword.ToLower()))
                .Include(x => x.Artist)
                .ToListAsync().ConfigureAwait(false);
            var rsMap = _mapper.Map<List<AlbumResponseModel>>(rs);
            return Ok(rsMap);
        }

        [HttpGet("/api/get-album-by-id")]
        public async Task<IActionResult> GetAlbumsById(int albumId)
        {
            var rs = await _albumRepository.Find(x => x.Id == albumId)
                .Include(x => x.Artist)
                .FirstOrDefaultAsync().ConfigureAwait(false);
            if (rs == null) return BadRequest();
            var rsMap = _mapper.Map<AlbumResponseModel>(rs);
            return Ok(rsMap);
        }

        [HttpGet("/api/get-album-by-artistid")]
        public async Task<IActionResult> GetAlbumsByArtistId(int artistId)
        {
            var rs = await _albumRepository.Find(x => x.ArtistId == artistId)
                .Include(x => x.Artist)
                .ToListAsync().ConfigureAwait(false);
            if (rs == null) return BadRequest();
            var rsMap = _mapper.Map<List<AlbumResponseModel>>(rs);
            return Ok(rsMap);
        }
    }
}
