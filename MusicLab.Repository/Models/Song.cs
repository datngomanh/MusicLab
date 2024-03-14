using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicLab.Repository.Models
{
    [Table("Song")]
    public class Song
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Title { get; set; } = null!;
        [Required]
        [Column(TypeName = "text")]
        public string Link { get; set; } = null!;
        public long Duration { get; set; }
        [Required]
        public DateTime DatePublished { get; set; }
        public int? AlbumId { get; set; }
        [MaxLength(200)]
        public string? Image { get; set; }
        public int NumberOfListen { get; set; }

        public Song()
        {
        }

        public Song(string title, string link, long duration, DateTime datePublished, int? albumId, string? image, int numberOfListen)
        {
            Title = title;
            Link = link;
            Duration = duration;
            DatePublished = datePublished;
            AlbumId = albumId;
            Image = image;
            NumberOfListen = numberOfListen;
        }
        public virtual Album Album { get; set; }
        public virtual ICollection<SongCategory> SongCategories { get; set; }
        public virtual ICollection<Favourite> Favourites { get; set; }
        public virtual ICollection<PlaylistSong> PlaylistSongs { get; set; }
        public virtual ICollection<PlayHistory> PlayHistories { get; set; }
        public virtual ICollection<SongArtist> SongArtists { get; set; }
    }
}
