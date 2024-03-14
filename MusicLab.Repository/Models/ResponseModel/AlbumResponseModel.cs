using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLab.Repository.Models.ResponseModel
{
    public class AlbumResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime DatePublished { get; set; }
        public int ArtistId { get; set; }
        public string Image { get; set; }
        public int NumberOfListen { get; set; }
        public ArtistResponseModel Artist { get; set; }
    }
}
