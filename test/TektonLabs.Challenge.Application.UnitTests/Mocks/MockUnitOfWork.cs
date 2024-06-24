using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using TektonLabs.Challenge.Domain.Abstranctions;
using TektonLabs.Challenge.Infraestructure;

namespace TektonLabs.Challenge.Application.UnitTests.Mocks;
internal static class MockUnitOfWork
{
    public static Mock<IUnitOfWork> GetUnitOfWork()
    {
        Guid dbContextId = Guid.NewGuid();
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: $"ApplicationDbContext-{dbContextId}")
            .Options;

        Mock<IPublisher> publisher = new Mock<IPublisher>();
        var ApplicationDbContextFake = new ApplicationDbContext(options, publisher.Object);
        ApplicationDbContextFake.Database.EnsureDeleted();
        var mockUnitOfWork = new Mock<IUnitOfWork>(ApplicationDbContextFake);

        return mockUnitOfWork;
    }

}
