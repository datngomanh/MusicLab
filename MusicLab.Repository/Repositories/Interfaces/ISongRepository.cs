using MusicLab.Repository.Models;

namespace MusicLab.Repository.Repositories.Interfaces
{
    public interface ISongRepository : IBaseRepository<Song>
    {
        public Task<List<Song>> GetAllRecommendedSongs(string username, int? top);
    }
}
