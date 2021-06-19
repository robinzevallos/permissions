using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Permissions.Database
{
    internal sealed class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            return new Context(
                new DbContextOptionsBuilder<Context>()
                    //.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=PermissionsDb;")
                    .UseInMemoryDatabase("InMemoryDb")
                    .Options); ;
        }
    }
}
