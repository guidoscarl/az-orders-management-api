using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Orders_management.Models
{
    public class Order
    {
        [Key]
        public String OrderCode { get; set; }
        public string ProductName { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public String UserName { get; set; }

    }
}
