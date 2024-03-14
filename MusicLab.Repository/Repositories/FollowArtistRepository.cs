using Microsoft.EntityFrameworkCore;
using MusicLab.Repository.Models;
using MusicLab.Repository.Repositories.Interfaces;

namespace MusicLab.Repository.Repositories
{
    public class FollowArtistRepository : BaseRepository<FollowArtist>, IFollowArtistRepository
    {
        private readonly MusicLabContext _context;
        public FollowArtistRepository(MusicLabContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Artist>> GetFollowArtist(string username)
        {
            var followArtists = await _context.FollowArtists.Join(_context.Artists, t1 => t1.ArtistId, t2 => t2.Id,
                                                (t1, t2) => new { FollowArtists = t1, Artists = t2 })
                                                .Where(x => x.FollowArtists.Username == username)
                                                .Select(x => x.Artists).ToListAsync().ConfigureAwait(false);
            return followArtists;
        }
    }
}
