using TeamChallengeProject_Shop.Models;

namespace TeamChallengeProject_Shop.Services.IServices
{
    public interface ICategoryService
    {
        Category GetCategory(int categoryId);
        Category GetCategory(string categoryName);
        ICollection<Category> GetCategories();
        Category UpdateCategory(Category model);
        Category CreateCategory(Category model);
        bool DeleteCategory(int categoryId);
        bool GetCategoryExists(string categoryName);
    }
}
