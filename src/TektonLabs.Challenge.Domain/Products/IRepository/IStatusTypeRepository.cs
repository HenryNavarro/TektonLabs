namespace TektonLabs.Challenge.Domain.Products.IRepository;
public interface IStatusTypeRepository
{
    Task<StatusType?> GetByIdAsync(int code,CancellationToken cancellationToken = default);
    void Add(StatusType statusType);
}

