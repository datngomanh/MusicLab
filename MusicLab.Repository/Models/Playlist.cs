using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicLab.Repository.Models
{
    [Table("Playlist")]
    public class Playlist
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Username { get; set; } = null!;
        public DateTime CreatedDate { get; set; }

        public Playlist(string title, string username, DateTime createdDate)
        {
            Title = title;
            Username = username;
            CreatedDate = createdDate;
        }

        public Playlist()
        {
        }

        public virtual User User { get; set; }
        public virtual ICollection<PlaylistSong> PlaylistSongs { get; set; }
    }
}
