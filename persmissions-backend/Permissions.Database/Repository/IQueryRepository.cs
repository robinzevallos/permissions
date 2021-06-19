using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Permissions.Database
{
    public interface IQueryRepository<T>
    {
        IQueryable<T> Queryable { get; }

        IIncludableQueryable<T, object> Include(Expression<Func<T, object>> navigationProperty);
    }
}
