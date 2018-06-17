using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ClickCounterApp.Business.UnitOfWork
{
    public interface IGenericRequest<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        IEnumerable<TEntity> Query(string query);
        TEntity GetById(object id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(object id);
        int GetEntryCount();

    }
}
