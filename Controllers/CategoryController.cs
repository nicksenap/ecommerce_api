using System.Net.Mime;
using ecommerce_api.Models;
using ecommerce_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_api.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController
{
    private readonly CategoryService _service;

    public CategoryController(CategoryService categoryService)
    {
        _service = categoryService;
    }

    [HttpGet("GetCategoryByIdAsync")]
    public async Task<Category> GetCategoryByIdAsync(string id)
    {
        return await _service.GetCategoryByIdAsync(id);
    }

    [HttpGet("GetCategoryByNameAsync")]
    public async Task<Category> GetCategoryByNameAsync(string name)
    {
        return await _service.GetCategoryByNameAsync(name);
    }

    [HttpPost("PutCategoryAsync")]
    public async Task<Category> PutCategoryAsync(string description, string imageUrl, string categoryName)
    {
        return await _service.PutCategoryAsync(description, imageUrl, categoryName);
    }

    [HttpGet("GetAllCategoryAsync")]
    public async Task<ICollection<Category>> GetAllCategoryAsync()
    {
        return await _service.GetAllCategoriesAsync();
    }

    [HttpPost("PutCategoryAsync")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Category>> UpdateCategoryAsync(string id, string description, string imageUrl, string categoryName)
    {
        return new ActionResult<Category>(await _service.UpdateCategoryAsync(id, description, imageUrl, categoryName));
    }
}