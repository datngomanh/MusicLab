using System.ComponentModel.DataAnnotations.Schema;

namespace MusicLab.Repository.Models
{
    [Table("PlayHistory")]
    public class PlayHistory
    {
        public string Username { get; set; } = null!;
        public int SongId { get; set; }
        public DateTime PlayedDate { get; set; }
        public long Duration { get; set; }

        public PlayHistory()
        {
        }

        public PlayHistory(string username, int songId, DateTime playedDate, long duration)
        {
            Username = username;
            SongId = songId;
            PlayedDate = playedDate;
            Duration = duration;
        }

        public virtual User User { get; set; }
        public virtual Song Song { get; set; }
    }
}
