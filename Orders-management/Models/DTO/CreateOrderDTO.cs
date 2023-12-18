namespace Orders_management.Models.DTO
{
    public class CreateOrderDTO
    {
        public string ProductName { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public String UserName { get; set; }
    }
}
