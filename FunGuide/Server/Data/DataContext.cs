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
                { Id = 2, Name = "MMA"},
                new Sport 
                { Id = 3, Name ="Basketball"}
            );
            modelBuilder.Entity<Citizenship>().HasData(
               new Citizenship
               { Id = 1, Name = "Ukrainian" },
               new Citizenship
               { Id = 2, Name = "Pole" },
               new Citizenship
               { Id = 3, Name = "Czech" }
           );
            
        }
        public DbSet<Sportsman> Sportsmen { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Citizenship> Citizenships { get; set; }
    }
}
