using JWTDemo.Model;
using Microsoft.EntityFrameworkCore;

namespace JWTDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDemo>().HasData(
            new List<UserDemo>
            {
               new UserDemo
               {
                   UserId = 1,
                   Username = "admin",
                   Password = "admin",
                   Role = "admin"
               },
               new UserDemo
               {
                   UserId = 2,
                   Username = "User1",
                   Password = "1",
                   Role = "user"
               }
            });
        }
        public DbSet<UserDemo> TblUsers { get; set; }
    }
}
