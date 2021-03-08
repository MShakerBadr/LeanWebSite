using lean.UI.Helpers.Models;
using lean.UI.LocalResources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lean.UI.Models.Entities
{
    public class HeaderFooterPages : Entity
    {
        [Display(Name = "NameAr", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "NameIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string NameAr { get; set; }
        
        [Display(Name = "NameEn", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "NameIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string NameEn { get; set; }

        [Display(Name = "DescriptionAr", ResourceType = typeof(Resource))]
        public string DescriptionAr { get; set; }

        [Display(Name = "DescriptionEn", ResourceType = typeof(Resource))]
        public string DescriptionEn { get; set; }

        [Display(Name = "TabOrder", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "TabOrderIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public int TabOrder { get; set; }

        [Display(Name = "TabUrl", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "TabUrlIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string TabUrl { get; set; }

        [Display(Name = "IsHeader", ResourceType = typeof(Resource))]
        public bool IsHeader { get; set; }
        
        [Display(Name = "Show", ResourceType = typeof(Resource))]
        public bool Show { get; set; }

        #region notMapped
        [NotMapped]
        public string Name => MySession.IsArabic ? NameAr : NameEn;
        public string Description => MySession.IsArabic ? DescriptionAr : DescriptionEn;

        #endregion
    }
}
