using KissLog.AspNetCore;
using AspNetCoreIdentity.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetCoreIdentity
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment hostEnvironment)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables()

                .AddUserSecrets<Startup>().Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ResolveIdentityConfigure(Configuration);
            services.AddControllersWithViews();

            services.ResolveDependecies();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/erro");
                app.UseStatusCodePagesWithRedirects("/erro/{0}");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            
            // app.UseKissLogMiddleware() must to be referenced after app.UseAuthentication(), app.UseSession()
            app.UseKissLogMiddleware(options => {
                LogConfiguration.ConfigureKissLog(options, Configuration);
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default", "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
