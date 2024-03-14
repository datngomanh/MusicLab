namespace MusicLab.Repository.Models.ResponseModel
{
    public class SongArtistResponseModel
    {
        public int ArtistId { get; set; }
        public int SongId { get; set; }
        public ArtistResponseModel Artist { get; set; }
    }
}
