using TeamChallengeProject_Shop.Models;

namespace TeamChallengeProject_Shop.Data.Services.IServices
{
    public interface IStoreDataService
    {
        Store GetStoreData(int id);
        Store GetStoreData(string name);
        ICollection<Store> GetStoresData();
        Store UpdateStoreData(Store store);
        Store CreateStoreData(Store store);
        bool DeleteStoreData(int storeId);
        bool GetStoreExistsData(string name);
    }
}
