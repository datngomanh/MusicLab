using System.ComponentModel.DataAnnotations.Schema;

namespace MusicLab.Repository.Models
{
    [Table("SongCategory")]
    public class SongCategory
    {
        public int SongId { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }

        public SongCategory()
        {
        }

        public SongCategory(int songId, int categoryId, DateTime createdDate)
        {
            SongId = songId;
            CategoryId = categoryId;
            CreatedDate = createdDate;
        }

        public virtual Category Category { get; set; }
        public virtual Song Song { get; set; }
    }
}
