using TektonLabs.Challenge.Domain.Products;
using TektonLabs.Challenge.Infraestructure;

namespace TektonLabs.Challenge.Application.UnitTests.Mocks;
internal sealed class MockStatusTypeRepository
{
    public static void AddDataStatusTypeRepository(ApplicationDbContext ApplicationDbContextFake)
    {
        var fixture = new Fixture();
        fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        var statusType = fixture.CreateMany<StatusType>().ToList();

        statusType.Add(fixture.Build<StatusType>()
            .With(tr => tr., "vaxidrez")
            .Create()
        );

        ApplicationDbContextFake.StatusType!.Add(statusType);
        ApplicationDbContextFake.SaveChanges();
    }
}