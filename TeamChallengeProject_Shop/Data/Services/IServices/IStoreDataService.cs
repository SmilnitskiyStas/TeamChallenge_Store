using TeamChallengeProject_Shop.Models;

namespace TeamChallengeProject_Shop.Data.Services.IServices
{
    public interface IStoreDataService
    {
        Store GetData(int id);
        Store GetData(string name);
        ICollection<Store> GetAllData();
        Store UpdateData(Store store);
        Store CreateData(Store store);
        bool DeleteData(Store store);
        bool GetExistsData(string name);
    }
}
