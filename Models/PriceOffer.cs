using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class PriceOffer
    {
        public int Id { get;set; }

        public float newPrice { get;set; }
        [MaxLength(1000)]
        public string PromotionalText { get; set; }

        public int bookId { get; set; }

        public virtual Book book { get; set; }

    }
}
