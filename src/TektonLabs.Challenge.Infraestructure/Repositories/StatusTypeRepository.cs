using Microsoft.EntityFrameworkCore;
using TektonLabs.Challenge.Domain.Products;
using TektonLabs.Challenge.Domain.Products.IRepository;

namespace TektonLabs.Challenge.Infraestructure.Repositories;
internal sealed class StatusTypeRepository : IStatusTypeRepository
{
    protected readonly ApplicationDbContext DbContext;

    public StatusTypeRepository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }
    public void Add(StatusType statusType)
    {
        DbContext.Add(statusType);
    }

    public async Task<StatusType?> GetByIdAsync(int code, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<StatusType>().FirstOrDefaultAsync(s => s.Code == code, cancellationToken);
    }
}