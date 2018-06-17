using System.Collections.Generic;

namespace ClickCounterApp.Data.UnitOfWork
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
        public virtual IEnumerable<TEntity> Get()
        {
            return genericRequest.Get();
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
