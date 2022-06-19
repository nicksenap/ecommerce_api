namespace ecommerce_api.Models;

public class AddProductRequestModel
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public string CategoryId { get; set; }
}
