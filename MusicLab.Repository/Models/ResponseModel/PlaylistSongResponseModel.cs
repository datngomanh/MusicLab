using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLab.Repository.Models.ResponseModel
{
    public class PlaylistSongResponseModel
    {
        public int PlaylistId { get; set; }
        public int SongId { get; set; }
        public DateTime DateAdded { get; set; }
        public SongResponseModel Song { get; set; }
    }
}
