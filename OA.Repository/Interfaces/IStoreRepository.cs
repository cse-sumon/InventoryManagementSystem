using OA.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Repository.Interfaces
{
    public interface IStoreRepository<T> where T : Store
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
