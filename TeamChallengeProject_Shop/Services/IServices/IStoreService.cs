using TeamChallengeProject_Shop.Models;

namespace TeamChallengeProject_Shop.Services.IServices
{
    public interface IStoreService
    {
        Store GetStore(int id);
        Store GetStore(string name);
        ICollection<Store> GetStores();
        Store UpdateStore(Store store);
        Store CreateStore(Store store);
        bool DeleteStore(int storeId);
        bool GetStoreExists(string name);
    }
}
