namespace MusicLab.Repository.Models.RequestModel
{
    public class AddSongToPlaylistRequestModel
    {
        public int SongId { get; set; }
        public int PlaylistId { get; set; }
    }
}
