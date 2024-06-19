namespace TektonLabs.Challenge.Domain.Abstranctions;
public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
