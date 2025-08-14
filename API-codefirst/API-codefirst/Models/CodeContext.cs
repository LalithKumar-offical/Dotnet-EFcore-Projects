using Microsoft.EntityFrameworkCore;

namespace API_codefirst.Models
{
    public class CodeContext : DbContext
    {
        internal readonly object BookService;

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasData(new Author
                {
                    authorId = 1,
                    authorName = "Lalith Kumar",
                    phoneNumber = 8317
                },
                new Author
                {
                    authorId = 2,
                    authorName = "Hajeera",
                    phoneNumber = 8315

                });
            modelBuilder.Entity<Book>().HasData(
               new Book
               {
                   bookId = 1,
                   bookTitle = "C# Basics",
                   authorId = 1
               },
               new Book
               {
                   bookId = 2,
                   bookTitle = "Advanced EF Core",
                   authorId = 2
               }
           );
        }


        public CodeContext(DbContextOptions<CodeContext> options): base(options)
        {
        }

    }
}
