using Microsoft.EntityFrameworkCore;
using MusicLab.Repository.Models;
using MusicLab.Repository.Repositories.Interfaces;

namespace MusicLab.Repository.Repositories
{
    public class SongRepository : BaseRepository<Song>, ISongRepository
    {
        private readonly MusicLabContext _context;
        public SongRepository(MusicLabContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Song>> GetAllRecommendedSongs(string username, int? top)
        {
            var favouriteSongs = await _context.Favourites
                                                .Where(x => x.Username == username)
                                                .Select(x => x.SongId).Distinct().ToListAsync().ConfigureAwait(false);
            var genres = await _context.SongCategories.Join(_context.Categories, t1 => t1.CategoryId, t2 => t2.Id,
                                                (t1, t2) => new { Song = t1, Category = t2 })
                                                .Where(x => x.Category.IsGenre)
                                                .Where(x => favouriteSongs.Contains(x.Song.SongId))
                                                .Select(x => x.Category.Id)
                                                .Distinct()
                                                .ToListAsync().ConfigureAwait(false);
            var songIds = await _context.SongCategories.Where(x => genres.Contains(x.CategoryId))
                .Select(x => x.SongId).Distinct().ToListAsync();
            List<Song> songs = new List<Song>();
            if (top == null) songs = await _context.Songs.Where(x => songIds.Contains(x.Id))
                    .Include(x => x.SongArtists).ThenInclude(x => x.Artist).ToListAsync().ConfigureAwait(false);
            else songs = await _context.Songs.Where(x => songIds.Contains(x.Id)).OrderByDescending(x => x.NumberOfListen).Take(top.Value)
                    .Include(x => x.SongArtists).ThenInclude(x => x.Artist).ToListAsync().ConfigureAwait(false);
            return songs;
        }
    }
}
