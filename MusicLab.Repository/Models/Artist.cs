using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicLab.Repository.Models
{
    [Table("Artist")]
    public class Artist
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Biography { get; set; } = null!;

        public string? Image { get; set; }
        public string? CoverImage { get; set; }

        public Artist(string name, string biography, string? image, string? coverImage)
        {
            Name = name;
            Biography = biography;
            Image = image;
            CoverImage = coverImage;
        }

        public Artist()
        {
        }

        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<FollowArtist> FollowArtists { get; set; }
        public virtual ICollection<SongArtist> SongArtists { get; set; }
    }
}
