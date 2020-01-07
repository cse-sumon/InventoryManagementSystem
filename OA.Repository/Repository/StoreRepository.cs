using Microsoft.EntityFrameworkCore;
using OA.Data;
using OA.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OA.Repository.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private readonly ApplicationContext context;
        private DbSet<Store> entities;
        public StoreRepository(ApplicationContext context)
        {
            this.context = context;

            entities = context.Set<Store>();
        }

        public IEnumerable<Store> GetAll()
        {
            return entities.Where(e => e.IsActive == true).AsEnumerable().ToList();
        }

        public Store Get(int id)
        {
            return entities.SingleOrDefault(e => e.Id == id && e.IsActive == true);
        }

        public void Insert(Store model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("store");
            }
            entities.Add(model);
            context.SaveChanges();
        }
        public void Update(Store model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("store");
            }
            context.Update(model);
            context.SaveChanges();
        }
        public void Delete(Store model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("store");
            }
            context.Remove(model);
            context.SaveChanges();
        }
        public void Remove(Store model)
        {
            context.Remove(model);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        
    }
}
