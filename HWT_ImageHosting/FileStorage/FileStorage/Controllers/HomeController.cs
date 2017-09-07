using System.Text.RegularExpressions;
using System.Web.Mvc;
using BusinessLogicLayer;

namespace FileStorage.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CheckFileExtension(string content)
        {
            var pattern = @".*\.((jpg)|(jpeg)|(png))$";
            return Json(Regex.IsMatch(content, pattern, RegexOptions.IgnoreCase), JsonRequestBehavior.AllowGet);
        }
    }
}