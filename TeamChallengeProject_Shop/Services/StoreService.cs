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

        public Store Create(Store store)
        {
            return _db.CreateData(store);
        }

        public bool Delete(Store store)
        {
            return _db.DeleteData(store);
        }

        public Store Get(int id)
        {
            return _db.GetData(id);
        }

        public Store Get(string name)
        {
            return _db.GetData(name);
        }

        public ICollection<Store> GetAll()
        {
            return _db.GetAllData();
        }

        public bool GetExists(string name)
        {
            return _db.GetExistsData(name);
        }

        public Store Update(Store store)
        {
            return _db.UpdateData(store);
        }
    }
}
