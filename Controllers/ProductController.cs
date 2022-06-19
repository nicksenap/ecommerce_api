using ecommerce_api.Models;
using ecommerce_api.Models.Dto;
using ecommerce_api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace ecommerce_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController
{
    private readonly ProductService _service;

    public ProductController(ProductService service)
    {
        _service = service;
    }
    
    [HttpPost("AddProductAsync")]
    public async Task AddProductAsync(AddProductRequestModel addProductRequestModel)
    {
        await _service.CreateAsync(addProductRequestModel);
    }
    
}