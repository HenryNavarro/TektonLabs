using Bogus;
using Moq;
using TektonLabs.Challenge.Domain.Abstractions;
using TektonLabs.Challenge.Domain.Products;
using TektonLabs.Challenge.Domain.Products.IRepository;
using TektonLabs.Challenge.Infraestructure;
using TektonLabs.Challenge.Infraestructure.Repositories;

namespace TektonLabs.Challenge.Application.UnitTests.Mocks;

internal sealed class MockProductRepository
{
    public static IProductRepository GetProductRepository()
    {
        return new Mock<IProductRepository>().Object;
    }
    public static IProductRepository GetProductRepository(ApplicationDbContext applicationDbContext)
    {
        return new ProductRepository(applicationDbContext);
    }
    public static async Task AddDataProductRepository(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        var fake = new Faker();

        for (int i = 1; i <= 10; i++)
        {
            productRepository.Add(
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
        await unitOfWork.SaveChangesAsync();
    }
}
