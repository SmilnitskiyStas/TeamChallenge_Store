using Azure.Core;
using TeamChallengeProject_Shop.Data.Services.IServices;
using TeamChallengeProject_Shop.Models;

namespace TeamChallengeProject_Shop.Data.Services
{
    public class ProductDataService : IProductDataService
    {
        private readonly AppDbContext _db;

        public ProductDataService(AppDbContext db)
        {
            _db = db;
        }

        public Product CreateProductData(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();

            return _db.Products.Where(p => p.Name == product.Name).FirstOrDefault();
        }

        public bool DeleteProductData(int productId)
        {
            var product = _db.Products.Where(p => p.ProductId == productId).FirstOrDefault();
            _db.Remove(product);

            return _db.Products.Where(p => p.Equals(product)).Any() != null ? true : false;
        }

        public Product GetProductData(int productId)
        {
            return _db.Products.Where(p => p.ProductId == productId).FirstOrDefault();
        }

        public Product GetProductData(string productName)
        {
            return _db.Products.Where(p => p.Name.Equals(productName)).FirstOrDefault();
        }

        public bool GetProductExistsData(string productName)
        {
            return _db.Products.Where(p => p.Name.Equals(productName)).Any();
        }

        public ICollection<Product> GetProductsData()
        {
            var pro = _db.Products.ToList();
            return pro;
        }

        public Product UpdateProductData(Product product)
        {
            _db.Products.Update(product);

            return _db.Products.Where(p => p.Name.Equals(product.Name)).FirstOrDefault();
        }
    }
}
