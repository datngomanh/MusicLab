using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicLab.Backend.Services.Interfaces;
using MusicLab.Repository;
using MusicLab.Repository.Models;
using MusicLab.Repository.Models.RequestModel;
using MusicLab.Repository.Models.ResponseModel;
using MusicLab.Repository.Repositories.Interfaces;

namespace MusicLab.Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongRepository _songRepository;
        private readonly IFavouriteRepository _favouriteRepository;
        private readonly ISongArtistRepository _songArtistRepository;
        private readonly IPlaylistSongRepository _playlistSongRepository;
        private readonly ISongCategoryRepository _songCategoryRepository;
        private readonly IMapper _mapper;
        private readonly IAWSS3Service _s3Service;

        public SongController(IUnitOfWork unitOfWork, IMapper mapper, IAWSS3Service s3Service)
        {
            _songRepository = unitOfWork.SongRepository;
            _favouriteRepository = unitOfWork.FavouriteRepository;
            _songArtistRepository = unitOfWork.SongArtistRepository;
            _playlistSongRepository = unitOfWork.PlaylistSongRepository;
            _songCategoryRepository = unitOfWork.SongCategoryRepository;
            _mapper = mapper;
            _s3Service = s3Service;
        }

        [HttpGet("/api/get-song-by-id")]
        public async Task<IActionResult> GetSongById(int songId)
        {
            var rs = await _songRepository.Find(x => x.Id == songId)
                .Include(x => x.SongArtists)
                .ThenInclude(x => x.Artist)
                .FirstOrDefaultAsync().ConfigureAwait(false);
            return Ok(_mapper.Map<SongResponseModel>(rs));
        }

        [HttpGet("/api/get-songs-by-keyword")]
        public async Task<IActionResult> GetSongsByKeyWord(string keyword)
        {
            var rs = await _songRepository.Find(x => x.Title.ToLower().Contains(keyword.ToLower()))
                .Include(x => x.SongArtists)
                .ThenInclude(x => x.Artist)
                .ToListAsync().ConfigureAwait(false);
            return Ok(_mapper.Map<List<SongResponseModel>>(rs));
        }

        [HttpPost("/api/upload-song")]
        public async Task<IActionResult> UploadSong([FromForm] IFormFile song)
        {
            var success = await _s3Service.UploadFileAsync(song).ConfigureAwait(false);
            if (success) return Ok();
            else return BadRequest();
        }

        [HttpPost("/api/add-song")]
        public async Task<IActionResult> UploadSong(Song song)
        {
            try
            {
                await _songRepository.Add(song).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPost("/api/add-favourite")]
        public async Task<IActionResult> AddFavourite(AddFavouriteSongRequestModel entity)
        {
            var favourite = new Favourite
            {
                Username = entity.Username,
                SongId = entity.SongId,
                LikedDate = DateTime.Now,
            };
            try
            {
                await _favouriteRepository.Add(favourite).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("/api/update-number-of-listens")]
        public async Task<IActionResult> UpdateNumberOfListens(int songId)
        {
            var song = await _songRepository.GetById(songId).ConfigureAwait(false);
            try
            {
                song.NumberOfListen += 1;
                await _songRepository.Update(song).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("/api/get-song-url")]
        public async Task<IActionResult> GetSongURL(int songId)
        {
            var song = await _songRepository.GetById(songId).ConfigureAwait(false);
            if (song == null) return BadRequest();
            var url = await _s3Service.GetURLAsync(song.Link).ConfigureAwait(false);
            if (string.IsNullOrEmpty(url)) return BadRequest();
            return Ok(url);
        }

        [HttpGet("/api/get-songs-by-album")]
        public async Task<IActionResult> GetSongsByAlbum(int albumId)
        {
            var songs = await _songRepository.Find(x => x.AlbumId == albumId)
                .Include(x => x.SongArtists)
                .ThenInclude(x => x.Artist)
                .ToListAsync().ConfigureAwait(false);
            if (songs == null) return BadRequest();
            return Ok(_mapper.Map<List<SongResponseModel>>(songs));  
        }

        [HttpGet("/api/get-songs-by-artist")]
        public async Task<IActionResult> GetSongsByArtist(int artistId)
        {
            var songIds = await _songArtistRepository.Find(x => x.ArtistId == artistId).Select(x => x.SongId).Distinct().ToListAsync().ConfigureAwait(false);
            var songs = await _songRepository.Find(x => songIds.Contains(x.Id))
                .Include(x => x.SongArtists)
                .ThenInclude(x => x.Artist)
                .ToListAsync().ConfigureAwait(false);
            if (songs == null) return BadRequest();
            return Ok(_mapper.Map<List<SongResponseModel>>(songs));
        }

        [HttpGet("/api/get-songs-by-category")]
        public async Task<IActionResult> GetSongsByCategory(int categoryId)
        {
            var songIds = await _songCategoryRepository.Find(x => x.CategoryId == categoryId).Select(x => x.SongId).Distinct().ToListAsync().ConfigureAwait(false);
            var songs = await _songRepository.Find(x => songIds.Contains(x.Id))
                .Include(x => x.SongArtists)
                .ThenInclude(x => x.Artist)
                .ToListAsync().ConfigureAwait(false);
            if (songs == null) return BadRequest();
            return Ok(_mapper.Map<List<SongResponseModel>>(songs));
        }

        [Authorize]
        [HttpGet("/api/get-songs-by-playlist")]
        public async Task<IActionResult> GetSongsByPlaylist(int playlistId)
        {
            var songIds = await _playlistSongRepository.Find(x => x.PlaylistId == playlistId).Select(x => x.SongId).Distinct().ToListAsync().ConfigureAwait(false);
            var songs = await _songRepository.Find(x => songIds.Contains(x.Id))
                .Include(x => x.SongArtists)
                .ThenInclude(x => x.Artist)
                .ToListAsync().ConfigureAwait(false);
            if (songs == null) return BadRequest();
            return Ok(_mapper.Map<List<SongResponseModel>>(songs));
        }
    }
}
