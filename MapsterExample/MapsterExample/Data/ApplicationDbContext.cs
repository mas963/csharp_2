using MapsterExample.Entities;
using Microsoft.EntityFrameworkCore;

namespace MapsterExample.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Company> Companies { get; set; }

}
