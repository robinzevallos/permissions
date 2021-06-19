using Microsoft.EntityFrameworkCore;

namespace Permissions.Database
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .ApplyConfigurationsFromAssembly(typeof(Context).Assembly)
                .SeedBuild();
        }
    }
}
