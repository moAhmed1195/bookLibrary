using BookStore.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels
{
	public class BookFormViewModel
	{

		[Required, StringLength(200)]
		public string Title { get; set; }

		[Required, StringLength(2000)]
		public string Description { get; set; }

		[Required, StringLength(200)]
		public string Publisher { get; set; }

		public DateTime PublishedOn { get; set; }

		[Required,Range(1,1000)]
		public float Price { get; set; }

		public byte[]? Poster { get; set; }

		[Display(Name ="Author")]
		public IEnumerable<int> AuthorId { get; set; }
		
		[Display(Name ="Tag")]
		public IEnumerable<int> TagId { get; set; }
		public IEnumerable<Authors>? Authors { get; set; }

		public IEnumerable<Tag>? Tags { get; set; }
	}
}
