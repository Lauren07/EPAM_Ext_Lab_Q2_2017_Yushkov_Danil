using System.Text.RegularExpressions;
using System.Web.Mvc;
using BusinessLogicLayer;

namespace FileStorage.Controllers
{
    public class HomeController : Controller
    {
        private UserManager userManager;
        private FileService fileService;

        public HomeController()
        {
            userManager = new UserManager();
            fileService = new FileService();
        }

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