using lean.UI.Helpers.Models;
using lean.UI.LocalResources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lean.UI.Models.Entities
{
    public class WhatWeDelivered : Entity
    {
        [Display(Name = "NameEn", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "NameIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string NameEn { get; set; }

        [Display(Name = "NameAr", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "NameIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string NameAr { get; set; }

        [Display(Name = "LocationEn", ResourceType = typeof(Resource))]
        //[Required(ErrorMessageResourceName = "LocationIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string LocationEn { get; set; }

        [Display(Name = "LocationAr", ResourceType = typeof(Resource))]
        //[Required(ErrorMessageResourceName = "LocationIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string LocationAr { get; set; }

        [Display(Name = "DescriptionEn", ResourceType = typeof(Resource))]
        //[Required(ErrorMessageResourceName = "DescriptionIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string DescriptionEn { get; set; }

        [Display(Name = "DescriptionAr", ResourceType = typeof(Resource))]
        //[Required(ErrorMessageResourceName = "DescriptionIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string DescriptionAr { get; set; }

        [Display(Name = "ImageUrl", ResourceType = typeof(Resource))]
        public string ImageUrl { get; set; }

        public virtual ICollection<WhatWeDeliveredGallery> WhatWeDeliveredGallery { get; set; }


        #region notMapped
        [NotMapped]
        public string Name => MySession.IsArabic ? NameAr : NameEn;
        [NotMapped]
        public string Location => MySession.IsArabic ? LocationAr : LocationEn;
        [NotMapped]
        public string Description => MySession.IsArabic ? DescriptionAr : DescriptionEn;

        #endregion
    }
}
