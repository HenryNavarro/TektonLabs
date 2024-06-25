using System.Text.Json;
using TektonLabs.Challenge.Application.Abstractions.Discount;
using TektonLabs.Challenge.Domain.Abstractions;

namespace TektonLabs.Challenge.Infraestructure.ExternalServices;

public sealed class ProductExternalService : IProductExternalService
{
    private readonly HttpClient _httpClient;
    JsonSerializerOptions _serializerOptions;
    private readonly string _path;
    public ProductExternalService(string path)
    {
        _httpClient = new HttpClient();
        _path = path;
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

    public async Task<Result<int>> GetDiscountFromProduct(int productId)
    {
        int discount = 0;

        HttpResponseMessage response = await _httpClient.GetAsync(_path + $"/{productId}");

        if (response.IsSuccessStatusCode)
        {

            string content = await response.Content.ReadAsStringAsync();
            var product = JsonSerializer.Deserialize<ProductExternalResponse>(content, _serializerOptions);
            if (product is null)
                return Result.Failure<int>(Error.NullValue);

            discount = product.discount;
        }

        return discount;
    }
}
