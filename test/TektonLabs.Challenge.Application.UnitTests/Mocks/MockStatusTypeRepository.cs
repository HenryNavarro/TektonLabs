using LazyCache;
using Moq;
using TektonLabs.Challenge.Domain.Abstractions;
using TektonLabs.Challenge.Domain.Products;
using TektonLabs.Challenge.Domain.Products.IRepository;
using TektonLabs.Challenge.Infraestructure.Cache;

namespace TektonLabs.Challenge.Application.UnitTests.Mocks;
internal sealed class MockStatusTypeRepository
{
    public static IStatusTypeRepository GetStatusTypeRepository()
    {
        return new Mock<IStatusTypeRepository>().Object;
    }
    public static IStatusTypeReadRepository GetStatusTypeReadRepository(IStatusTypeRepository statusTypeRepository)
    {
        var appCache = new Mock<IAppCache>().Object;
        return new CacheProvider(statusTypeRepository, appCache);
    }
    public static async Task AddDataStatusTypeRepository(IStatusTypeRepository statusTypeRepository, IUnitOfWork unitOfWork)
    {
        statusTypeRepository.Add(StatusType.Inactivo);
        statusTypeRepository.Add(StatusType.Activo);

        await unitOfWork.SaveChangesAsync();
    }

}