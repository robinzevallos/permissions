using Microsoft.EntityFrameworkCore;
using Permissions.Domain.Entities;

namespace Permissions.Database.Seeds
{
    class PermissionTypeSeed : ISeedable
    {
        public void Seed(ModelBuilder builder)
        {
            builder.Entity<PermissionType>(entity =>
            {
                entity.HasData(
                    new PermissionType
                    {
                        Id = 1,
                        Description = "Enfermedad",
                    },
                    new PermissionType
                    {
                        Id = 2,
                        Description = "Diligencias",
                    },
                    new PermissionType
                    {
                        Id = 3,
                        Description = "Otros",
                    }
                );
            });
        }
    }
}
