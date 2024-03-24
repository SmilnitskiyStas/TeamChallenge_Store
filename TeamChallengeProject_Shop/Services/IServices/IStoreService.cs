using TeamChallengeProject_Shop.Models;

namespace TeamChallengeProject_Shop.Services.IServices
{
    public interface IStoreService
    {
        Store Get(int id);
        Store Get(string name);
        ICollection<Store> GetAll();
        Store Update(Store store);
        Store Create(Store store);
        bool Delete(Store store);
        bool GetExists(string name);
    }
}
