using Orders_management.Models;

namespace Orders_management.Services
{
    public interface IServiceBusMessageHandler
    {
        void SendOrderMessage(Order order);
    }
}
