using Microsoft.EntityFrameworkCore;

namespace RT.Data;

public static class WebApplicationExtensions
{
    public static async Task SeedRTDBContext(this WebApplication app)
    {
        // Seed the database with initial data
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<RTDBContext>();

        var dbSeeder = new DbSeeder(context);
        await dbSeeder.SeedAsync();
    }
}

public class DbSeeder(RTDBContext context)
{
    public async Task SeedAsync()
    {
        await SeedProductCategories();
        await SeedProducts();
    }

    private async Task SeedProductCategories()
    {
        if (!context.ProductsCategories.Any())
        {
            var productCategories = new[]
            {
                new ProductCategory { Id = 1, Name = "Hardware" },
                new ProductCategory { Id = 2, Name = "Subscriptions" },
            };

            context.ProductsCategories.AddRange(productCategories);
            await context.SaveChangesAsync();
        }
    }

    private async Task SeedProducts()
    {
        if (!context.Products.Any())
        {
            var hardwareCategoryId = context.ProductsCategories.First(category => category.Name == "Hardware").Id;
            var subscriptionCategoryId = context.ProductsCategories.First(category => category.Name == "Subscriptions").Id;

            var products = new[]
            {
                new Product
                {
                    Id = 1, Name = "Test 1", Description = "Product Description", Price = (decimal)19.99,
                    ProductCategoryId = hardwareCategoryId
                },
                new Product
                {
                    Id = 2, Name = "Test 2", Description = "Product Description", Price = (decimal)19.99,
                    ProductCategoryId = hardwareCategoryId
                },
                new Product
                {
                    Id = 3, Name = "Test 3", Description = "Product Description", Price = (decimal)19.99,
                    ProductCategoryId = subscriptionCategoryId
                }
            };

            context.Products.AddRange(products);
            await context.SaveChangesAsync();
        }
    }
}