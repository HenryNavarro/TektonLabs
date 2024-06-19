using TektonLabs.Challenge.Domain.Products;
using TektonLabs.Challenge.Infraestructure;

namespace TektonLabs.Challenge.Application.UnitTests.Mocks;

internal sealed class MockProductRepository
{
    public static void AddDataProductRepository(ApplicationDbContext ApplicationDbContextFake)
    {
        var fixture = new Fixture();
        fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        var products = fixture.CreateMany<Product>().ToList();

        products.Add(fixture.Build<Product>()
            .With(tr => tr., "vaxidrez")
            .Create()
        );

        ApplicationDbContextFake.Products!.Add(products);
        ApplicationDbContextFake.SaveChanges();
    }
}
