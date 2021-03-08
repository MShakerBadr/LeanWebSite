using lean.UI.Context;
using lean.UI.Models.Entities;
using lean.UI.Repositories;
using lean.UI.Services.Config;
using System.Linq;
using System.Threading.Tasks;

namespace lean.UI.Services
{
    public class SettingsService : BaseService<User, User>
    {
        private readonly BaseRepository _repo;
        private readonly LeanDbContext _context;
        private readonly SessionService _sessionService;
        private readonly HasherService _hasherService;


        public SettingsService(BaseRepository repo, LeanDbContext context) : base(repo)
        {
            _repo = repo;
            _context = context;
            _sessionService = new SessionService();
            _hasherService = new HasherService();
        }
        #region Settings
        public async Task<bool> ChangeUsername(string oldUsername, string newUsername)
        {
            var user = _context.Users.FirstOrDefault<User>(x => x.Id == _sessionService.User.Id);
            if (user != null)
            {
                if (string.IsNullOrEmpty(newUsername))
                    return false;
                if (user.Username.ToLower() == oldUsername.ToLower())
                {
                    user.Username = newUsername;
                    _context.Entry(user).State = System.Data.Entity.EntityState.Modified;
                }
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ChangePassword(string oldPassword, string newPassword)
        {
            var user = _context.Users.FirstOrDefault<User>(x => x.Id == _sessionService.User.Id);
            if (user != null)
            {
                if (string.IsNullOrEmpty(newPassword))
                    return false;
                if (user.Password == _hasherService.ComputeSha256Hash(oldPassword))
                {
                    user.Password = _hasherService.ComputeSha256Hash(newPassword);
                    _context.Entry(user).State = System.Data.Entity.EntityState.Modified;
                }
            }
            return await _context.SaveChangesAsync() > 0;
        }

        #endregion

    }
}