using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace MusicLab.Repository.Models
{
    public partial class MusicLabContext : DbContext
    {
        public MusicLabContext()
        {
        }

        public MusicLabContext(DbContextOptions<MusicLabContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("ConnectionString"));
            }
        }
        public virtual DbSet<Song> Songs { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Album> Albums { get; set; } = null!;
        public virtual DbSet<SongCategory> SongCategories { get; set; } = null!;
        public virtual DbSet<Artist> Artists { get; set; } = null!;
        public virtual DbSet<FollowArtist> FollowArtists { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Favourite> Favourites { get; set; } = null!;
        public virtual DbSet<Playlist> Playlists { get; set; } = null!;
        public virtual DbSet<PlaylistSong> PlaylistSongs { get; set; } = null!;
        public virtual DbSet<PlayHistory> PlayHistories { get; set; } = null!;
        public virtual DbSet<SongArtist> SongArtists { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>().HasMany(e => e.Songs)
                .WithOne(e => e.Album)
                .IsRequired(false)
                .HasForeignKey(e => e.AlbumId)
                .HasPrincipalKey(e => e.Id)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<SongCategory>().HasOne(e => e.Song)
                .WithMany(e => e.SongCategories)
                .HasForeignKey(e => e.SongId)
                .HasPrincipalKey(e => e.Id);
            modelBuilder.Entity<SongCategory>().HasOne(e => e.Category)
                .WithMany(e => e.SongCategories)
                .HasForeignKey(e => e.CategoryId)
                .HasPrincipalKey(e => e.Id);
            modelBuilder.Entity<SongCategory>().HasKey(e => new {e.SongId, e.CategoryId});

            modelBuilder.Entity<Album>().HasOne(e => e.Artist)
                .WithMany(e => e.Albums)
                .HasForeignKey(e => e.ArtistId)
                .HasPrincipalKey(e => e.Id);

            modelBuilder.Entity<FollowArtist>().HasKey(e => new {e.Username, e.ArtistId});
            modelBuilder.Entity<FollowArtist>().HasOne(e => e.User)
                .WithMany(e => e.FollowArtists)
                .HasForeignKey(e => e.Username)
                .HasPrincipalKey(e => e.Username);
            modelBuilder.Entity<FollowArtist>().HasOne(e => e.Artist)
                .WithMany(e => e.FollowArtists)
                .HasForeignKey(e => e.ArtistId)
                .HasPrincipalKey(e => e.Id);

            modelBuilder.Entity<Favourite>().HasKey(e => new { e.Username, e.SongId });
            modelBuilder.Entity<Favourite>().HasOne(e => e.User)
                .WithMany(e => e.Favourites)
                .HasForeignKey(e => e.Username)
                .HasPrincipalKey(e => e.Username);
            modelBuilder.Entity<Favourite>().HasOne(e => e.Song)
                .WithMany(e => e.Favourites)
                .HasForeignKey(e => e.SongId)
                .HasPrincipalKey(e => e.Id);

            modelBuilder.Entity<PlaylistSong>().HasKey(e => new { e.PlaylistId, e.SongId });
            modelBuilder.Entity<PlaylistSong>().HasOne(e => e.Playlist)
                .WithMany(e => e.PlaylistSongs)
                .HasForeignKey(e => e.PlaylistId)
                .HasPrincipalKey(e => e.Id);
            modelBuilder.Entity<PlaylistSong>().HasOne(e => e.Song)
                .WithMany(e => e.PlaylistSongs)
                .HasForeignKey(e => e.SongId)
                .HasPrincipalKey(e => e.Id);

            modelBuilder.Entity<PlayHistory>().HasKey(e => new { e.Username, e.SongId });
            modelBuilder.Entity<PlayHistory>().HasOne(e => e.User)
                .WithMany(e => e.PlayHistories)
                .HasForeignKey(e => e.Username)
                .HasPrincipalKey(e => e.Username);
            modelBuilder.Entity<PlayHistory>().HasOne(e => e.Song)
                .WithMany(e => e.PlayHistories)
                .HasForeignKey(e => e.SongId)
                .HasPrincipalKey(e => e.Id);

            modelBuilder.Entity<Playlist>().HasOne(e => e.User)
                .WithMany(e => e.Playlists)
                .HasForeignKey(e => e.Username)
                .HasPrincipalKey(e => e.Username);

            modelBuilder.Entity<SongArtist>().HasKey(e => new { e.ArtistId, e.SongId });
            modelBuilder.Entity<SongArtist>().HasOne(e => e.Artist)
                .WithMany(e => e.SongArtists)
                .HasForeignKey(e => e.ArtistId)
                .HasPrincipalKey(e => e.Id);
            modelBuilder.Entity<SongArtist>().HasOne(e => e.Song)
                .WithMany(e => e.SongArtists)
                .HasForeignKey(e => e.SongId)
                .HasPrincipalKey(e => e.Id);
        }
    }
}
