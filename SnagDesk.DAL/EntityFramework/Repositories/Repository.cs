using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SnagDesk.DAL.Repositories;

namespace SnagDesk.DAL.EntityFramework.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>, IDisposable where TEntity : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(DbContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public IQueryable<TEntity> All => DbSet;

        public TEntity Find(Expression<Func<TEntity, bool>> uniqueFilterExpression)
        {
            throw new NotImplementedException();
        }

        public (bool IsSuccessfull, string Error) Add(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public (bool IsSuccessfull, string Error) Update(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public (bool IsSuccessfull, string Error) Delete(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(TKey identifier)
        {
            throw new NotImplementedException();
        }

        public (bool IsSuccessfull, string Error) Delete(params TKey[] keys)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}