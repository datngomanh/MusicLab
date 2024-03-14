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
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IPlaylistSongRepository _playlistSongRepository;
        private readonly IMapper _mapper;

        public PlaylistController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _playlistRepository = unitOfWork.PlaylistRepository;
            _playlistSongRepository = unitOfWork.PlaylistSongRepository;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("/api/add-song-to-playlist")]
        public async Task<IActionResult> AddSongToPlaylist(AddSongToPlaylistRequestModel entity)
        {
            var playlistSong = new PlaylistSong
            {
                PlaylistId = entity.PlaylistId,
                SongId = entity.SongId,
                DateAdded = DateTime.Now,
            };
            try
            {
                _playlistSongRepository.Add(playlistSong).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpDelete("/api/delete-song-from-playlist")]
        public async Task<IActionResult> DeleteSongFromPlaylist(AddSongToPlaylistRequestModel entity)
        {
            var playlistSong = await _playlistSongRepository.Find(x => x.PlaylistId == entity.PlaylistId && x.SongId == entity.SongId)
                .FirstOrDefaultAsync().ConfigureAwait(false);
            if (playlistSong == null) return BadRequest();
            try
            {
                _playlistSongRepository.Delete(playlistSong).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpDelete("/api/delete-playlist")]
        public async Task<IActionResult> DeletePlaylist(int playlistId)
        {
            var playlist = await _playlistRepository.GetById(playlistId).ConfigureAwait(false);
            if (playlist == null) return NotFound();
            try
            {
                await _playlistRepository.Delete(playlist).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [Authorize]
        [HttpPost("/api/add-playlist")]
        public async Task<IActionResult> AddPlaylist(AddPlaylistRequestModel entity)
        {
            var playlist = new Playlist
            {
                Title = entity.Title,
                Username = entity.Username,
                CreatedDate = DateTime.Now,
            };
            try
            {
                await _playlistRepository.Add(playlist).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet("/api/get-playlists-by-keyword")]
        public async Task<IActionResult> GetPlaylistsByKeyword(string username, string keyword)
        {
            var rs = await _playlistRepository.Find(x => x.Username == username && x.Title.ToLower().Contains(keyword.ToLower()))
                .ToListAsync()
                .ConfigureAwait(false);
            return Ok(rs);
        }

        [Authorize]
        [HttpGet("/api/get-playlist-by-id")]
        public async Task<IActionResult> GetPlaylistById(int id)
        {
            var rs = await _playlistRepository.Find(x => x.Id == id)
                .Include(x => x.PlaylistSongs)
                .ThenInclude(x => x.Song)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
            var rsMap = _mapper.Map<PlaylistResponseModel>(rs);
            return Ok(rsMap);
        }
    }
}
