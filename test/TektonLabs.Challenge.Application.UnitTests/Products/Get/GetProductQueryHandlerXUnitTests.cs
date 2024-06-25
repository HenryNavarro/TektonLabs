using FluentAssertions;
using Moq;
using TektonLabs.Challenge.Application.Products.Get;
using TektonLabs.Challenge.Application.UnitTests.Mocks;
using TektonLabs.Challenge.Domain.Abstractions;
using TektonLabs.Challenge.Domain.Products.IRepository;
using Xunit;

namespace TektonLabs.Challenge.Application.UnitTests.Products.Get;

public class GetProductQueryHandlerXUnitTests
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductRepository _productRepository;
    private readonly IStatusTypeReadRepository _statusTypeReadRepository;
    public GetProductQueryHandlerXUnitTests()
    {

        _unitOfWork = MockUnitOfWork.GetUnitOfWork();
        _productRepository = MockProductRepository.GetProductRepository();
        var statusTypeRepository = new Mock<IStatusTypeRepository>().Object;
        _statusTypeReadRepository = MockStatusTypeRepository.GetStatusTypeReadRepository(statusTypeRepository);
    }

    [Fact]
    public async Task GetProductQuery_ProductId_ReturnProduct()
    {
        await MockProductRepository.AddDataProductRepository(_productRepository, _unitOfWork);

        var handler = new GetProductQueryHandler(_productRepository, _statusTypeReadRepository);

        var query = new GetProductQuery(1);

        var result = await handler.Handle(query, CancellationToken.None);

        result.Value.Should().BeNull();
    }
}
