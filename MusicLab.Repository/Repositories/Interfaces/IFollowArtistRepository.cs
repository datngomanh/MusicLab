using MusicLab.Repository.Models;

namespace MusicLab.Repository.Repositories.Interfaces
{
    public interface IFollowArtistRepository : IBaseRepository<FollowArtist>
    {
        Task<List<Artist>> GetFollowArtist(string username);
    }
}
