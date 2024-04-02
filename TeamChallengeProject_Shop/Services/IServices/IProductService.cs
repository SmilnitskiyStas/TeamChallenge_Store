using TeamChallengeProject_Shop.Models;

namespace TeamChallengeProject_Shop.Services.IServices
{
    public interface IProductService
    {
        Product GetProduct(int productId);
        Product GetProduct(string productName);
        ICollection<Product> GetProducts();
        Product UpdateProduct(Product product);
        Product CreateProduct(Product product);
        bool DeleteProduct(int productId);
        bool GetProductExists(string productName);
    }
}
