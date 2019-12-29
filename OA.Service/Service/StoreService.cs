using OA.Data;
using OA.Repository.Interfaces;
using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Service
{
    public class StoreService : IStoreService
    {
        private IStoreRepository<Store> _storeRepository;

        public StoreService(IStoreRepository<Store> storeRepository)
        {
            _storeRepository = storeRepository; 
        }


        public IEnumerable<Store> GetStores()
        {
            return _storeRepository.GetAll();
        }


        public Store GetStore(int id)
        {
            return _storeRepository.Get(id);
        }

      
        public void InsertStore(Store store)
        {
            _storeRepository.Insert(store);
        }


        public void UpdateStore(Store store)
        {
            _storeRepository.Update(store);
        }


        public void SoftDeleteStore(Store store)
        {
            _storeRepository.Update(store);
        }


        public void DeleteStore(Store store)
        {
            _storeRepository.Delete(store);
        }
    }
}
