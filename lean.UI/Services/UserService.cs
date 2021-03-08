using lean.UI.Models.Entities;
using lean.UI.Repositories;

namespace lean.UI.Services
{
    public class UserService : BaseService<User, User>
    {
        public UserService(BaseRepository repo) : base(repo)
        {

        }
    }
}