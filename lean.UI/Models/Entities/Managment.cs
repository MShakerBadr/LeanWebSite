using lean.UI.Helpers.Models;
using lean.UI.LocalResources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lean.UI.Models.Entities
{
    public class Managment : Entity
    {
        [Display(Name = "NameAr", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "NameIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string NameAr { get; set; }
       
        [Display(Name = "NameEn", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "NameIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string NameEn { get; set; }
        
        [Display(Name = "PhotoUrl", ResourceType = typeof(Resource))]
        public string PhotoUrl { get; set; }
        
        [Display(Name = "PositionEn", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "PositionIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string PositionEn { get; set; }
        
        [Display(Name = "PositionAr", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "PositionIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string PositionAr { get; set; }
        
        [Display(Name = "DescriptionEn", ResourceType = typeof(Resource))]
        public string DescriptionEn { get; set; }
        
        [Display(Name = "DescriptionAr", ResourceType = typeof(Resource))]
        public string DescriptionAr { get; set; }



        [NotMapped]
        public string Name => MySession.IsArabic ? NameAr : NameEn;
        [NotMapped]
        public string Position => MySession.IsArabic ? PositionAr : PositionEn;
        [NotMapped]
        public string Description => MySession.IsArabic ? DescriptionAr : DescriptionEn;

    }
}
