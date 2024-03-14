using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLab.Repository.Models.ResponseModel
{
    public class ArtistResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Biography { get; set; } = null!;

        public string? Image { get; set; }
        public string? CoverImage { get; set; }
    }
}
