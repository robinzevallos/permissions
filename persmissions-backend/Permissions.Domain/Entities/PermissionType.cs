namespace Permissions.Domain.Entities
{
    public class PermissionType : IEntity
    {
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
