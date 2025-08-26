using Microsoft.EntityFrameworkCore;
using Searchify.Domain.Model;

namespace Searchify.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
