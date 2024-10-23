using ProductManagementSystemApi.Models;

namespace ProductManagementSystemApi.Repository.IRepository
{
    public interface IProductRepository
    {
        ICollection<Product> GetAllProducts();
        Product GetProductById(int productId);
        Product GetProductByName(string productName);   
        bool ProductExists(int productId);
        bool ProductExists(string productName);
        bool CreateProduct(Product product);
        bool UpdateProductById(Product product);
        bool UpdateProductByName(Product productName);
        bool DeleteProduct(Product productToDelete);
        bool DeleteProductByName(string productName);   
        bool Save();
      
    }
}
