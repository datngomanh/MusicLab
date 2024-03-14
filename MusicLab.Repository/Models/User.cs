using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicLab.Repository.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string FullName { get; set; } = null!;
        public string? Email { get; set; }
        public string? Avatar { get; set; }
        public bool Gender { get; set; }

        public User(string username, string password, string fullName, string? email, string? avatar, bool gender)
        {
            Username = username;
            Password = password;
            FullName = fullName;
            Email = email;
            Avatar = avatar;
            Gender = gender;
        }

        public User()
        {
        }

        public virtual ICollection<FollowArtist> FollowArtists { get; set; }
        public virtual ICollection<Favourite> Favourites { get; set; }
        public virtual ICollection<PlayHistory> PlayHistories { get; set; }
        public virtual ICollection<Playlist> Playlists { get; set; }
    }
}
