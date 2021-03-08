using lean.UI.Helpers.Models;
using lean.UI.LocalResources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lean.UI.Models.Entities
{
    public class StaticContent : Entity
    {
        [Display(Name = "CommercialProjectDescriptionEn", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "CommercialProjectDescriptionIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string CommercialProjectDescriptionEn { get; set; }

        [Display(Name = "CommercialProjectDescriptionAr", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "CommercialProjectDescriptionIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string CommercialProjectDescriptionAr { get; set; }

        [Display(Name = "ResidentialProjectDescriptionEn", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "ResidentialProjectDescriptionIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string ResidentialProjectDescriptionEn { get; set; }

        [Display(Name = "ResidentialProjectDescriptionAr", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "ResidentialProjectDescriptionIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string ResidentialProjectDescriptionAr { get; set; }

        [Display(Name = "AboutUstEn", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "AboutUsIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string AboutUstEn { get; set; }

        [Display(Name = "AboutUstAr", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "AboutUsIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string AboutUstAr { get; set; }

        [Display(Name = "AboutUstPhotoUrl", ResourceType = typeof(Resource))]
        public string AboutUsPhotoUrl { get; set; }

        [Display(Name = "ChairManNameEn", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "ChairManNameIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string ChairManNameEn { get; set; }

        [Display(Name = "ChairManNameAr", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "ChairManNameIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string ChairManNameAr { get; set; }

        [Display(Name = "ChairManPhotoUrl", ResourceType = typeof(Resource))]
        public string ChairManPhotoUrl { get; set; }

        [Display(Name = "ChairManWordEn", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "ChairManWordIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string ChairManWordEn { get; set; }

        [Display(Name = "ChairManWordAr", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "ChairManWordIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string ChairManWordAr { get; set; }

        [Display(Name = "VisionEn", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "VisionIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string VisionEn { get; set; }

        [Display(Name = "VisionAr", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "VisionIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string VisionAr { get; set; }

        [Display(Name = "MissionEn", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "MissionIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string MissionEn { get; set; }

        [Display(Name = "MissionAr", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "MissionIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string MissionAr { get; set; }

        [Display(Name = "ObjectivesEn", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "ObjectivesIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string ObjectivesEn { get; set; }

        [Display(Name = "ObjectivesAr", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "ObjectivesIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string ObjectivesAr { get; set; }

        [Display(Name = "WhatWeDeliveredEn", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "WhatWeDeliveredIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string WhatWeDeliveredEn { get; set; }

        [Display(Name = "WhatWeDeliveredAr", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "WhatWeDeliveredIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string WhatWeDeliveredAr { get; set; }

        [Display(Name = "CompanyLocationMapUrl", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "CompanyLocationMapUrlIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string CompanyLocationMapUrl { get; set; }

        [Display(Name = "LinkedInUrl", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "LinkedInUrlIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string LinkedInUrl { get; set; }

        [Display(Name = "FaceBookUrl", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "FaceBookUrlIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string FaceBookUrl { get; set; }

        [Display(Name = "InstagramUrl", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "InstagramUrlIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string InstagramUrl { get; set; }

        [Display(Name = "Phone", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "PhoneRIsequired", ErrorMessageResourceType = typeof(Resource))]
        public string Phone { get; set; }

        [Display(Name = "Mail", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "MaillIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string Mail { get; set; }

        [Display(Name = "ShowFeaturedProjects", ResourceType = typeof(Resource))]
        public bool ShowFeaturedProjects { get; set; }
        [Display(Name = "ShowCommercialSection", ResourceType = typeof(Resource))]
        public bool ShowCommercialSection { get; set; }
        [Display(Name = "ShowResdentialSection", ResourceType = typeof(Resource))]
        public bool ShowResdentialSection { get; set; }
        [Display(Name = "ShowVision", ResourceType = typeof(Resource))]
        public bool ShowVision { get; set; }
        [Display(Name = "ShowMission", ResourceType = typeof(Resource))]
        public bool ShowMission { get; set; }
        [Display(Name = "ShowObjectives", ResourceType = typeof(Resource))]
        public bool ShowObjectives { get; set; }
        [Display(Name = "ShowConvenientLocation", ResourceType = typeof(Resource))]
        public bool ShowConvenientLocation { get; set; }
        [Display(Name = "ShowConstructionUpdates", ResourceType = typeof(Resource))]
        public bool ShowConstructionUpdates { get; set; }
        [Display(Name = "ShowLocalization", ResourceType = typeof(Resource))]
        public bool ShowLocalization { get; set; }
        [Display(Name = "CompanyAddress", ResourceType = typeof(Resource))]
        public string CompanyAddress { get; set; }

        [Display(Name = "AboutUsBannerPhotoUrl", ResourceType = typeof(Resource))]
        public string AboutUsBannerPhotoUrl { get; set; }

        [Display(Name = "ProjectBannerPhotoUrl", ResourceType = typeof(Resource))]
        public string ProjectBannerPhotoUrl { get; set; }

        [Display(Name = "NewsBannerPhotoUrl", ResourceType = typeof(Resource))]
        public string NewsBannerPhotoUrl { get; set; }

        [Display(Name = "ContactBannerPhotoUrl", ResourceType = typeof(Resource))]
        public string ContactBannerPhotoUrl { get; set; }

        [Display(Name = "DeliveredBannerPhotoUrl", ResourceType = typeof(Resource))]
        public string DeliveredBannerPhotoUrl { get; set; }

        [Display(Name = "GalleryBannerPhotoUrl", ResourceType = typeof(Resource))]
        public string GalleryBannerPhotoUrl { get; set; }

    
        [Display(Name = "ProjectDetailsBannerPhotoUrl", ResourceType = typeof(Resource))]
        public string ProjectDetailsBannerPhotoUrl { get; set; }   
      
        [NotMapped] public string CommercialProjectDescription => MySession.IsArabic ? CommercialProjectDescriptionAr : CommercialProjectDescriptionEn;
        [NotMapped] public string ResidentialProjectDescription => MySession.IsArabic ? ResidentialProjectDescriptionAr : ResidentialProjectDescriptionEn;
        [NotMapped] public string AboutUst => MySession.IsArabic ? AboutUstAr : AboutUstEn;
        [NotMapped] public string ChairManName => MySession.IsArabic ? ChairManNameAr : ChairManNameEn;
        [NotMapped] public string ChairManWord => MySession.IsArabic ? ChairManWordAr : ChairManWordEn;
        [NotMapped] public string Vision => MySession.IsArabic ? VisionAr : VisionEn;
        [NotMapped] public string Mission => MySession.IsArabic ? MissionAr : MissionEn;
        [NotMapped] public string Objectives => MySession.IsArabic ? ObjectivesAr : ObjectivesEn;
        [NotMapped] public string WhatWeDelivered => MySession.IsArabic ? WhatWeDeliveredAr : WhatWeDeliveredEn;

    }
}
