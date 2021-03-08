using lean.UI.Helpers;
using lean.UI.Helpers.Models;
using lean.UI.Models.DTOs;
using lean.UI.Services;
using System.Web.Mvc;
using System.Web.Security;

namespace lean.UI.Controllers
{
    public class AuthorizeController : Controller
    {
        private readonly AuthorizeService _authorizeService;

        public AuthorizeController(AuthorizeService authorizeService)
        {
            _authorizeService = authorizeService;
        }


        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Home", "Admin");
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginDTO userLoginDTO)
        {
            SessionUser sessionUser;
            if (_authorizeService.Login(userLoginDTO, out sessionUser))
            {
                FormsAuthentication.RedirectFromLoginPage(sessionUser.Id.ToString(), userLoginDTO.RememberMe);
                return RedirectToAction("Home", "Admin");
            }
            else
            {
                ViewBag.LoginErrors = "Invalid UserName Or Password!";
            }
            return View(userLoginDTO);
        }

        [HttpGet]
        //[Stop]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        //[Stop]
        public ActionResult Register(UserRegisterDTO userRegisterDTO)
        {
            var res = _authorizeService.Register(userRegisterDTO);
            if (res)
            {
                return View("Login");
            }
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            SessionHelper.RemoveSession(MyConstants.SessionInfoName);
            return RedirectToAction("Login");
        }

        [HttpGet]
        [Authorize]
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}