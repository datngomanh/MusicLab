using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicLab.Repository.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsGenre { get; set; }
        public string Image { get; set; }

        public Category()
        {
        }

        public Category(string name, string? description, bool isGenre, string image)
        {
            Name = name;
            Description = description;
            IsGenre = isGenre;
            Image = image;
        }

        public virtual ICollection<SongCategory> SongCategories { get; set; }
    }
}
