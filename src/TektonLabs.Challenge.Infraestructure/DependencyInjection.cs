using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TektonLabs.Challenge.Application.Abstractions.Discount;
using TektonLabs.Challenge.Application.Abstractions.Email;
using TektonLabs.Challenge.Domain.Abstranctions;
using TektonLabs.Challenge.Domain.Products.IRepository;
using TektonLabs.Challenge.Infraestructure.Cache;
using TektonLabs.Challenge.Infraestructure.Email;
using TektonLabs.Challenge.Infraestructure.ExternalServices;
using TektonLabs.Challenge.Infraestructure.Repositories;

namespace TektonLabs.Challenge.Infraestructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
        )
    {
        services.AddTransient<IEmailService, EmailService>();

        var connectionString = configuration.GetConnectionString("Database")
             ?? throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(
            options =>
                options.UseSqlite(connectionString)
        );

        var pathProductService = configuration.GetValue<string>("ExternalAPIs:Products")
            ?? throw new ArgumentNullException(nameof(configuration));

        services.AddTransient<IProductExternalService>(_ => new ProductExternalService(pathProductService));

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IStatusTypeRepository, StatusTypeRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddLazyCache();
        services.AddTransient<IStatusTypeReadRepository, CacheProvider>();

        return services;
    }

}