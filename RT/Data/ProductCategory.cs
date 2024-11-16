using System.Text.Json.Serialization;

namespace RT.Data;

public class ProductCategory
{
    public int Id { get; set; }
    public string Name { get; set; }
    [JsonIgnore]

    public ICollection<Product> Products { get; set; } = new List<Product>();

}