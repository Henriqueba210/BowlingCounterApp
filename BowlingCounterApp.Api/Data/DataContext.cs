using BowlingCounterApp.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BowlingCounterApp.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}