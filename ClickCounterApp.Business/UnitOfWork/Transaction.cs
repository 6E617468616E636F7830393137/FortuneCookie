using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ClickCounterApp.Business.UnitOfWork
{
    public class Transaction<TEntity> where TEntity : class
    {
        public class ExecuteDb : IGenericRequest<TEntity> 
        {
            public TEntity GetById(object id)
            {
                return new Transactions.Request<TEntity>().GetById(id);
            }
            public void Insert(TEntity entity)
            {
                new Transactions.Request<TEntity>().Insert(entity);
            }

            public void Update(TEntity entity)
            {
                new Transactions.Request<TEntity>().Update(entity);
            }
            public void Delete(object id)
            {
                new Transactions.Request<TEntity>().Delete(id);
            }

            public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
            {
                return new Transactions.Request<TEntity>().Get(filter = null,
             orderBy = null,
            includeProperties = "");
            }

            public int GetEntryCount()
            {
                return new Transactions.Request<TEntity>().GetEntryCount();
            }

            public IEnumerable<TEntity> Query(string query)
            {
                return new Transactions.Request<TEntity>().Query(query);
            }
        }
    }
}
