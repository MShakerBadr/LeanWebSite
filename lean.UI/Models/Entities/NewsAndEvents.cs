using lean.UI.Helpers.Models;
using lean.UI.LocalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lean.UI.Models.Entities
{
    public class NewsAndEvents : Entity
    {
        [Display(Name = "NameEn", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "NameIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string NameEn { get; set; }

        [Display(Name = "NameAr", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "NameIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string NameAr { get; set; }

        [Display(Name = "DescriptionEn", ResourceType = typeof(Resource))]
        public string DescriptionEn { get; set; }

        [Display(Name = "DescriptionAr", ResourceType = typeof(Resource))]
        public string DescriptionAr { get; set; }

        [Display(Name = "AttachmentUrl", ResourceType = typeof(Resource))]
        public string AttachmentUrl { get; set; }

        [Display(Name = "IsEvent", ResourceType = typeof(Resource))]
        public bool IsEvent { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

        public virtual ICollection<NewsAndEventsGallery> NewsAndEventsGallery { get; set; }

        #region notMapped
        [NotMapped] public string Name => MySession.IsArabic ? NameAr : NameEn;
        [NotMapped] public string Description => MySession.IsArabic ? DescriptionAr : DescriptionEn;
        [NotMapped] public string HandeledAttachmentUrl => AttachmentUrl != null ? AttachmentUrl.ToString() : string.Empty;
        #endregion
    }
}
