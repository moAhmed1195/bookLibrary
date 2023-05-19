using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required,MaxLength(200)]
        public string Title { get; set; }

        [Required,MaxLength(2000)]
        public string Description { get; set; }

        [Required,MaxLength(200)]
        public string Publisher { get; set; }

        public DateTime PublishedOn { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public byte[] Poster { get; set; }

        public virtual ICollection<Reviews> Reviews { get; set; }

        public virtual PriceOffer PriceOffer { get; set; }

        public virtual ICollection<bookAuthor> bookAuthors { get; set; }

        public virtual ICollection<Tag> tags { get; set; }

    }
}
