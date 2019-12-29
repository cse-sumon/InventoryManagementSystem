using Microsoft.EntityFrameworkCore;
using OA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OA.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext context;
        private DbSet<T> entities;
        public Repository(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GellAll( int storeId)
        {
            return entities.Where(e=>e.IsDeleted==false && e.StoreId== storeId).AsEnumerable();
        }

        public T Get(int id, int storeId)
        {
            return entities.SingleOrDefault(e => e.Id == id && e.IsDeleted == false && e.StoreId == storeId);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Update(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Remove(entity);
            context.SaveChanges();
        }


        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

      
    }
}
