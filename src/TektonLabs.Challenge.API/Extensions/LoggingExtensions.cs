using Serilog;

namespace TektonLabs.Challenge.API.Extensions;
public static class LoggingExtensions
{
    public static void UseLogging(this IHostBuilder builder,IConfiguration configuration)
    {
             builder.UseSerilog((_, config) => config.ReadFrom.Configuration(configuration));
    }
}