using MusicLab.Repository.Models;
using MusicLab.Repository.Repositories.Interfaces;

namespace MusicLab.Repository.Repositories
{
    public class FavouriteRepository : BaseRepository<Favourite>, IFavouriteRepository
    {
        private readonly MusicLabContext _context;
        public FavouriteRepository(MusicLabContext context) : base(context)
        {
            _context = context;
        }
    }
}
