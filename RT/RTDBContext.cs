using Adaptive;
using Microsoft.EntityFrameworkCore;
using RT.Data;

namespace RT;

public class RTDBContext(DbContextOptions options) : CoreContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductsCategories { get; set; }

}