using Permissions.Database;
using Permissions.Domain.Entities;
using Permissions.Services.Models;
using System.Linq;

namespace Permissions.Services.Queries
{
    public class PermissionQuery : IQuery
    {
        readonly IQueryRepository<Permission> repository;

        public PermissionQuery(IQueryRepository<Permission> repository)
        {
            this.repository = repository;
        }

        public PermissionModel[] List()
        {
            return repository
                .Queryable
                .Select(_ => new PermissionModel
                {
                    Id = _.Id,
                    FirstnameEmployee = _.FirstnameEmployee,
                    LastnameEmployee = _.LastnameEmployee,
                    Date = _.Date,
                    PermissionType = new PermissionTypeModel
                    {
                        Id = _.PermissionType.Id,
                        Description = _.PermissionType.Description
                    }
                })
                .ToArray();
        }

        public PermissionModel ById(int id)
        {
            var permission = repository
                .Include(_ => _.PermissionType)
                .SingleOrDefault(_ => _.Id == id);

            if (permission is null) return default;

            return new PermissionModel
            {
                Id = permission.Id,
                FirstnameEmployee = permission.FirstnameEmployee,
                LastnameEmployee = permission.LastnameEmployee,
                Date = permission.Date,
                PermissionType = new PermissionTypeModel
                {
                    Id = permission.PermissionType.Id,
                    Description = permission.PermissionType.Description
                }
            };
        }
    }
}
