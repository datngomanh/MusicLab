using System.ComponentModel.DataAnnotations.Schema;

namespace MusicLab.Repository.Models
{
    [Table("FollowArtist")]
    public class FollowArtist
    {
        public string Username { get; set; } = null!;
        public int ArtistId { get; set; }
        public DateTime FollowDate { get; set; }

        public FollowArtist(string username, int artistId, DateTime followDate)
        {
            Username = username;
            ArtistId = artistId;
            FollowDate = followDate;
        }

        public FollowArtist()
        {
        }

        public virtual User User { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
