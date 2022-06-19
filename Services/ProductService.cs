using ecommerce_api.Interfaces;
using ecommerce_api.Models;
using ecommerce_api.Models.Dto;
using ecommerce_api.Repositories;

namespace ecommerce_api.Services;

public class ProductService : IService<ProductDto>
{
    private readonly ProductRepository _repository;
    private readonly CategoryRepository _categoryRepository;

    public ProductService(ProductRepository repository, CategoryRepository categoryRepository)
    {
        _repository = repository;
        _categoryRepository = categoryRepository;
    }
    
    public async Task<ProductDto> GetByIdAsync(string id)
    {
        return await _repository.GetAsync(id);
    }

    public async Task UpdateAsync(ProductDto item)
    {
        await _repository.UpdateAsync(item);
    }

    public Task CreateAsync(ProductDto item)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        return await _repository.GetAsync();
    }
    
    public async Task CreateAsync(AddProductRequestModel item)
    {
        var dto = await TransferAddProductRequestModel(item);
        await _repository.CreateAsync(dto);
    }

    private async Task<ProductDto> TransferAddProductRequestModel(AddProductRequestModel model)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(model.CategoryId);
        var productDto = new ProductDto(model.Name, model.ImageUrl, model.Price, model.Description, category);

        return productDto;
    }

}