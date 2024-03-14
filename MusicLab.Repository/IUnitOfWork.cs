using MusicLab.Repository.Repositories.Interfaces;

namespace MusicLab.Repository
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public IAlbumRepository AlbumRepository { get; }
        public IArtistRepository ArtistRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IFavouriteRepository FavouriteRepository { get; }
        public IFollowArtistRepository FollowArtistRepository { get; }
        public IPlaylistRepository PlaylistRepository { get; }
        public IPlayHistoryRepository PlayHistoryRepository { get; }
        public IPlaylistSongRepository PlaylistSongRepository { get; }
        public ISongRepository SongRepository { get; }
        public ISongCategoryRepository SongCategoryRepository { get; }
        public ISongArtistRepository SongArtistRepository { get; }
    }
}
