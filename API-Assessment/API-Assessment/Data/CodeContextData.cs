using API_Assessment.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Assessment.Data
{
    public class CodeContextData : DbContext
    {
        public virtual DbSet<DirectorClass> DbDirector { get; set; }
        public virtual DbSet<RatingClass> DbRating { get; set; }
        public virtual DbSet<SeasonsClass> DbSeason { get; set; }

        public virtual DbSet<UserClass> DbUser { get; set; }
        public virtual DbSet<WebseriesClass> DbWebseries { get; set; }
        public CodeContextData(DbContextOptions<CodeContextData> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WebseriesClass>()
    .Property(w => w.WebseriesDate)
    .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<RatingClass>()
                .Property(r => r.RatingDate)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<DirectorClass>().HasData(
                new DirectorClass
                {
                    DirectorId = "Dir_101",
                    DirectorName = "Alex Pina",
                    DirectorAge = 45,
                    DirectorEmail = "alexpina@gmail.com",
                    DirectorPassword = "alexpina",
                    DirectorExperience = "21"
                },
                new DirectorClass
                {
                    DirectorId = "Dir_102",
                    DirectorName = "Baran Bo Odar",
                    DirectorAge = 42,
                    DirectorEmail = "baranboodar@gmail.com",
                    DirectorPassword = "baranboodar",
                    DirectorExperience = "17"
                },
                new DirectorClass
                {
                    DirectorId = "Dir_103",
                    DirectorName = "Sharad Devarajan",
                    DirectorAge = 50,
                    DirectorEmail = "sharaddevarajan@gmail.com",
                    DirectorPassword = "sharaddevarajan",
                    DirectorExperience = "27"
                },
                new DirectorClass
                {
                    DirectorId = "Dir_104",
                    DirectorName = "Christopher Nolan",
                    DirectorAge = 55,
                    DirectorEmail = "christophernolan@gmail.com",
                    DirectorPassword = "christopher",
                    DirectorExperience = "32"
                }
                );
            modelBuilder.Entity<UserClass>().HasData(
                 new UserClass { UserId = 1, UserName = "Lalith", UserEmail = "lalith@gmail.com", UserPassword = "lalith", UserAdult = true },
                 new UserClass { UserId = 2, UserName = "Hadiya", UserEmail = "hadiya@gmail.com", UserPassword = "hadiya", UserAdult = true },
                 new UserClass { UserId = 3, UserName = "Reshni", UserEmail = "Reshni@gmail.com", UserPassword = "Reshni", UserAdult = false }
             );
            modelBuilder.Entity<WebseriesClass>().HasData(
       new WebseriesClass
       {
           WebseriesId = "Web_101",
           WebseriesTitle = "Money Heist",
           WebseriesDate = new DateOnly(2022, 1, 1),   // 👈 fixed seed date
           WebseriesType = "Thriller",
           WebseriesAgerestrictions = "18+",
           DirectorId = "Dir_101"
       },
       new WebseriesClass
       {
           WebseriesId = "Web_102",
           WebseriesTitle = "Dark",
           WebseriesDate = new DateOnly(2022, 2, 10),
           WebseriesType = "Sci-Fi",
           WebseriesAgerestrictions = "16+",
           DirectorId = "Dir_102"
       },
       new WebseriesClass
       {
           WebseriesId = "Web_103",
           WebseriesTitle = "The Legend of Hanuman",
           WebseriesDate = new DateOnly(2022, 3, 15),
           WebseriesType = "Mythology",
           WebseriesAgerestrictions = "7+",
           DirectorId = "Dir_103"
       }
   );
            modelBuilder.Entity<RatingClass>().HasData(
                new RatingClass
                {
                    RatingId = "R101",
                    RatingNo = 5,
                    RatingComment = "Amazing!",
                    RatingDate = new DateOnly(2022, 1, 1),
                    WebseriesId = "Web_101",
                    UserId = "1"
                },
                new RatingClass
                {
                    RatingId = "R102",
                    RatingNo = 4,
                    RatingComment = "Mind-blowing",
                    RatingDate = new DateOnly(2022, 2, 15),
                    WebseriesId = "Web_102",
                    UserId = "2"
                },
                new RatingClass
                {
                    RatingId = "R103",
                    RatingNo = 3,
                    RatingComment = "Good animation",
                    RatingDate = new DateOnly(2022, 3, 5),
                    WebseriesId = "Web_103",
                    UserId = "3"
                }
            );

            modelBuilder.Entity<SeasonsClass>().HasData(
           new SeasonsClass { SeasonId = "S101", SeasonPhoto = "/Images/moneyheist_s1.jpg", WebseriesId = "Web_101" },
           new SeasonsClass { SeasonId = "S102", SeasonPhoto = "/Images/moneyheist_s2.jpg", WebseriesId = "Web_101" },
           new SeasonsClass { SeasonId = "S201", SeasonPhoto = "/Images/dark_s1.jpg", WebseriesId = "Web_102" },
           new SeasonsClass { SeasonId = "S301", SeasonPhoto = "/Images/hanuman_s1.jpg", WebseriesId = "Web_103" }
       );
            modelBuilder.Entity<WebseriesClass>()
        .HasOne(w => w.DirectorInstance)
        .WithMany(d => d.WebseriesInstance)
        .HasForeignKey(w => w.DirectorId)
        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SeasonsClass>()
                .HasOne(s => s.WebseriesInstance)
                .WithMany(w => w.SeasonsInstance)
                .HasForeignKey(s => s.WebseriesId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
