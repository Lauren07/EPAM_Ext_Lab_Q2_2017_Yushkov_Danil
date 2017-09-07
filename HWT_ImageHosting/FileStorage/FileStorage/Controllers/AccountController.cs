using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using BusinessLogicLayer;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;
using FileStorage.Models;
using FileStorage.Resources;

namespace FileStorage.Controllers
{
    public class AccountController : Controller
    {
        private UserManager userManager;

        public AccountController()
        {
            userManager = new UserManager();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var preparedUser = Mapper.Map<UserLoginViewModel, UserDTO>(user);
                if (userManager.UserIsLogin(preparedUser))
                {
                    FormsAuthentication.SetAuthCookie(user.Login, user.RememberMe);
                    return Json(new {result = MessagesResource.OperationSuccess, url = Url.Action("Index", "Home")});
                }
            }

            return new EmptyResult();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return PartialView();
        }

        public ActionResult Roles()
        {
            var roles = Mapper.Map<IEnumerable<Role>, IEnumerable<RoleViewModel>>(userManager.GetAllRoles());
            return PartialView(roles);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(UserRegistrationViewModel newUser)
        {
            if (ModelState.IsValid)
            {
                var preparedUser = Mapper.Map<UserRegistrationViewModel, UserDTO>(newUser);
                userManager.RegisterUser(preparedUser);
                FormsAuthentication.SetAuthCookie(preparedUser.Login, false);
            }

            return Redirect("~/Home/Index");
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public JsonResult CheckExistingLogin(string login)
        {
            var result = !userManager.UserIsExisting(login);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(UserChangePasswordViewModel passwordInfo)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.FindUser(HttpContext.User.Identity.Name);
                if (user.PassIsMatch(passwordInfo.OldPassword))
                {
                    var preparedUser = new UserDTO
                    {
                        Id = user.Id,
                        Login = user.Login,
                        Password = passwordInfo.NewPassword
                    };
                    userManager.UpdateUser(preparedUser);
                    ViewData["StateChange"] = MessagesResource.OperationSuccess;
                }
                else
                {
                    ViewData["StateChange"] = MessagesResource.OperationError;
                }
            }

            return View(new UserChangePasswordViewModel());

        }
    }
}