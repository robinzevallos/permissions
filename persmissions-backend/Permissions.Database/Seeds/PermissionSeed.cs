using Microsoft.EntityFrameworkCore;
using Permissions.Domain.Entities;
using System;

namespace Permissions.Database.Seeds
{
    class PermissionSeed : ISeedable
    {
        public void Seed(ModelBuilder builder)
        {
            builder.Entity<Permission>(entity =>
            {
                entity.HasData(
                    new Permission
                    {
                        Id = 1,
                        FirstnameEmployee = "Carlos",
                        LastnameEmployee = "Mock",
                        Date = new DateTime(2021, 06, 15),
                        PermissionTypeId = 1
                    },
                    new Permission
                    {
                        Id = 2,
                        FirstnameEmployee = "Rosa",
                        LastnameEmployee = "Mock",
                        Date = new DateTime(2021, 06, 16),
                        PermissionTypeId = 2
                    }
                );
            });
        }
    }
}
