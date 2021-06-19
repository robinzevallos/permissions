using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Permissions.Database
{
    public class QueryRepository<T> : IQueryRepository<T> where T : class
    {
        private readonly Context context;

        public IQueryable<T> Queryable { get; }

        public QueryRepository(Context context)
        {
            this.context = context;

            Queryable = context.Set<T>();
        }

        public IIncludableQueryable<T, object> Include(Expression<Func<T, object>> navigationProperty)
            => context.Set<T>().Include(navigationProperty);
    }
}
