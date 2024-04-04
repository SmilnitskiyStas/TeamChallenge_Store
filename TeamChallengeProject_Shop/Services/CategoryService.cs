using TeamChallengeProject_Shop.Data.Services.IServices;
using TeamChallengeProject_Shop.Models;
using TeamChallengeProject_Shop.Services.IServices;

namespace TeamChallengeProject_Shop.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDataService _categoryDataService;

        public CategoryService(ICategoryDataService categoryDataService)
        {
            _categoryDataService = categoryDataService;
        }

        public Category CreateCategory(Category model)
        {
            return _categoryDataService.CreateCategoryData(model);
        }

        public bool DeleteCategory(int categoryId)
        {
            return _categoryDataService.DeleteCategoryData(categoryId);
        }

        public ICollection<Category> GetCategories()
        {
            return _categoryDataService.GetCategoriesData();
        }

        public Category GetCategory(int categoryId)
        {
            return _categoryDataService.GetCategoryData(categoryId);
        }

        public Category GetCategory(string categoryName)
        {
            return _categoryDataService.GetCategoryData(categoryName);
        }

        public bool GetCategoryExists(string categoryName)
        {
            return _categoryDataService.GetCategoryDataExists(categoryName);
        }

        public Category UpdateCategory(Category model)
        {
            return _categoryDataService.UpdateCategoryData(model);
        }
    }
}
