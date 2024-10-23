using ProductManagementSystemApi.Data;
using ProductManagementSystemApi.Models;
using ProductManagementSystemApi.Repository.IRepository;

namespace ProductManagementSystemApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CreateProduct(Product product)
        {
            //change tracker - 
            _dbContext.Add(product);
            return Save();
          
        }

        public bool DeleteProduct(Product productToDelete)
        {
            _dbContext.Remove(productToDelete);
            return Save();  
        }

        public bool DeleteProductByName(string productName)
        {
            _dbContext.Remove(productName);
            return Save();
        }

        public ICollection<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();    
        }

        public Product GetProductById(int productId)
        {
            return _dbContext.Products.Where(p => p.Id == productId).FirstOrDefault();
        
        }

        public Product GetProductByName(string productName)
        {
            return _dbContext.Products.Where(p => p.Name == productName).FirstOrDefault();
            
        }

        public bool ProductExists(int productId)
        {
           return _dbContext.Products.Any(p => p.Id == productId);
        }

        public bool ProductExists(string productName)
        {
            return _dbContext.Products.Any(p => p.Name == productName);
        }

        public bool Save()
        {
            var save = _dbContext.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool UpdateProductById(Product product)
        {
            _dbContext.Update(product);
            return Save();
        }

        public bool UpdateProductByName(Product product)
        {
            _dbContext.Update(product);
            return Save();
        }
    }
}
