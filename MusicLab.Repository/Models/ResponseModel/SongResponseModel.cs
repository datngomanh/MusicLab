using MusicLab.Repository.Models.RequestModel;

namespace MusicLab.Repository.Models.ResponseModel
{
    public class SongResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Link { get; set; } = null!;
        public long Duration { get; set; }
        public DateTime DatePublished { get; set; }
        public int? AlbumId { get; set; }
        public string? Image { get; set; }
        public int NumberOfListen { get; set; }
        public List<SongArtistResponseModel> SongArtists { get; set; }
    }
}
