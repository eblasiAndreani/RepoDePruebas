using Andreani.Data.CQRS.Extension;
using Ejemplo.Infrastructure.Persistence;
using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;

namespace Ejemplo.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCQRS<ApplicationDbContext>(configuration);

        services.AddScoped<ApplicationDbContext>();
        var settings = new ConnectionSettings();
        services.AddSingleton<IElasticLowLevelClient>(new ElasticLowLevelClient(settings));

        return services;
    }
}
