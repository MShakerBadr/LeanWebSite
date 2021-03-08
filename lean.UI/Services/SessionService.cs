using lean.UI.Models.Entities;
using lean.UI.Models;
using Newtonsoft.Json;
using System.Linq;
using System.Web;
using lean.UI.Helpers.Models;
using lean.UI.Context;

namespace lean.UI.Services
{
    public class SessionService
    {
        public SessionUser User { get; }
        private readonly LeanDbContext _db;

        public SessionService()
        {
            _db = new LeanDbContext();

            //handle default sessions
            var httpContext = HttpContext.Current;
            if (string.IsNullOrEmpty(Get("user")) && !string.IsNullOrEmpty(httpContext.User.Identity.Name))
            {
                var intId = int.Parse(httpContext.User.Identity.Name);
                var user = _db.Users.FirstOrDefault(x => x.Id == intId);
                if (user != null)
                {
                    SessionUser sessionUser = new SessionUser
                    {
                        Id = user.Id,
                        Username = user.Username,
                        FullName = user.FullName,
                        Role = user.Role,
                    };
                    User = sessionUser;
                    Set("user", JsonConvert.SerializeObject(sessionUser));
                }
            }

            if (!string.IsNullOrEmpty(Get("user")))
                User = JsonConvert.DeserializeObject<SessionUser>(Get("user"));
        }


        public void Set(string key, string value)
        {
            HttpContext.Current.Session[key] = value;
        }

        public string Get(string key)
        {
            if (HttpContext.Current.Session[key] != null)
                return HttpContext.Current.Session[key].ToString();
            return string.Empty;
        }

    }
}
