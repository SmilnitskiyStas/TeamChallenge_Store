using TeamChallengeProject_Shop.Models;

namespace TeamChallengeProject_Shop.Data.Services.IServices
{
    public interface IProductDataService
    {
        Product GetProductData(int productId);
        Product GetProductData(string productName);
        ICollection<Product> GetProductsData();
        Product UpdateProductData(Product product);
        Product CreateProductData(Product product);
        bool DeleteProductData(int productId);
        bool GetProductExistsData(string productName);
    }
}
