using Microsoft.EntityFrameworkCore;
using Test_API.Models;

namespace Test_API.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
            
        }

        public MyDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Genre> genres { get; set; }
        public DbSet<Movie> movies { get; set; }
        public DbSet<Actor> actors { get; set; }
    }
}
