using Azure.Core.Amqp;
using Azure.Identity;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Options;
using Orders_management.Models;

namespace Orders_management.Services.Implementation
{
    public class ServiceBusMessageHandler : IServiceBusMessageHandler
    {
        private ServiceBusClient _client;
        private Settings _settings;
        private readonly IWebHostEnvironment _env;

        public ServiceBusMessageHandler(IWebHostEnvironment env, IOptionsSnapshot<Settings> options)
        {
            _env = env;
            _settings = options.Value;
            if (_env.IsDevelopment())
            {
                _client = new ServiceBusClient(_settings.ServiceBusConnectionString);
            }
            else
            {
                _client = new ServiceBusClient(_settings.ServiceBusUrl, new DefaultAzureCredential());
            }
        }

        public async void SendOrderMessage(Order order)
        {
            var sender = _client.CreateSender(_settings.ServiceBusTopicName);

            ServiceBusMessage message = new ServiceBusMessage(order.ProductName);
            message.CorrelationId = order.Type;
            message.ApplicationProperties.Add("price", order.Price);
            message.ApplicationProperties.Add("userName", order.UserName);
            message.ApplicationProperties.Add("orderCode", order.OrderCode);

            try
            {
                await sender.SendMessageAsync(message);
            }
            finally
            {
                await sender.DisposeAsync();
            }
        }
    }
}
