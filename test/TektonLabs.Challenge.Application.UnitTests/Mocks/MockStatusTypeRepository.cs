using TektonLabs.Challenge.Domain.Products;
using TektonLabs.Challenge.Infraestructure;

namespace TektonLabs.Challenge.Application.UnitTests.Mocks;
internal sealed class MockStatusTypeRepository
{
    public static void AddDataStatusTypeRepository(ApplicationDbContext ApplicationDbContextFake)
    {
        var statustype = new List<StatusType>();

        statustype.Add(StatusType.Inactivo);
        statustype.Add(StatusType.Activo);

        ApplicationDbContextFake.Set<StatusType>().AddRange(statustype);
        ApplicationDbContextFake.SaveChanges();
    }
}