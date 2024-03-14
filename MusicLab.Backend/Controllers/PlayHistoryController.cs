using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicLab.Repository;
using MusicLab.Repository.Models;
using MusicLab.Repository.Repositories.Interfaces;

namespace MusicLab.Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PlayHistoryController : ControllerBase
    {
        private readonly IPlayHistoryRepository _playHistoryRepository;
        private readonly IMapper _mapper;
        public PlayHistoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _playHistoryRepository = unitOfWork.PlayHistoryRepository;
            _mapper = mapper;
        }

        [HttpPost("/api/add-play-history")]
        public async Task<IActionResult> AddPlayHistory(PlayHistory playHistory)
        {
            var playhistoryOld = await _playHistoryRepository.Find(x => x.Username == playHistory.Username && x.SongId == playHistory.SongId)
                .FirstOrDefaultAsync().ConfigureAwait(false);
            try
            {
                if (playhistoryOld != null)
                {
                    playhistoryOld.PlayedDate = DateTime.Now;
                    playhistoryOld.Duration = playHistory.Duration;
                    await _playHistoryRepository.Update(playHistory).ConfigureAwait(false);
                }
                else await _playHistoryRepository.Add(playHistory).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
