using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicLab.Repository.Models
{
    [Table("Album")]
    public class Album
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public DateTime DatePublished { get; set; }
        public int ArtistId { get; set; }
        public string Image { get; set; }
        public int NumberOfListen { get; set; }

        public Album(string title, DateTime datePublished, int artistId, string image, int numberOfListen)
        {
            Title = title;
            DatePublished = datePublished;
            ArtistId = artistId;
            Image = image;
            NumberOfListen = numberOfListen;
        }

        public Album()
        {
        }

        public virtual ICollection<Song> Songs { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
