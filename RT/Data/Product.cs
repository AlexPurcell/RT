using System.Text.Json.Serialization;

namespace RT.Data;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int ProductCategoryId { get; set; }
    public ProductCategory Category { get; set; }
    
    
}