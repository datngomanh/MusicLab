using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicLab.Repository;
using MusicLab.Repository.Models.RequestModel;
using MusicLab.Repository.Models.ResponseModel;
using MusicLab.Repository.Repositories.Interfaces;

namespace MusicLab.Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FavouriteController : ControllerBase
    {
        private readonly ISongRepository _songRepository;
        private readonly IFavouriteRepository _favouriteRepository;
        private readonly IMapper _mapper;

        public FavouriteController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _songRepository = unitOfWork.SongRepository;
            _favouriteRepository = unitOfWork.FavouriteRepository;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("/api/get-all-favourites")]
        public async Task<IActionResult> GetAllFavourites(string username)
        {
            var songIds = await _favouriteRepository.Find(x => x.Username == username)
                .Select(x => x.SongId).Distinct().ToListAsync().ConfigureAwait(false);
            var favourites = await _songRepository.Find(x => songIds.Contains(x.Id))
                .Include(x => x.SongArtists)
                .ThenInclude(x => x.Artist)
                .ToListAsync().ConfigureAwait(false);
            return Ok(_mapper.Map<List<SongResponseModel>>(favourites));
        }

        [Authorize]
        [HttpDelete("/api/delete-favourite")]
        public async Task<IActionResult> DeleteFavourite(AddFavouriteSongRequestModel entity)
        {
            var favourite = await _favouriteRepository.Find(x => x.Username == entity.Username && x.SongId == entity.SongId).FirstOrDefaultAsync().ConfigureAwait(false);
            if (favourite == null) return BadRequest();
            try
            {
                await _favouriteRepository.Delete(favourite).ConfigureAwait(false);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
