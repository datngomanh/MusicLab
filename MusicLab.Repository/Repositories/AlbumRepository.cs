using MusicLab.Repository.Models;
using MusicLab.Repository.Repositories.Interfaces;

namespace MusicLab.Repository.Repositories
{
    public class AlbumRepository : BaseRepository<Album>, IAlbumRepository
    {
        private readonly MusicLabContext _context;
        public AlbumRepository(MusicLabContext context) : base(context)
        {
            _context = context;
        }
    }
}
