using ProductsCatalogue.Models;
using ProductsCatalogue.Repositories;

public class FakeRepo : IProductsRepository     
{
    public List<Product> products = new List<Product>();

    public Task<List<Product>> GetAllAsync(CancellationToken ct)
    {
        return Task.FromResult(products);
    }
}