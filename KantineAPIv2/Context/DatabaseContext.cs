using KantineAPIv2.Entities;
using System.Collections.Generic;

namespace KantineAPIv2.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
    }
}
