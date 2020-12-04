using KissLog;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreIdentity.Configuration
{
    public static class DependenciesInjectionConfiguration
    {
        public static IServiceCollection ResolveDependecies(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped((context) => Logger.Factory.Get());

            return services;
        }
    }
}
