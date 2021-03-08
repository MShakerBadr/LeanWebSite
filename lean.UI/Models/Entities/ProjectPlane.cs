using lean.UI.Helpers.Models;
using lean.UI.LocalResources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lean.UI.Models.Entities
{
    public class ProjectPlane : Entity
    {
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        public long ProjectId { get; set; }

        [Display(Name = "TextEn", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "TextIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string TextEn { get; set; }
       
        [Display(Name = "TextAr", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "TextIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string TextAr { get; set; }
        
        [Display(Name = "DescriptionEn", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "DescriptionIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string DescriptionEn { get; set; }
        
        [Display(Name = "DescriptionAr", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "DescriptionIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string DescriptionAr { get; set; }
        
        [Display(Name = "AttachmentUrl", ResourceType = typeof(Resource))]
        public string AttachmentUrl { get; set; }

        [Display(Name ="TabOrder",ResourceType =typeof(Resource))]
        public int TabOrder { get; set; }

        #region notMapped
        [NotMapped]
        public string Text => MySession.IsArabic ? TextAr : TextEn;
        [NotMapped]
        public string Description => MySession.IsArabic ? DescriptionAr : DescriptionEn;
        [NotMapped] public bool IsImgChanged { get; set; } = false;
        #endregion
    }
}
