using Andreani.Data.CQRS.Extension;
using CrudTest.Application.Common.Interfaces;
using CrudTest.Application.Common.Interfaces.IAutenticacion;
using CrudTest.Infrastructure.Persistence;
using CrudTest.Infrastructure.Services.Autenticacion;
using CrudTest.Infrastructure.Services.CuadroFutbolService.Commands;
using CrudTest.Infrastructure.Services.CuadroFutbolService.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CrudTest.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCQRS<ApplicationDbContext>(configuration);

        services.AddScoped<ApplicationDbContext>();
        services.AddTransient<ICuadroFutbolServiceCommands, CuadroFutbolServiceCommands>();
        services.AddTransient<ICuadroFutbolServiceQueries, CuadroFutbolServiceQueries>();
        services.AddTransient<ILoginService, LoginService>();

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("Authentication:Secret").Value)),
                    ValidateIssuer = false,
                    ValidateLifetime = true,
                    ValidateAudience = false
                };
            });
        return services;
    }
}
