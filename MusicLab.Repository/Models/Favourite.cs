using System.ComponentModel.DataAnnotations.Schema;

namespace MusicLab.Repository.Models
{
    [Table("Favourite")]
    public class Favourite
    {
        public string Username { get; set; } = null!;
        public int SongId { get; set; }
        public DateTime LikedDate { get; set; }

        public Favourite()
        {
        }

        public Favourite(string username, int songId, DateTime likedDate)
        {
            Username = username;
            SongId = songId;
            LikedDate = likedDate;
        }

        public virtual User User { get; set; }
        public virtual Song Song { get; set; }
    }
}
