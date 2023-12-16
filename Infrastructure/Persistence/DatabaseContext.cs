using Microsoft.EntityFrameworkCore;
using users_api.Domain.Entities;

namespace users_api.Infrastructure.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
                {
                    Id = 1,
                    FirstName = "Reynaldo",
                    LastName = "Cano",
                    Email = "roninjosue88@gmail.com",
                    CreatedAt = DateTime.Now,
                    Age = 35
                    // Populate other properties as required
                },
                new User
                {
                    Id = 2,
                    FirstName = "John",
                    LastName = "password123",
                    Email = "email@gmail.com",
                    CreatedAt = DateTime.Now,
                    Age = 34
                    // Populate other properties as required
                });

            // Add more users as required
        }
    }
}
