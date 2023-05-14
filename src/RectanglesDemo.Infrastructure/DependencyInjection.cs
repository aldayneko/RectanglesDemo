using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RectanglesDemo.Application.Common;
using System.Data;

namespace RectanglesDemo.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDbConnection>(db => new SqlConnection(configuration["RectanglesDBConnectionString"]));
        services.AddScoped<IRectanglesStorage, RectanglesStorage>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}