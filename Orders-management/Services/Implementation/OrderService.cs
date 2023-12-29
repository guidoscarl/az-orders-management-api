using Microsoft.EntityFrameworkCore;
using Orders_management.Models;
using Orders_management.Models.DTO;
using Orders_management.Repository;

namespace Orders_management.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly OrdersManagementContext _dbContext;
        private readonly IServiceBusMessageHandler _messageHandler;
        public OrderService(OrdersManagementContext dbContext, IServiceBusMessageHandler messageHandler)
        {
            _dbContext = dbContext;
            _messageHandler = messageHandler;
        }

        public void CreateOrder(CreateOrderDTO o)
        {
            Order order = new()
            {
                Price = o.Price,
                ProductName = o.ProductName,
                Type = o.Type.ToString(),
                UserName = o.UserName,
                OrderCode = Guid.NewGuid() + o.UserName,
            };

            //_dbContext.Orders.Add(order);

            //_dbContext.SaveChanges();
            _messageHandler.SendOrderMessage(order);
        }

        public Order? GetOrder(string orderCode)
        {
            return _dbContext.Orders.Where(o => o.OrderCode == orderCode).FirstOrDefault();
        }

        public IEnumerable<Order> GetOrders()
        {
            return _dbContext.Orders.ToList();
        }

        public IEnumerable<Order> GetOrdersByUsername(string userName)
        {
            return _dbContext.Orders.Where(order => order.UserName == userName);
        }
    }
}
