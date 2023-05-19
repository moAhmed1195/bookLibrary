using Microsoft.EntityFrameworkCore;

namespace BookStore.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<bookAuthor>()
                .HasKey(bc => new {bc.bookId,bc.authorId});

            modelBuilder.Entity<bookAuthor>()
                .HasOne(bc => bc.book)
                .WithMany(b => b.bookAuthors)
                .HasForeignKey(bc => bc.bookId);

            modelBuilder.Entity<bookAuthor>()
                .HasOne(a => a.author)
                .WithMany(a => a.bookAuthors)
                .HasForeignKey(a => a.authorId);
        }
        
        public virtual DbSet<Book> Books { get; set;}
        public virtual DbSet<Reviews> Reviews { get; set;}

        public virtual DbSet<PriceOffer> PriceOffers { get; set;}

        public virtual DbSet<Authors> Authors { get; set;}

        public virtual DbSet<bookAuthor> bookAuthors { get; set;}

        public virtual DbSet<Tag> Tags { get; set;}
    }
}
