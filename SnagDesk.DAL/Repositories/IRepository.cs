using System;
using System.Linq;
using System.Linq.Expressions;

namespace SnagDesk.DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> All { get; }
        TEntity Find(Expression<Func<TEntity, bool>> uniqueFilterExpression);
        (bool IsSuccessfull, string Error) Add(params TEntity[] entities);
        (bool IsSuccessfull, string Error) Update(params TEntity[] entities);
        (bool IsSuccessfull, string Error) Delete(params TEntity[] entities);
    }

    public interface IRepository<TEntity, in TKey> : IRepository<TEntity> where TEntity : class
    {
        TEntity Get(TKey identifier);
        (bool IsSuccessfull, string Error) Delete(params TKey[] keys);
    }
}
