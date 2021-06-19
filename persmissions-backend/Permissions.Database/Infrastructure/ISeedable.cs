using Microsoft.EntityFrameworkCore;

namespace Permissions.Database
{
    internal interface ISeedable
    {
        void Seed(ModelBuilder builder);
    }
}
