using System;
using System.Collections.Generic;
using ecommerce_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_api.Contexts;

public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOption):base(dbContextOption)
    {
    }
}