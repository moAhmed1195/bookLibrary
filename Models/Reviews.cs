using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Reviews
    {
        public int Id { get; set; }

        [Required,MaxLength(200)]
        public string VoterName { get; set; }

        [Range(0,10)]
        public int NumStars { get; set; }

        [Required,MaxLength(2000)]
        public string Comment { get; set; }

        public int bookId { get; set; }
        public virtual Book book { get; set; }


    }
}
