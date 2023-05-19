using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Authors
    {
        public int Id { get; set; }

        [Required,MaxLength(200)]
        public string Name { get; set; }

        public virtual ICollection<bookAuthor> bookAuthors { get; set; }
    }
}
