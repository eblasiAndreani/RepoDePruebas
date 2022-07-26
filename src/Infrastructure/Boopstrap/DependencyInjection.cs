using Andreani.Data.CQRS.Extension;
using CrudTest.Application.Common.Interfaces;
using CrudTest.Infrastructure.Persistence;
using CrudTest.Infrastructure.Services.CuadroFutbolService.Commands;
using CrudTest.Infrastructure.Services.CuadroFutbolService.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace CrudTest.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCQRS<ApplicationDbContext>(configuration);

        services.AddScoped<ApplicationDbContext>();
        services.AddTransient<ICuadroFutbolServiceCommands, CuadroFutbolServiceCommands>();
        services.AddTransient<ICuadroFutbolServiceQueries, CuadroFutbolServiceQueries>();

        return services;
    }
}
