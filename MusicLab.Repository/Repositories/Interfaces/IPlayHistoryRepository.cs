using MusicLab.Repository.Models;

namespace MusicLab.Repository.Repositories.Interfaces
{
    public interface IPlayHistoryRepository : IBaseRepository<PlayHistory>
    {
        public Task<List<Song>> GetTop6LastPlayedSongs(string username);
    }
}
