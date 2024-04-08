using Microsoft.FeatureManagement;
using Orders_management.Enums;
using Orders_management.Models;
using Orders_management.Models.DTO;
using Orders_management.Repository;

namespace Orders_management.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly OrdersManagementContext _dbContext;
        private readonly IFeatureManager _featureManager;

        public ProductService(OrdersManagementContext dbContext, IFeatureManager featureManager)
        {
            _dbContext = dbContext;
            _featureManager = featureManager;
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

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = _dbContext.Products.ToList();

            var isBlackFriday = await _featureManager.IsEnabledAsync("blackFriday");

            if (!isBlackFriday)
            {
                return products;
            }

            products.ForEach(product => product.Price -= (0.20m * product.Price));
            return products;
        }

        public async Task<bool> GetBlackFriday()
        {
            var isBlackFriday = await _featureManager.IsEnabledAsync("blackFriday");
            return isBlackFriday;
        }

        public async Task<IEnumerable<Product>> GetByProductType(OrdersTypeEnum type)
        {
            var products = _dbContext.Products.Where(item => item.Type == type.ToString()).ToList();
            var isBlackFriday = await _featureManager.IsEnabledAsync("blackFriday");

            if (!isBlackFriday)
            {
                return products;
            }

            products.ForEach(product => product.Price -= (0.20m * product.Price));
            return products;
        }

        public async Task<Product?> GetProductByCode(string productCode)
        {
            var product = _dbContext.Products.Where(item => item.ProductCode == productCode).FirstOrDefault();
            if(product == null)
            {
                return product;
            }

            var isBlackFriday = await _featureManager.IsEnabledAsync("blackFriday");

            if (!isBlackFriday)
            {
                return product;
            }

            product.Price -= (0.20m * product.Price);
            return product;
        }
    }
}
