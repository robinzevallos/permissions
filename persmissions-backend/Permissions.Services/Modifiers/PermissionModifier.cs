using Permissions.Database;
using Permissions.Domain.Entities;
using Permissions.Services.Models;
using System.Threading.Tasks;

namespace Permissions.Services.Modifiers
{
    public class PermissionModifier : IModifier
    {
        readonly IModifierRepository repository;

        public PermissionModifier(IModifierRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> Create(PermissionModifierModel model)
        {
            var permission = new Permission()
            {
                FirstnameEmployee = model.FirstnameEmployee,
                LastnameEmployee = model.LastnameEmployee,
                Date = model.Date,
                PermissionTypeId = model.PermissionTypeId
            };

            await repository.Add(permission);

            return await repository.Save();
        }

        public async Task<bool> Update(PermissionModifierModel model)
        {
            var permission = new Permission()
            {
                FirstnameEmployee = model.FirstnameEmployee,
                LastnameEmployee = model.LastnameEmployee,
                Date = model.Date,
                PermissionTypeId = model.PermissionTypeId
            };

            repository.Update(model.Id, permission);

            return await repository.Save();
        }

        public async Task<bool> Remove(int id)
        {
            repository.Remove<Permission>(id);

            return await repository.Save();
        }
    }
}
