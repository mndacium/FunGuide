using Microsoft.EntityFrameworkCore;
using FunGuide.Shared;
namespace FunGuide.Server.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sport>().HasData(
                new Sport
                { Id = 1, Name = "Football" },
                new Sport
                { Id = 2, Name = "MMA"}
            );
            modelBuilder.Entity<Sportsman>().HasData(
                new Sportsman
                {
                    Id = 1,
                    FirstName = "Vlad",
                    LastName = "Tanasiichuk",
                    BirthDate = null,
                    Age = 22,
                    Height = 1.82,
                    Weight = 75.8,
                    Сitizenship = "Ukrainian",
                    SportId=1
                },
                new Sportsman
                {
                    Id = 2,
                    FirstName = "Andrey",
                    LastName = "Huila",
                    BirthDate = DateTime.Today,
                    Age = 21,
                    Height = 1.8,
                    Weight = 75.3,
                    Сitizenship = "Ukrainian",
                    SportId=2
                }
            );
        }
        public DbSet<Sportsman> Sportsmen { get; set; }
        public DbSet<Sport> Sports { get; set; }
    }
}
