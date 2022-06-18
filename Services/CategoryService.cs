using ecommerce_api.Models;
using ecommerce_api.Repositories;

namespace ecommerce_api.Services;

public class CategoryService
{
    private readonly CategoryRepository _categoryRepository;
    public CategoryService(CategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    
    public async Task<Category> GetCategoryByIdAsync(string id)
    {
        return await _categoryRepository.GetCategoryByIdAsync(id);
    }
    
    public async Task<Category> GetCategoryByNameAsync(string name)
    {
        return await _categoryRepository.GetCategoryByNameAsync(name);
    }

    public async Task<Category> PutCategoryAsync(string description, string imageUrl, string categoryName)
    {
        return await _categoryRepository.PutCategoryAsync(description, imageUrl, categoryName);
    }

    public async Task<ICollection<Category>> GetAllCategoriesAsync()
    {
        return await _categoryRepository.GetAllCategories();
    }

    public async Task<Category> UpdateCategoryAsync(string id, string description, string imageUrl, string categoryName)
    {
        return await _categoryRepository.UpdateCategoryAsync(id, description, imageUrl, categoryName);
    }
}