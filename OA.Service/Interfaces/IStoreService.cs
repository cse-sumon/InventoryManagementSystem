using OA.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Interfaces
{
    public interface IStoreService
    {
        IEnumerable<Store> GetStores();
        Store GetStore(int id);
        void InsertStore(Store store);
        void UpdateStore(Store store);
        void DeleteStore(Store store);
        void SoftDeleteStore(Store store);
    }
}
