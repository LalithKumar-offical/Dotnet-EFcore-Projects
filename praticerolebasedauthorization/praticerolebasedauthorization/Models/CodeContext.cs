using Microsoft.EntityFrameworkCore;

namespace praticerolebasedauthorization.Models
{
    public class CodeContext: DbContext
    {
        public DbSet<Webseries> DbWebSeries { get; set; }
        public DbSet<User> DbUsers { get; set; }
        public CodeContext(DbContextOptions<CodeContext> options):base(options) 
        {

        }


    }
}
