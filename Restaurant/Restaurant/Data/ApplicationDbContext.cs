using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Data
{
   
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {

            }

            public DbSet<Customer>Customers { get; set; }

            public DbSet<FoodItem>FoodItems { get; set; }

            public DbSet<Menu>Menu { get; set; }

            public DbSet<Reservation>Reservations { get; set; }

            public DbSet<Waiter>Waiters { get; set; }
        
    }
    
}
