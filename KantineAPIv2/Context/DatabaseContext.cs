using KantineAPIv2.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace KantineAPIv2.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
        //DbSets for the tables in our Database, these DbSets are a collection of all Entities in table with the same name as the DbSet argument
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
    }
}
