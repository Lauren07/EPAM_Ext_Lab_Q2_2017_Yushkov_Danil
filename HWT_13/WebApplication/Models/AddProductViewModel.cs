using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class AddProductViewModel
    {
        public int OrderID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public double UnitPrice { get; set; }

        [Required]
        [Range(0,10000)]
        public int Quantity { get; set; }

        [Required]
        [Range(0,99)]
        public double Discount { get; set; }
    }
}