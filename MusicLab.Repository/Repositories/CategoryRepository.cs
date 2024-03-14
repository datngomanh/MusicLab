using MusicLab.Repository.Models;
using MusicLab.Repository.Repositories.Interfaces;

namespace MusicLab.Repository.Repositories
{
    internal class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly MusicLabContext _context;
        public CategoryRepository(MusicLabContext context) : base(context)
        {
            _context = context;
        }
    }
}
