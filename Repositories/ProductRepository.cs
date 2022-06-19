using AutoMapper;
using ecommerce_api.Contexts;
using ecommerce_api.Interfaces;
using ecommerce_api.Models;
using ecommerce_api.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_api.Repositories;

public class ProductRepository : IRepository<ProductDto>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ProductRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> GetAsync()
    {
        var productList = await _context.Products.ToListAsync();
        return _mapper.Map<List<ProductDto>>(productList);
    }

    
    public async Task CreateAsync(ProductDto item)
    {
        var product = _mapper.Map<Product>(item);
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(ProductDto item)
    {
        var product = _mapper.Map<Product>(item);
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(string id)
    {
        try
        {
            var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);
            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<ProductDto> GetAsync(string id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);
        return _mapper.Map<ProductDto>(product);
    }
}