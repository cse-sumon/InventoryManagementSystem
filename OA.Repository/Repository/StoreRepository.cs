using Microsoft.EntityFrameworkCore;
using OA.Data;
using OA.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OA.Repository.Repository
{
    public class StoreRepository<T> : IStoreRepository<T> where T : Store
    {
        private readonly ApplicationContext context;
        private DbSet<T> entities;
        public StoreRepository(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.Where(e => e.IsDeleted == false).AsEnumerable();
        }

        public T Get(int id)
        {
            return entities.SingleOrDefault(e => e.Id == id && e.IsDeleted == false);
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
            context.Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        
    }
}
