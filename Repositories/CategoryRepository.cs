using ecommerce_api.Contexts;
using ecommerce_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_api.Repositories;

public class CategoryRepository
{
    private readonly CategoryContext _context;
    public CategoryRepository(CategoryContext context)
    {
        _context = context;
    }

    public async Task<Category> GetCategoryByIdAsync(string id)
    {
        return await _context.Categories.FirstOrDefaultAsync(category => category.Id == id) ?? throw new InvalidOperationException();
    }

    public async Task<Category> PutCategoryAsync(string description, string imageUrl, string categoryName)
    {
        var category = new Category(description, imageUrl, categoryName);
        var result = await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        
        return result.Entity;
    }

    public async Task<Category> GetCategoryByNameAsync(string name)
    {
        return await _context.Categories.FirstOrDefaultAsync(category => category.CategoryName == name) ?? throw new InvalidOperationException();
    }

    public async Task<ICollection<Category>> GetAllCategories()
    {
        return await _context.Categories.ToArrayAsync();
    }

    public async Task<Category> UpdateCategoryAsync(string id, string description, string imageUrl, string categoryName)
    {
        var category = await GetCategoryByIdAsync(id);
        category.Description = description;
        category.CategoryName = categoryName;
        category.ImageUrl = imageUrl;
        _context.Update(category);
        await _context.SaveChangesAsync();

        return category;
    }
}