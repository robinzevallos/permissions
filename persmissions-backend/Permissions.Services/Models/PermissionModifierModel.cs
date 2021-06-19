using System;

namespace Permissions.Services.Models
{
    public struct PermissionModifierModel
    {
        public int Id { get; set; }

        public string FirstnameEmployee { get; set; }

        public string LastnameEmployee { get; set; }

        public DateTime Date { get; set; }

        public int PermissionTypeId { get; set; }
    }
}
