using System.ComponentModel.DataAnnotations.Schema;

namespace MusicLab.Repository.Models
{
    [Table("PlaylistSong")]
    public class PlaylistSong
    {
        public int PlaylistId { get; set; }
        public int SongId { get; set; }
        public DateTime DateAdded { get; set; }

        public PlaylistSong(int playlistId, int songId, DateTime dateAdded)
        {
            PlaylistId = playlistId;
            SongId = songId;
            DateAdded = dateAdded;
        }

        public PlaylistSong()
        {
        }

        public virtual Playlist Playlist { get; set; }
        public virtual Song Song { get; set; }
    }
}
