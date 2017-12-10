using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CrawlerDataAccess.Database.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal CrawlerDBContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(CrawlerDBContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();

        }

        public virtual IEnumerable<TEntity> Get(
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

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity, bool commit = false)
        {
            dbSet.Add(entity);
            if (commit)
                context.SaveChanges();
        }

        public virtual void Delete(object id, bool commit = false)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete, commit);
        }

        public virtual void Delete(TEntity entityToDelete, bool commit = false)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            if (commit)
                context.SaveChanges();
        }

        public virtual void Update(TEntity entityToUpdate, object Id, bool commit = false)
        {
            var entry = context.Entry<TEntity>(entityToUpdate);

            if (entry.State == EntityState.Detached)
            {
                var set = context.Set<TEntity>();
                TEntity attachedEntity = set.Find(Id);  // You need to have access to key

                if (attachedEntity != null)
                {
                    var attachedEntry = context.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entityToUpdate);
                }
                else
                {
                    entry.State = EntityState.Modified; // This should attach entity
                }
            }
            if (commit)
                context.SaveChanges();
        }


        public List<TEntity> GetAllEntities()
        {
            return dbSet.ToList();
        }
    }
}
