using TeamChallengeProject_Shop.Models;

namespace TeamChallengeProject_Shop.Data.Services.IServices
{
    public interface ICategoryDataService
    {
        Category GetCategoryData(int categoryId);
        Category GetCategoryData(string categoryName);
        ICollection<Category> GetCategoriesData();
        Category UpdateCategoryData(Category model);
        Category CreateCategoryData(Category model);
        bool DeleteCategoryData(int categoryId);
        bool GetCategoryDataExists(string categoryName);
    }
}
