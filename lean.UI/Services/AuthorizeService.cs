using lean.UI.Helpers.Methods;
using lean.UI.Helpers.Models;
using lean.UI.Models.DTOs;
using lean.UI.Models.Entities;

namespace lean.UI.Services
{
    public class AuthorizeService
    {
        private readonly UserService _userService;

        public AuthorizeService(UserService userService)
        {
            _userService = userService;
        }

        public bool Login(UserLoginDTO userLoginDTO, out SessionUser sessionUser)
        {
            sessionUser = null;
            var hasshedpass = HasherHelper.ComputeSha256Hash(userLoginDTO.Password);
            var user = _userService.FirstOrDefault(x => x.Username.ToLower() == userLoginDTO.UserName && x.Password == hasshedpass);
            if (user != null)
            {
                sessionUser = new SessionUser
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Username = user.Username,
                    Role = user.Role,
                };
                return true;
            }
            return false;
        }

        public bool Register(UserRegisterDTO userRegisterDTO)
        {
            _userService.Add(new User
            {
                FullName = userRegisterDTO.FullName,
                Username = userRegisterDTO.UserName,
                Password = HasherHelper.ComputeSha256Hash(userRegisterDTO.Password),
            });
            return _userService.SaveChanges();
        }
    }
}
