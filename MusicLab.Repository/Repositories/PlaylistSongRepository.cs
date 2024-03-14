using MusicLab.Repository.Models;
using MusicLab.Repository.Repositories.Interfaces;

namespace MusicLab.Repository.Repositories
{
    public class PlaylistSongRepository : BaseRepository<PlaylistSong>, IPlaylistSongRepository
    {
        private readonly MusicLabContext _context;
        public PlaylistSongRepository(MusicLabContext context) : base(context)
        {
            _context = context;
        }
    }
}
