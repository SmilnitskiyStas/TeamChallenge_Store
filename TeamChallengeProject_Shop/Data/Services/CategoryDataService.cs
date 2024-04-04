using TeamChallengeProject_Shop.Data.Services.IServices;
using TeamChallengeProject_Shop.Models;

namespace TeamChallengeProject_Shop.Data.Services
{
    public class CategoryDataService : ICategoryDataService
    {
        private readonly AppDbContext _db;

        public CategoryDataService(AppDbContext db)
        {
            _db = db;
        }

        public Category CreateCategoryData(Category model)
        {
            var category = _db.Categories.Add(model);
            _db.SaveChanges();
            return _db.Categories.Where(c => c.Name == model.Name).FirstOrDefault();
        }

        public bool DeleteCategoryData(int categoryId)
        {
            var categoryToDelete = _db.Categories.Where(c => c.CategoryId == categoryId).FirstOrDefault();
            _db.Categories.Remove(categoryToDelete);
            _db.SaveChanges();
            return _db.Categories.Where(c => c.CategoryId == categoryId).Any() != null ? true : false;
        }

        public ICollection<Category> GetCategoriesData()
        {
            return _db.Categories.ToList();
        }

        public Category GetCategoryData(int categoryId)
        {
            return _db.Categories.Where(c => c.CategoryId == categoryId).FirstOrDefault();
        }

        public Category GetCategoryData(string categoryName)
        {
            return _db.Categories.Where(c => c.Name == categoryName).FirstOrDefault();
        }

        public bool GetCategoryDataExists(string categoryName)
        {
            return _db.Categories.Where(c => c.Name == categoryName).Any();
        }

        public Category UpdateCategoryData(Category model)
        {
            _db.Categories.Update(model);
            _db.SaveChanges();
            return _db.Categories.Where(c => c.Name == model.Name).FirstOrDefault();
        }
    }
}
