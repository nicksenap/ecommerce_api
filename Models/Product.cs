using System.ComponentModel.DataAnnotations;
using static System.Guid;

namespace ecommerce_api.Models;

public class Product
{
    public Product(string name, string imageUrl, double price, string description)
    {
        Id = NewGuid().ToString();
        Name = name;
        ImageUrl = imageUrl;
        Price = price;
        Description = description;
    }

    [Key]
    public string Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string ImageUrl { get; set; }
    
    [Required]
    public double Price { get; set; }
    
    [Required]
    public  string Description { get; set; }
    
    public Category Category { get; set; }
}