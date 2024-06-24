using FluentAssertions;
using Moq;
using TektonLabs.Challenge.Application.Abstractions.Discount;
using TektonLabs.Challenge.Application.Products.CreateProduct;
using TektonLabs.Challenge.Application.UnitTests.Mocks;
using TektonLabs.Challenge.Domain.Abstranctions;
using TektonLabs.Challenge.Domain.Products;
using TektonLabs.Challenge.Domain.Products.IRepository;
using Xunit;

namespace TektonLabs.Challenge.Application.UnitTests.Products.Create;
public sealed class CreteProductCommandHandlerXUnitTests
{
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly Mock<IProductRepository> _productRepository;
    private readonly Mock<IProductExternalService> _productExternalService;

    public CreteProductCommandHandlerXUnitTests()
    {
        _unitOfWork = MockUnitOfWork.GetUnitOfWork();
        _productRepository = new Mock<IProductRepository>();
        _productExternalService = new Mock<IProductExternalService>();
    }

    [Fact]
    public async Task CreateStreamerCommand_InputStreamer_ReturnsNumber()
    {
        var productInput = new CreateProductCommand
        (
            1,
            "Azufre",
            "Lorem",
            99,
            100,
            StatusType.Activo.Code
        );

        var handler = new CreateProductCommandHandler(
            _productRepository.Object,
            _unitOfWork.Object,
            _productExternalService.Object
            );

        var result = await handler.Handle(productInput, CancellationToken.None);

        result.Should().Be(result.IsSuccess);

    }
}
