using TektonLabs.Challenge.Domain.Abstractions;

namespace TektonLabs.Challenge.Application.Abstractions.Discount;
public interface IProductExternalService
{
    Task<Result<int>> GetDiscountFromProduct(int productId);
}