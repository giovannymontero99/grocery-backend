using GroceryBackend.src.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GroceryBackend.src.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        // Tables from grocery_db
        public DbSet<User> User { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<UserProduct> UserProduct { get; set; }


    }
}
