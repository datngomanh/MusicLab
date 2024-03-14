using System.ComponentModel.DataAnnotations.Schema;

namespace MusicLab.Repository.Models
{
    [Table("SongArtist")]
    public class SongArtist
    {
        public int ArtistId { get; set; }
        public int SongId { get; set; }
        public DateTime DateAdded { get; set; }

        public SongArtist(int artistId, int songId, DateTime dateAdded)
        {
            ArtistId = artistId;
            SongId = songId;
            DateAdded = dateAdded;
        }

        public SongArtist()
        {
        }

        public virtual Artist Artist { get; set; }
        public virtual Song Song { get; set; }
    }
}
