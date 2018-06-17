using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ClickCounterApp.Business.UnitOfWork
{
    public class GenericRequest<TEntity> where TEntity : class
    {
        // Initialize variables
        private readonly IGenericRequest<TEntity> genericRequest;
        // Constructor
        public GenericRequest(IGenericRequest<TEntity> concreteImplementation)
        {
            genericRequest = concreteImplementation;
        }
        // Implementation
        public int GetEntryCount()
        {
            return genericRequest.GetEntryCount();
        }
        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            return genericRequest.Get(filter = null,
             orderBy = null,
            includeProperties = "");
        }
        public virtual IEnumerable<TEntity> Query(string query)
        {
            return genericRequest.Query(query);
        }
        public virtual TEntity GetById(object id)
        {
            return genericRequest.GetById(id);
        }
        public virtual void Insert(TEntity entity)
        {
            genericRequest.Insert(entity);
        }
        public virtual void Update(TEntity entity)
        {
            genericRequest.Update(entity);
        }
        public virtual void Delete(object id)
        {
            genericRequest.Delete(id);
        }
    }
}
