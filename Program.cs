using AutoMapper;
using ecommerce_api;
using ecommerce_api.Contexts;
using ecommerce_api.Repositories;
using ecommerce_api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var mapper = MappingConfig.RegisterMaps().CreateMapper();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddTransient<CategoryService>();
builder.Services.AddTransient<CategoryRepository>();
builder.Services.AddTransient<ProductService>();
builder.Services.AddTransient<ProductRepository>();
builder.Services.AddSingleton(mapper);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Ecommerce");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.Run();
