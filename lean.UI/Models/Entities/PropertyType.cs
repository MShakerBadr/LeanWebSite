using lean.UI.LocalResources;
using System.ComponentModel.DataAnnotations;
using lean.UI.Helpers.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace lean.UI.Models.Entities
{
    public class PropertyType : Entity
    {
        [Display(Name = "NameAr", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "NameIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string NameAr { get; set; }
        
        [Display(Name = "NameEn", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "NameIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string NameEn { get; set; }

        #region notMapped
        [NotMapped]
        public string Name => MySession.IsArabic ? NameAr : NameEn;
        #endregion
    }
}
