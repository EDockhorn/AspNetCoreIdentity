using AspNetCoreIdentity.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreIdentity.Configuration
{
    public static class IdentityConfiguration
    {
        public static IServiceCollection ResolveIdentityConfigure (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AspNetCoreIdentityContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("AspNetCoreIdentityContextConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AspNetCoreIdentityContext>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("PodeTestar", policy => policy.RequireClaim("PodeTestar"));
                options.AddPolicy("PodeAcessar", policy => policy.RequireClaim("PodeAcessar"));
            });

            return services;
        }
    }
}
