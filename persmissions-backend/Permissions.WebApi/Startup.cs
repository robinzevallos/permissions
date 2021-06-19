using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Permissions.Database;
using Permissions.Services;

namespace Permissions.WebApi
{
    public class Startup
    {
        readonly IConfiguration configuration;

        public static bool IsTest { get; set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            if (!IsTest)
            {
                services.AddDbContextPool<Context>(options => options
                    //.UseSqlServer(configuration.GetConnectionString("PermissionsDB"))
                    .UseInMemoryDatabase("InMemoryDb"));
            }

            services.AddCustomCors();
            services.AddControllers();
            services.AddSwagger();

            services
                .AddScoped(typeof(IModifierRepository), typeof(ModifierRepository))
                .AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>))
                .AddAssemblyScoped<IModifier>()
                .AddAssemblyScoped<IQuery>()
                ;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app
                    .UseDeveloperExceptionPage()
                    .UseCustomSwagger();
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseCustomCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
