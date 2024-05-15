namespace Orders_management
{
    public class Settings
    {
        public string ServiceBusConnectionString { get; set; }
        public string ServiceBusUrl { get; set; }
        public string ServiceBusTopicName { get; set; }
        public string CosmosDBEndpoint { get; set;}
    }
}
