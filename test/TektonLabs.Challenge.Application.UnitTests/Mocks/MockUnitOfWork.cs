using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using TektonLabs.Challenge.Domain.Abstractions;
using TektonLabs.Challenge.Infraestructure;

namespace TektonLabs.Challenge.Application.UnitTests.Mocks;
internal static class MockUnitOfWork
{
    public static IUnitOfWork GetUnitOfWork()
    {
        Guid dbContextId = Guid.NewGuid();
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: $"ApplicationDbContext-{dbContextId}")
            .Options;

        var publisher = new Mock<IPublisher>();
        var applicationDbContextFake = new ApplicationDbContext(options, publisher.Object);
        //ApplicationDbContextFake.Database.EnsureDeleted();
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        return mockUnitOfWork.Object;
    }

}
