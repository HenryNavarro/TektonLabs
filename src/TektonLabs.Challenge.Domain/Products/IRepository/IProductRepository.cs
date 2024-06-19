namespace TektonLabs.Challenge.Domain.Products.IRepository;
public interface IProductRepository
{
    Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Product>?> GetAllAsync(CancellationToken cancellationToken = default);
    void Add(Product product);
    void Update(Product product);
}

