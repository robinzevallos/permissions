using Permissions.Database;
using Permissions.Domain.Entities;
using Permissions.Services.Models;
using System.Linq;

namespace Permissions.Services.Queries
{
    public class PermissionTypeQuery : IQuery
    {
        readonly IQueryRepository<PermissionType> repository;

        public PermissionTypeQuery(IQueryRepository<PermissionType> repository)
        {
            this.repository = repository;
        }

        public PermissionTypeModel[] List()
        {
            return repository
                .Queryable
                .Select(_ => new PermissionTypeModel
                {
                    Id = _.Id,
                    Description = _.Description
                }).ToArray();
        }
    }
}
