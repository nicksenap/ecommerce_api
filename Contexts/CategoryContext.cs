using System;
using System.Collections.Generic;
using ecommerce_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_api.Contexts;

public class CategoryContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    
    public CategoryContext(DbContextOptions<CategoryContext> dbContextOption):base(dbContextOption)
    {
    }
}