using ProductsCatalogue.Models;
using ProductsCatalogue.Services.Implementations;
using Xunit;

public class ProductServiceTests
{
    //test 1: we put 2 products in the fake, so service give back list of 2
    [Fact]
    public async Task GetAll_ReturnsTwoProducts()
    {
        var repo = new FakeRepo();
        repo.products.Add(new Product { Id = 1, Name = "Pen" });
        repo.products.Add(new Product { Id = 2, Name = "Book" });
        var service = new ProductService(repo);

        var result = await service.GetAllAsync(CancellationToken.None);

        Assert.Equal(2, result.Count);
    }
    //test 2: checks data inside the product wasnt changed
    //id,name,price all match what we put in
    [Fact]
    public async Task GetAll_ReturnsCorrectProductData()
    {
        var repo = new FakeRepo();
        repo.products.Add(new Product { Id = 1, Name = "Pen", price = 5 });
        var service = new ProductService(repo);

        var result = await service.GetAllAsync(CancellationToken.None);

        Assert.Equal(1, result[0].Id);
        Assert.Equal("Pen", result[0].Name);
        Assert.Equal(5, result[0].price);
    }
    //test 3: negative scenario, fake has no products
    //service returns empty list
    [Fact]
    public async Task GetAll_NothingFound_ReturnsEmptyList()
    {
        var repo = new FakeRepo();
        var service = new ProductService(repo);

        var result = await service.GetAllAsync(CancellationToken.None);

        Assert.Empty(result);
    }
}