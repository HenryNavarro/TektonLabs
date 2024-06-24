using Bogus;
using TektonLabs.Challenge.Domain.Products;
using TektonLabs.Challenge.Infraestructure;

namespace TektonLabs.Challenge.Application.UnitTests.Mocks;

internal sealed class MockProductRepository
{
    public static void AddDataProductRepository(ApplicationDbContext ApplicationDbContextFake)
    {
        var products = new List<Product>();

        var fake = new Faker();

        for (int i = 1; i <= 10; i++)
        {
            products.Add(
                Product.Create(
                    i,
                    fake.Commerce.ProductName(),
                    fake.Commerce.ProductDescription(),
                    Price.Create(fake.Random.Int(500, 9999), fake.Random.Int(0, 100)).Value,
                    fake.Random.Int(0, 9999),
                    StatusType.Create(fake.Random.Int(0, 1)).Value.Code
                )
            );
        }

        ApplicationDbContextFake.Set<Product>().AddRange(products);
        ApplicationDbContextFake.SaveChanges();
    }
}
