using System.Collections.Generic;

namespace ClickCounterApp.Data.UnitOfWork
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

            public IEnumerable<TEntity> Get()
            {
                return new Transactions.Request<TEntity>().Get();
            }
        }
    }
}
