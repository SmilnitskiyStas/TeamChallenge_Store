using TeamChallengeProject_Shop.Data.Services.IServices;
using TeamChallengeProject_Shop.Models;
using TeamChallengeProject_Shop.Services.IServices;

namespace TeamChallengeProject_Shop.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDataService _db;

        public ProductService(IProductDataService db)
        {
            _db = db;
        }

        public Product CreateProduct(Product product)
        {
            return _db.CreateProductData(product);
        }

        public bool DeleteProduct(int productId)
        {
            return _db.DeleteProductData(productId);
        }

        public Product GetProduct(int productId)
        {
            return _db.GetProductData(productId);
        }

        public Product GetProduct(string productName)
        {
            return _db.GetProductData(productName);
        }

        public bool GetProductExists(string productName)
        {
            return _db.GetProductExistsData(productName);
        }

        public ICollection<Product> GetProducts()
        {
            return _db.GetProductsData();
        }

        public Product UpdateProduct(Product product)
        {
            return _db.UpdateProductData(product);
        }
    }
}
