using ProductsCatalogue.Middleware;
using ProductsCatalogue.Repositories;
using ProductsCatalogue.Services.Implementations;
using ProductsCatalogue.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IProductsRepository, ProductsRepository>();  




var app = builder.Build();

app.UseMiddleware<RequestLoggignMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
