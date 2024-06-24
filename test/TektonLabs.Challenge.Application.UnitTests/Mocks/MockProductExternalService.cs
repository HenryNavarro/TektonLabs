using TektonLabs.Challenge.Application.Abstractions.Discount;
using TektonLabs.Challenge.Infraestructure.ExternalServices;

namespace TektonLabs.Challenge.Application.UnitTests.Mocks;
internal static class MockProductExternalService
{
    public static IProductExternalService GetProductExternalService()
    {

        var productExternalService = new ProductExternalService("https://666a41df7013419182cea9d9.mockapi.io/api/v1/products");

        return productExternalService;
    }

}
