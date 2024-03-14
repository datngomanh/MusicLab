using MusicLab.Repository.Models;
using MusicLab.Repository.Repositories.Interfaces;

namespace MusicLab.Repository.Repositories
{
    public class ArtistRepository : BaseRepository<Artist>, IArtistRepository
    {
        private readonly MusicLabContext _context;
        public ArtistRepository(MusicLabContext context) : base(context)
        {
            _context = context;
        }
    }
}
