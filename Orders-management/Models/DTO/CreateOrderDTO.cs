using Orders_management.Enums;

namespace Orders_management.Models.DTO
{
    public class CreateOrderDTO
    {
        public string ProductName { get; set; }
        public OrdersTypeEnum Type { get; set; }
        public decimal Price { get; set; }
        public String UserName { get; set; }
    }
}
