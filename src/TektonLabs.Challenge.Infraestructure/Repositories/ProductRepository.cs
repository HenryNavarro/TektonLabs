﻿using TektonLabs.Challenge.Domain.Products;
using TektonLabs.Challenge.Domain.Products.IRepository;

namespace TektonLabs.Challenge.Infraestructure.Repositories;
public sealed class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}