using AutoMapper;
using ecommerce_api.Models;
using ecommerce_api.Models.Dto;

namespace ecommerce_api;


public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<Product, ProductDto>().ReverseMap();
            config.CreateMap<Category, CategoryDto>().ReverseMap();
        });

        return mappingConfig;
    }
}