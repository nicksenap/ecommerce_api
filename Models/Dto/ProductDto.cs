namespace ecommerce_api.Models.Dto;

public class ProductDto
{
    public ProductDto(string name, string imageUrl, double price, string description, Category category)
    {
        Name = name;
        ImageUrl = imageUrl;
        Price = price;
        Description = description;
        Category = category;
        Id = Guid.NewGuid().ToString();
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public Category Category { get; set; }
}