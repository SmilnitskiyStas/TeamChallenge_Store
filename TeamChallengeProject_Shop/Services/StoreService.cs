using TeamChallengeProject_Shop.Data.Services.IServices;
using TeamChallengeProject_Shop.Models;
using TeamChallengeProject_Shop.Services.IServices;

namespace TeamChallengeProject_Shop.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreDataService _db;

        public StoreService(IStoreDataService db)
        {
            _db = db;
        }

        public Store CreateStore(Store store)
        {
            return _db.CreateStoreData(store);
        }

        public bool DeleteStore(int storeId)
        {
            return _db.DeleteStoreData(storeId);
        }

        public Store GetStore(int id)
        {
            return _db.GetStoreData(id);
        }

        public Store GetStore(string name)
        {
            return _db.GetStoreData(name);
        }

        public ICollection<Store> GetStores()
        {
            return _db.GetStoresData();
        }

        public bool GetStoreExists(string name)
        {
            return _db.GetStoreExistsData(name);
        }

        public Store UpdateStore(Store store)
        {
            return _db.UpdateStoreData(store);
        }
    }
}
