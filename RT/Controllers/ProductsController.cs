using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RT.Data;

namespace RT.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController(RTDBContext context) : ControllerBase
{
    [HttpGet("")]
    public async Task<ActionResult<Product>> GetProducts()
    {
        var products = await context.Products.Include(product => product.Category).ToListAsync();

        return Ok(products);
    }

    [HttpGet("{categoryId:int:min(1)}")]
    public async Task<ActionResult<Product>> GetProductsByCategory(int categoryId)
    {
        var products = await context.Products.Include(product => product.Category)
            .Where(product => product.ProductCategoryId == categoryId).ToListAsync();

        return Ok(products);
    }
}