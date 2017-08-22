using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class ValidationController : Controller
    {

        public JsonResult CheckCompanyName(string companyName)
        {
            return this.Json(companyName.Length >= 5, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckPhone(string phone)
        {
            var patternPhone = @"^[0-9.-]*$";
            return this.Json(Regex.IsMatch(phone, patternPhone), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckAddress(string shipAddress)
        {
            return this.Json(shipAddress.Length >= 6, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckCity(string shipCity)
        {
            return this.Json(shipCity.Length > 0, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckCountry(string shipCountry)
        {
            return this.Json(shipCountry.Length > 0, JsonRequestBehavior.AllowGet);
        }
    }
}