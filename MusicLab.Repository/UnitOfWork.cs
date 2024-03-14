using MusicLab.Repository.Models;
using MusicLab.Repository.Repositories;
using MusicLab.Repository.Repositories.Interfaces;

namespace MusicLab.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MusicLabContext _context;

        private IUserRepository _userRepository;
        private IAlbumRepository _albumRepository;
        private IArtistRepository _artistRepository;
        private ICategoryRepository _categoryRepository;
        private IFavouriteRepository _favouriteRepository;
        private IFollowArtistRepository _followArtistRepository;
        private IPlaylistRepository _playlistRepository;
        private IPlayHistoryRepository _playHistoryRepository;
        private IPlaylistSongRepository _playlistSongRepository;
        private ISongRepository _songRepository;
        private ISongCategoryRepository _songCategoryRepository; 
        private ISongArtistRepository _songArtistRepository;

        public UnitOfWork(MusicLabContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository { get { return _userRepository ?? new UserRepository(_context); } }
        public IAlbumRepository AlbumRepository { get { return _albumRepository ?? new AlbumRepository(_context); } }
        public IArtistRepository ArtistRepository { get { return _artistRepository ?? new ArtistRepository(_context); } }
        public ICategoryRepository CategoryRepository { get { return _categoryRepository ?? new CategoryRepository(_context); } }
        public IFavouriteRepository FavouriteRepository { get { return _favouriteRepository ?? new FavouriteRepository(_context); } }
        public IFollowArtistRepository FollowArtistRepository { get { return _followArtistRepository ?? new FollowArtistRepository(_context); } }
        public IPlaylistRepository PlaylistRepository { get { return _playlistRepository ?? new PlaylistRepository(_context); } }
        public IPlayHistoryRepository PlayHistoryRepository { get { return _playHistoryRepository ?? new PlayHistoryRepository(_context); } }
        public IPlaylistSongRepository PlaylistSongRepository { get { return _playlistSongRepository ?? new PlaylistSongRepository(_context); } }
        public ISongRepository SongRepository { get { return _songRepository ?? new SongRepository(_context); } }
        public ISongCategoryRepository SongCategoryRepository { get { return _songCategoryRepository ?? new SongCategoryRepository(_context); } }
        public ISongArtistRepository SongArtistRepository { get { return _songArtistRepository ?? new SongArtistRepository(_context); } }
    }
}
