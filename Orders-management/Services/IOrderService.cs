using Orders_management.Models;
using Orders_management.Models.DTO;

namespace Orders_management.Services
{
    public interface IOrderService
    {
        void CreateOrder(CreateOrderDTO o);
        Order? GetOrder(string orderCode);
        IEnumerable<Order> GetOrders();
        IEnumerable<Order> GetOrdersByUsername(string userName);
    }
}
