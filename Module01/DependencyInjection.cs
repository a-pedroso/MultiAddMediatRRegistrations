using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Module01;

public static class DependencyInjection
{
    public static IServiceCollection AddModule01(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return services;
    }
}