using TeamChallengeProject_Shop.Data.Services.IServices;
using TeamChallengeProject_Shop.Models;

namespace TeamChallengeProject_Shop.Data.Services
{
    public class StoreDataService : IStoreDataService
    {
        private readonly AppDbContext _db;

        public StoreDataService(AppDbContext db)
        {
            _db = db;
        }

        public Store CreateStoreData(Store store)
        {
            _db.Stores.Add(store);
            _db.SaveChanges();
            return _db.Stores.Where(s => s.Name == store.Name).FirstOrDefault();
        }

        public bool DeleteStoreData(int storeId)
        {
            var store = _db.Stores.Where(s => s.StoreId.Equals(storeId)).FirstOrDefault();
            _db.Stores.Remove(store);
            _db.SaveChanges();
            return _db.Stores.Where(s => s.Equals(store)).Any() != null ? true : false;
        }

        public ICollection<Store> GetStoresData()
        {
            return _db.Stores.ToList();
        }

        public Store GetStoreData(int id)
        {
            return _db.Stores.Where(s => s.StoreId == id).FirstOrDefault();
        }

        public Store GetStoreData(string name)
        {
            return _db.Stores.Where(s => s.Name == name).FirstOrDefault();
        }

        public bool GetStoreExistsData(string name)
        {
            return _db.Stores.Where(s =>s.Name == name).Any();
        }

        public Store UpdateStoreData(Store store)
        {
            _db.Stores.Update(store);
            _db.SaveChanges();
            return _db.Stores.Where(s => s.Name == store.Name).FirstOrDefault();
        }
    }
}
