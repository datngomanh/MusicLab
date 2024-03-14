using MusicLab.Repository.Models;
using MusicLab.Repository.Repositories.Interfaces;

namespace MusicLab.Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly MusicLabContext _context;
        public UserRepository(MusicLabContext context) : base(context)
        {
            _context = context;
        }
    }
}
