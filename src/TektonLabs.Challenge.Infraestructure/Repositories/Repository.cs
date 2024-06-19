using Microsoft.EntityFrameworkCore;
using TektonLabs.Challenge.Domain.Abstranctions;

namespace TektonLabs.Challenge.Infraestructure.Repositories;

internal abstract class Repository<T> where T : Entity
{
    protected readonly ApplicationDbContext DbContext;

    protected Repository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }
    public async Task<IReadOnlyList<T>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<T>().ToListAsync(cancellationToken);
    }
    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<T>()
        .FirstOrDefaultAsync(obj => obj.Id == id, cancellationToken);
    }

    public void Add(T entity)
    {
        DbContext.Add(entity);
    }
    public void Update(T entity)
    {
        DbContext.Update(entity);
    }
}
