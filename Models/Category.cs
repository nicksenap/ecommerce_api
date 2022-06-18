using System.ComponentModel.DataAnnotations;
using static System.Guid;

namespace ecommerce_api.Models;

public class Category
{
    public Category(string description, string imageUrl, string categoryName)
    {
        Description = description;
        ImageUrl = imageUrl;
        Id = NewGuid().ToString();
        CategoryName = categoryName;
    }
    
    [Key]
    public string Id { get; set; }
    [Required]
    public string CategoryName { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string ImageUrl { get; set; }
}