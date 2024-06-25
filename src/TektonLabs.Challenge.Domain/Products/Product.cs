using TektonLabs.Challenge.Domain.Abstractions;
using TektonLabs.Challenge.Domain.Products.Events;

namespace TektonLabs.Challenge.Domain.Products;

public sealed class Product : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Price Price { get; private set; }
    public decimal Stock { get; private set; }
    public int Status { get; private set; }

    private Product()
    {

    }
    private Product(int id, string name, string description, Price price, decimal stock, int status) : base(id)
    {
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Status = status;
    }
    public static Product Create(int id, string name, string description, Price price, decimal stock, int status)
    {
        Product product = new Product(id, name, description, price, stock, status);
        product.RaiseDomainEvent(new ProductCreatedDomainEvent(product.Id));
        return product;
    }
    public void Update(string name, string description, Price price, decimal stock, int status)
    {
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Status = status;

        this.RaiseDomainEvent(new ProductCreatedDomainEvent(this.Id));
    }
}
