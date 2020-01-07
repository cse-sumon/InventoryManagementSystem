using OA.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Repository.Interfaces
{
    public interface IStoreRepository
    {
        IEnumerable<Store> GetAll();
        Store Get(int id);
        void Insert(Store model);
        void Update(Store model);
        void Delete(Store model);
        void Remove(Store model);
        void SaveChanges();
    }
}
