using lean.UI.Helpers;
using lean.UI.Helpers.Methods;
using lean.UI.Helpers.Models;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace lean.UI.Controllers
{
    public class BaseController : Controller
    {

        [NonAction]
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        [HttpGet]
        public ActionResult ChangeLanguage(string language = null)
        {
            string culture = MyConstants.DefaultLanguage;
            if (language == null)
            {
                if (CookieHelper.GetCookie(MyConstants.CultureCookieName) != null)
                {
                    culture = (CookieHelper.GetCookie(MyConstants.CultureCookieName) == MyConstants.EnglishLanguage ? MyConstants.ArabicLanguage : MyConstants.EnglishLanguage);
                }
            }
            else
            {
                switch (language)
                {
                    case "ar-EG":
                        culture = MyConstants.ArabicLanguage;
                        MyConstants.CurrrentLanguage = MyConstants.ArabicLanguage;
                        break;
                    case "en-US":
                        culture = MyConstants.EnglishLanguage;
                        MyConstants.CurrrentLanguage = MyConstants.EnglishLanguage;
                        break;
                    default:
                        culture = MyConstants.EnglishLanguage;
                        MyConstants.CurrrentLanguage = MyConstants.EnglishLanguage;
                        break;
                }


            }


            CookieHelper.SetCookie(MyConstants.CultureCookieName, culture);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            if (Request.UrlReferrer != null)
                return Redirect(Request.UrlReferrer.ToString());

            return null;
        }

        [HttpGet]
        public ActionResult DownloadFile(string fileName)
        {
            var root = MyConstants.UploadsPath;
            var path = System.IO.Path.Combine(root, fileName).MapPath();
            if (!IOHelper.FileExists(path))
            {
                return Content("File Not Found!");
            }
            byte[] fileBytes = System.IO.File.ReadAllBytes(path);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }


    [Authorize]
    public class BaseAuthorizedController : BaseController
    {
        [NonAction]
        protected override void OnActionExecuting(ActionExecutingContext actionExecutingContext)
        {
            base.OnActionExecuting(actionExecutingContext);
        }
    }
}
