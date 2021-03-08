using lean.UI.Helpers.Models;
using lean.UI.LocalResources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lean.UI.Models.Entities
{
    public class Gallery : Entity
    {
        [Display(Name = "AttchmentNameEn", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "AttchmentNameIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string AttchmentNameEn { get; set; }
        
        [Display(Name = "AttchmentNameAr", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "AttchmentNameIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string AttchmentNameAr { get; set; }

        [Display(Name = "AttchmentDescriptionEn", ResourceType = typeof(Resource))]
        public string AttchmentDescriptionEn { get; set; }

        [Display(Name = "AttchmentDescriptionAr", ResourceType = typeof(Resource))]
        public string AttchmentDescriptionAr { get; set; }

        [Display(Name = "AttchmentUrl", ResourceType = typeof(Resource))]
        public string AttchmentUrl { get; set; }

        [Display(Name = "VideoUrl", ResourceType = typeof(Resource))]
        public string VideoUrl { get; set; }
        
        [Display(Name = "IsVideo", ResourceType = typeof(Resource))]
        public bool IsVideo { get; set; }


        [NotMapped] public string AttchmentName => MySession.IsArabic ? AttchmentNameAr : AttchmentNameEn;
        [NotMapped] public string AttchmentDescription => MySession.IsArabic ? AttchmentDescriptionAr : AttchmentDescriptionEn;
        [NotMapped] public string AttchmentHandledUrl => AttchmentUrl ?? "/Assets/imgs/default-photo.png";
        [NotMapped] public string VideoHandledUrl => VideoUrl ?? string.Empty;

    }
}
