using System.Collections.Generic;

namespace ClickCounterApp.Data.UnitOfWork
{
    public interface IGenericRequest<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        TEntity GetById(object id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(object id);

    }
}
