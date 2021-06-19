using System;

namespace Permissions.Domain.Entities
{
    public class Permission : IEntity
    {
        public int Id { get; set; }

        public string FirstnameEmployee { get; set; }

        public string LastnameEmployee { get; set; }

        public DateTime Date { get; set; }

        public int PermissionTypeId { get; set; }
        public PermissionType PermissionType { get; set; }
    }
}
