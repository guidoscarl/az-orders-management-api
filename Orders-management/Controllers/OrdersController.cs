using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orders_management.Enums;
using Orders_management.Models;
using Orders_management.Models.DTO;
using Orders_management.Services;
using Orders_management.Services.Implementation;

namespace Orders_management.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : Controller
    {
        private IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IEnumerable<Order> Index()
        {
            return _orderService.GetOrders();
        }

        [HttpGet("details")]
        // GET: OrdersController/Details/5
        public IActionResult Details(string orderCode)
        {
            var order = _orderService.GetOrder(orderCode);
            if(order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpGet("user-orders")]
        public IEnumerable<Order> GetOrdersByUser(string username)
        {
            return _orderService.GetOrdersByUsername(username);
        }

        [HttpPost]
        public IActionResult CreateOrder(CreateOrderDTO o)
        {
            _orderService.CreateOrder(o);
            return Ok();
        }
    }
}
