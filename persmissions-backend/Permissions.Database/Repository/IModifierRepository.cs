using Microsoft.EntityFrameworkCore.ChangeTracking;
using Permissions.Domain;
using System.Threading.Tasks;

namespace Permissions.Database
{
    public interface IModifierRepository
    {
        ValueTask<EntityEntry<TEntity>> Add<TEntity>(TEntity entity)
            where TEntity : class;

        EntityEntry<IEntity> Update(int id, IEntity entity);

        void Remove<TEntity>(int id)
            where TEntity : class;

        Task<bool> Save();
    }
}
