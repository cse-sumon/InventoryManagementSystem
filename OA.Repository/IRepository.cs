using OA.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Repository
{
   public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GellAll(int storeId);
        T Get(int id, int storeId);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
