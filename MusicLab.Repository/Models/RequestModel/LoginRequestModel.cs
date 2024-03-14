using System.ComponentModel.DataAnnotations;

namespace MusicLab.Repository.Models.RequestModel
{
    public class LoginRequestModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Username { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Password { get; set; }
    }
}
