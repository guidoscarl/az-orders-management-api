using Orders_management.Enums;
using Orders_management.Models;
using Orders_management.Models.DTO;

namespace Orders_management.Services
{
    public interface IProductService
    {
        public void CreateProduct(ProductDTO productDTO);
        public Task<Product?> GetProductByCode(string productCode);
        public Task<IEnumerable<Product>> GetAllProducts();

        public Task<bool> GetBlackFriday();
        public Task<IEnumerable<Product>> GetByProductType(OrdersTypeEnum type);
    }
}
