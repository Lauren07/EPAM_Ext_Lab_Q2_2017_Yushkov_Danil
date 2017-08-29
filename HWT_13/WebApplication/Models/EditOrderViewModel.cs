using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class EditOrderViewModel
    {
        public int? OrderID { get; set; }

        public string CustomerID { get; set; }

        [Required(ErrorMessage = "Название не может быть пустым")]
        [StringLength(40,MinimumLength = 5, ErrorMessage = "Название должно содержать минимум 5 символов")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Телефон не может быть пустым")]
        [RegularExpression(@"^[0-9\.()-]*$", ErrorMessage = "Номер телефона содержит запрещенные символы")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Адрес не может быть пустым")]
        [StringLength(40, MinimumLength = 6, ErrorMessage = "Название должно содержать минимум 6 символов")]
        public string ShipAddress { get; set; }

        [Required(ErrorMessage = "Название города должно быть заполнено")]
        public string ShipCity { get; set; }

        [Required(ErrorMessage = "Страна должна быть заполнена")]
        public string ShipCountry { get; set; }
    }
}