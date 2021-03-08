using lean.UI.LocalResources;
using System.ComponentModel.DataAnnotations;

namespace lean.UI.Models.Entities
{
    public class User : Entity
    {
        [Display(Name = "FullName", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "NameIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string FullName { get; set; }

        [Display(Name = "Username", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "UsernameIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string Username { get; set; }

        [Display(Name = "Password", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "PasswordIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string Password { get; set; }
        [Display(Name = "Role", ResourceType = typeof(Resource))]
        public int Role { get; set; }
    }
}
