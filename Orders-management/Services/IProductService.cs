using Orders_management.Enums;
using Orders_management.Models;
using Orders_management.Models.DTO;

namespace Orders_management.Services
{
    public interface IProductService
    {
        public void CreateProduct(ProductDTO productDTO);
        public Product? GetProductByCode(string productCode);
        public IEnumerable<Product> GetAllProducts();
        public IEnumerable<Product> GetByProductType(OrdersTypeEnum type);
    }
}
