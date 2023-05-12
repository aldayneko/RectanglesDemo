using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RectanglesDemo.Application.Common;

namespace RectanglesDemo.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IRectanglesStorage>(sp => new RectanglesStorage(configuration["RectanglesDBConnectionString"]));
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}