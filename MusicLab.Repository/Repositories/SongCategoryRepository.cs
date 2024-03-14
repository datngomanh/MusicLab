using MusicLab.Repository.Models;
using MusicLab.Repository.Repositories.Interfaces;

namespace MusicLab.Repository.Repositories
{
    public class SongCategoryRepository : BaseRepository<SongCategory>, ISongCategoryRepository
    {
        private readonly MusicLabContext _context;
        public SongCategoryRepository(MusicLabContext context) : base(context)
        {
            _context = context;
        }
    }
}
