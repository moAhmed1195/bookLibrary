using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required,MaxLength (255)]
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
