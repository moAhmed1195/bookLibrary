using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class bookAuthor
    {
      //  [Key,Column(Order =0)]
        public int bookId { get; set; }
      //  [Key,Column(Order =1)]
        public int authorId { get; set; }

        public int order { get;set; }


        public virtual Book book { get; set; }

        public virtual Authors author { get; set; }

        
    }
}
