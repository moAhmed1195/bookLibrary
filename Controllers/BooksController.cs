using BookStore.Models;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var books = await _context.Books.ToListAsync();
            return View(books);
        }
        public async Task<IActionResult> Create()
        {
            var viewModel = new BookFormViewModel
            {
                Authors= await _context.Authors.OrderBy(m=>m.Name).ToListAsync(),
                Tags=await _context.Tags.OrderBy(m => m.Name).ToListAsync(),
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookFormViewModel model)
        {
			model.Authors = await _context.Authors.OrderBy(m => m.Name).ToListAsync();
			model.Tags = await _context.Tags.OrderBy(m => m.Name).ToListAsync();
			if (!ModelState.IsValid)
            {
				return View(model);
            }
            // check on file exists or not 
            var files = Request.Form.Files;
            if (!files.Any())
            {
                ModelState.AddModelError("Poster", "Please select book Poster!");
                return View(model);
            }
            //check on extension file 
            var poster = files.FirstOrDefault();
            var allowedExtensions = new List<string> { ".jpg", ".png" };

            if (!allowedExtensions.Contains(Path.GetExtension(poster.FileName).ToLower()))
            {
                ModelState.AddModelError("Poster", "Only .png , . jpg images are allowed");
                return View(model);
            }
            if(poster.Length> 2206720)
            {
                ModelState.AddModelError("Poster", "Too large file");
                return View(model);
            }

            using var dataStream = new MemoryStream();
            await poster.CopyToAsync(dataStream);

            

            var book = new Book
            {
                Title = model.Title,
                Description = model.Description,
                Publisher = model.Publisher,
                PublishedOn = model.PublishedOn,
                Price = model.Price,
                Poster = dataStream.ToArray(),
                
                //bookAuthors=new ICollection<bookAuthor>()
                //{
                   
                //}
                
            };
			List<bookAuthor> bkAuth = new List<bookAuthor>();
            var order = 0;
			foreach (var authid in model.AuthorId)
			{
                bkAuth.Add(new bookAuthor
                {
                    book = book,
                    authorId=authid,
                    order=++order,
                }); 
			}
            book.bookAuthors= bkAuth;
            var selectedTags=from res in _context.Tags
                             where model.TagId.Contains(res.Id) 
                             select res;
            book.tags = selectedTags.ToList();


           

            _context.Books.Add(book);
            _context.SaveChanges();

           

            return RedirectToAction(nameof(Index));
        }

    }
}
