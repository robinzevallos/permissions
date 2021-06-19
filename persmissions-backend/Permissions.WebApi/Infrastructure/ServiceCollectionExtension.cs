using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Permissions.WebApi
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddAssemblyScoped<T>(this IServiceCollection service)
        {
            var assembly = typeof(T).Assembly;

            foreach (var item in assembly.GetTypes())
            {
                var isTarget = item
                    .GetInterfaces()
                    .SingleOrDefault(_ => _ == typeof(T)) != null;

                if (isTarget)
                {
                    service.AddScoped(item);
                }
            }

            return service;
        }
    }
}
