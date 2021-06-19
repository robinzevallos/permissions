using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Permissions.Database;
using Permissions.WebApi;
using System.Net.Http;

namespace Permissions.Test
{
    public class ApiTestFixture : WebApplicationFactory<Startup>
    {
        public static HttpClient HttpClient { get; private set; }

        public ApiTestFixture()
        {
            Startup.IsTest = true;

            HttpClient = CreateClient();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing");

            builder.ConfigureServices(services =>
            {
                services.AddDbContextPool<Context>(options =>
                {
                    var context = new Context(
                        new DbContextOptionsBuilder<Context>()
                            .UseInMemoryDatabase("InMemoryDb")
                            .Options);

                    context.Database.EnsureCreated();

                    options.UseInMemoryDatabase("InMemoryDb");
                });
            });
        }
    }
}
