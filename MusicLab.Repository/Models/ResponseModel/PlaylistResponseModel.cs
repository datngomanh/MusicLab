using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLab.Repository.Models.ResponseModel
{
    public class PlaylistResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Username { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public ICollection<PlaylistSongResponseModel> PlaylistSongs { get; set; }
    }
}
