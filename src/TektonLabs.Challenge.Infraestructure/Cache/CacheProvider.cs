using LazyCache;
using TektonLabs.Challenge.Domain.Products;
using TektonLabs.Challenge.Domain.Products.IRepository;

namespace TektonLabs.Challenge.Infraestructure.Cache;
public class CacheProvider(IStatusTypeRepository statusTypeRepository, IAppCache cache): IStatusTypeReadRepository
{
    private const string MyModelCacheKey = "StatusType";

    public Task<StatusType?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        string key = MyModelCacheKey + "-" + id;

        return cache.GetOrAddAsync(key
          , async () => await statusTypeRepository.GetByIdAsync(id)
          , DateTimeOffset.Now.AddMinutes(5)); //Agregar en configuraciones
    }
}