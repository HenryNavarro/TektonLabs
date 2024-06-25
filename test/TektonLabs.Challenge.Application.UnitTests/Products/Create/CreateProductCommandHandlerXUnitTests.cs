using Bogus;
using FluentAssertions;
using TektonLabs.Challenge.Application.Abstractions.Discount;
using TektonLabs.Challenge.Application.Products.CreateProduct;
using TektonLabs.Challenge.Application.UnitTests.Mocks;
using TektonLabs.Challenge.Domain.Abstractions;
using TektonLabs.Challenge.Domain.Products;
using TektonLabs.Challenge.Domain.Products.IRepository;
using Xunit;

namespace TektonLabs.Challenge.Application.UnitTests.Products.Create;
public sealed class CreateProductCommandHandlerXUnitTests
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductRepository _productRepository;
    private readonly IProductExternalService _productExternalService;
    private readonly Faker _faker;

    public CreateProductCommandHandlerXUnitTests()
    {
        _unitOfWork = MockUnitOfWork.GetUnitOfWork();
        _productRepository = MockProductRepository.GetProductRepository();
        _productExternalService = MockProductExternalService.GetProductExternalService();
        _faker = new Faker();
    }

    [Fact]
    public async Task CreateProductCommand_InputProduct_ReturnsSuccess()
    {
        var productInput = new CreateProductCommand
        (
            51, //
           _faker.Commerce.ProductName(),
           _faker.Commerce.ProductDescription(),
           _faker.Random.Int(500, 9999),
            _faker.Random.Int(0, 9999),
            StatusType.Activo.Code
        );
    
        var handler = new CreateProductCommandHandler(
            _productRepository,
            _unitOfWork,
            _productExternalService
            );

        var result = await handler.Handle(productInput, CancellationToken.None);

        result.IsSuccess.Should().BeTrue();

    }
}
