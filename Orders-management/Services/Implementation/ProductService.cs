using Orders_management.Enums;
using Orders_management.Models;
using Orders_management.Models.DTO;
using Orders_management.Repository;

namespace Orders_management.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly OrdersManagementContext _dbContext;

        public ProductService(OrdersManagementContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateProduct(ProductDTO productDTO)
        {
            var product = new Product()
            {
                ProductCode = Guid.NewGuid().ToString(),
                ProductName = productDTO.ProductName,
                Price = productDTO.Price,
                Type = productDTO.Type.ToString()
            };

            _dbContext.Products.Add(product);

            _dbContext.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }

        public IEnumerable<Product> GetByProductType(OrdersTypeEnum type)
        {
            return _dbContext.Products.Where(item => item.Type == type.ToString());
        }

        public Product? GetProductByCode(string productCode)
        {
            return _dbContext.Products.Where(item => item.ProductCode == productCode).FirstOrDefault();
        }
    }
}
