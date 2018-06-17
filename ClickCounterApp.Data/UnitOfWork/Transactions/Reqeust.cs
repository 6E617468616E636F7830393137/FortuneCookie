using ClickCounterApp.Entities.Fortune;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ClickCounterApp.Data.UnitOfWork.Transactions
{
    internal class Request<TEntity> where TEntity : class
    {
        internal FortuneEntities context;
        internal DbSet<TEntity> dbSet;

        public Request() 
        {
            context = new FortuneEntities();
            dbSet = context.Set<TEntity>();
        }
        internal virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        internal TEntity GetById(object id)
        {
            
            
            return dbSet.Find(id);
        }
        public virtual void Insert(TEntity entity)
        {
            
            dbSet.Add(entity);
            context.SaveChanges();
        }
        public virtual void Update(TEntity entity)
        {
            try
            {
                
                dbSet.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
        public virtual void Delete(TEntity entity)
        {
            try
            {
                //context = new UnitOfWorkDevelopmentEntities();
                //dbSet = context.Set<TEntity>();                
                if (context.Entry(entity).State == EntityState.Detached)
                {
                    dbSet.Attach(entity);
                }
                dbSet.Remove(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
        public virtual void Delete(object id)
        {
            try
            {
                
                TEntity entityToDelete = dbSet.Find(id);
                Delete(entityToDelete);

            }
            catch (Exception ex)
            {

            }
        }

    }
}
