namespace TektonLabs.Challenge.Domain.Products.IRepository;
public interface IStatusTypeReadRepository
{
    Task<StatusType?> GetByIdAsync(int code, CancellationToken cancellationToken = default);
}

