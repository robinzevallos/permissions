using System;

namespace Permissions.Services.Models
{
    public struct PermissionModel
    {
        public int Id { get; set; }

        public string FirstnameEmployee { get; set; }

        public string LastnameEmployee { get; set; }

        public DateTime Date { get; set; }

        public PermissionTypeModel PermissionType { get; set; }
    }
}
