using System.ComponentModel.DataAnnotations;

namespace Orders_management.Models
{
    public class Product
    {
        [Key]
        public string ProductCode { get; set; }

        public string ProductName {  get; set; }

        public string Type { get; set; }

        public decimal Price { get; set; }
    }
}
