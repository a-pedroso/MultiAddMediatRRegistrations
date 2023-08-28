using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Module02;

public static class DependencyInjection
{
    public static IServiceCollection AddModule02(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return services;
    }
}