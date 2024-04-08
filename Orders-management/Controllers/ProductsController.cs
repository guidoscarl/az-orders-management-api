using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Orders_management.Enums;
using Orders_management.Models;
using Orders_management.Models.DTO;
using Orders_management.Services;

namespace Orders_management.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private IProductService _productService;


        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productService.GetAllProducts().Result;
        }

        [HttpGet("blackFriday")]
        public bool GetBlackFriday()
        {
            return _productService.GetBlackFriday().Result;
        }

        [HttpGet("type")]
        public IEnumerable<Product> GetByType(OrdersTypeEnum type)
        {
            return _productService.GetByProductType(type).Result;
        }

        [HttpGet("details")]
        public IActionResult GetByProductCode(string productCode)
        {
            var product = _productService.GetProductByCode(productCode).Result;
            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductDTO product) {

            _productService.CreateProduct(product);
            return Ok();
        }
    }
}
