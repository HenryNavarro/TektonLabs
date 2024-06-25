using Bogus;
using TektonLabs.Challenge.Domain.Abstractions;
using TektonLabs.Challenge.Domain.Products;
using TektonLabs.Challenge.Domain.Products.IRepository;

namespace TektonLabs.Challenge.API.Extensions;

public static class SeedDataExtensions
{
    public static async void SeedData(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var statusTypeRepository = scope.ServiceProvider.GetRequiredService<IStatusTypeRepository>();
    
        if (await statusTypeRepository.GetByIdAsync(StatusType.Inactivo.Code) is null)
        {
            var productRepository = scope.ServiceProvider.GetRequiredService<IProductRepository>();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

            statusTypeRepository.Add(StatusType.Inactivo);
            statusTypeRepository.Add(StatusType.Activo);

            var fake = new Faker();

            for (int i = 51; i <= 100; i++)
            {
                productRepository.Add(
                    Product.Create(i,
                   fake.Commerce.ProductName(),
                   fake.Commerce.ProductDescription(),
                   Price.Create(fake.Random.Int(500, 9999), fake.Random.Int(0, 100)).Value,
                   fake.Random.Int(0, 9999),
                   StatusType.Activo.Code)
                );
            }
            await unitOfWork.SaveChangesAsync();
        }
    }
}