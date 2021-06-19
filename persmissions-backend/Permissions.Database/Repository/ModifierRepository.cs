using Microsoft.EntityFrameworkCore.ChangeTracking;
using Permissions.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Permissions.Database
{
    public class ModifierRepository : IModifierRepository
    {
        readonly Context context;

        public ModifierRepository(Context context)
        {
            this.context = context;
        }

        public ValueTask<EntityEntry<TEntity>> Add<TEntity>(TEntity entity)
            where TEntity : class
        {
            return context.AddAsync(entity);
        }

        public EntityEntry<IEntity> Update(int id, IEntity entity)
        {
            entity.Id = id;

            return context.Update(entity);
        }

        public async Task<bool> Save()
        {
            var response = await context.SaveChangesAsync();

            return response > 0;
        }

        public void Remove<TEntity>(int id)
            where TEntity : class
        {
            var entity = context.Set<TEntity>().FirstOrDefault(_ => (_ as IEntity).Id == id);

            context.Remove(entity);
        }
    }
}
