using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApplication.Models
{
    public class EditOrderViewModel
    {
        public int? OrderID { get; set; }
        
        public string CustomerID { get; set; }

        [Required(ErrorMessage = "Название не может быть пустым")]
        [Remote("CheckCompanyName","Validation", ErrorMessage = "Название должно содержать минимум 5 символов")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Телефон не может быть пустым")]
        [Remote("CheckPhone", "Validation", ErrorMessage = "Номер телефона содержит запрещенные символы")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Адрес не может быть пустым")]
        [Remote("CheckAddress", "Validation", ErrorMessage = "Название должно содержать минимум 6 символов")]
        public string ShipAddress { get; set; }

        [Required]
        [Remote("CheckCity", "Validation", "Название города должно быть заполнено")]
        public string ShipCity { get; set; }

        [Required]
        [Remote("CheckCountry", "Validation", "Страна должна быть заполнена")]
        public string ShipCountry { get; set; }
    }
}