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

        public Store CreateData(Store store)
        {
            _db.Stores.Add(store);
            return _db.Stores.Where(s => s.Name == store.Name).FirstOrDefault();
        }

        public bool DeleteData(Store store)
        {
            _db.Stores.Remove(store);
            return _db.Stores.Where(s => s.Equals(store)).Any() == null ? true : false;
        }

        public ICollection<Store> GetAllData()
        {
            return _db.Stores.ToList();
        }

        public Store GetData(int id)
        {
            return _db.Stores.Where(s => s.StoreId == id).FirstOrDefault();
        }

        public Store GetData(string name)
        {
            return _db.Stores.Where(s => s.Name == name).FirstOrDefault();
        }

        public bool GetExistsData(string name)
        {
            return _db.Stores.Where(s =>s.Name == name).Any();
        }

        public Store UpdateData(Store store)
        {
            _db.Stores.Update(store);
            return _db.Stores.Where(s => s.Name == store.Name).FirstOrDefault();
        }
    }
}
