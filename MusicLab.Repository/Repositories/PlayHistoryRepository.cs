using Microsoft.EntityFrameworkCore;
using MusicLab.Repository.Models;
using MusicLab.Repository.Repositories.Interfaces;

namespace MusicLab.Repository.Repositories
{
    public class PlayHistoryRepository : BaseRepository<PlayHistory>, IPlayHistoryRepository
    {
        private readonly MusicLabContext _context;
        public PlayHistoryRepository(MusicLabContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Song>> GetTop6LastPlayedSongs(string username)
        {
            var songIds = await _context.PlayHistories.Where(s => s.Username == username)
                .OrderByDescending(s => s.PlayedDate)
                .Take(6)
                .Select(x => x.SongId).ToListAsync();
            var songs = await _context.Songs.Where(x => songIds.Contains(x.Id))
                .Include(x => x.SongArtists)
                .ThenInclude(x => x.Artist)
                .ToListAsync().ConfigureAwait(false);
            //var rs = await _context.PlayHistories.Join(_context.Songs, t1 => t1.SongId, t2 => t2.Id,
            //                                    (t1,t2) => new {History = t1, Song = t2})
            //                                    .Where(x => x.History.Username == username)
            //                                    .OrderByDescending(x => x.History.PlayedDate)
            //                                    .Take(6)
            //                                    .Include(x => x.Song.SongArtists)
            //                                    .ThenInclude(x => x.Artist)
            //                                    .Select(x => x.Song)
            //                                    .ToListAsync().ConfigureAwait(false);
            return songs;
        }
    }
}
