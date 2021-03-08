using lean.UI.Helpers.Models;
using lean.UI.LocalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lean.UI.Models.Entities
{
    public class Project : Entity
    {
        [ForeignKey("ProjectTypeId")]
        public ProjectType ProjectType { get; set; }
       
        [Display(Name = "ProjectTypeId", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "ProjectTypeIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public long ProjectTypeId { get; set; }

        
        [ForeignKey("PropertyTypeId")]
        public PropertyType PropertyType { get; set; }
        [Display(Name = "PropertyTypeId", ResourceType = typeof(Resource))]
        public Nullable<long> PropertyTypeId { get; set; }

        [ForeignKey("UnitTypeId")]
        public UnitType UnitType { get; set; }
        public Nullable<long> UnitTypeId { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }
        public Nullable<long> LocationId { get; set; }
        
        [Display(Name = "CoverUrl", ResourceType = typeof(Resource))]
        public string CoverUrl { get; set; }
        
        [Display(Name = "TitleAr", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "TitleArIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string TitleAr { get; set; }
        
        [Display(Name = "TitleEn", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "TitleEnIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string TitleEn { get; set; }

        [Display(Name = "ConceptEn", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "ConceptIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string ConceptEn { get; set; }
        
        [Display(Name = "ConceptAr", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "ConceptIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string ConceptAr { get; set; }

        [Display(Name = "HomeConceptEn", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "ConceptIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string HomeConceptEn { get; set; }

        [Display(Name = "HomeConceptAr", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "ConceptIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string HomeConceptAr { get; set; }

        [Display(Name = "ConceptImageUrl", ResourceType = typeof(Resource))]
        public string ConceptImageUrl { get; set; }
        
        [Display(Name = "MasterPlanEn", ResourceType = typeof(Resource))]
        public string MasterPlanEn { get; set; }
        
        [Display(Name = "MasterPlanAr", ResourceType = typeof(Resource))]
        public string MasterPlanAr { get; set; }

        [Display(Name = "MasterPlanImageUrl", ResourceType = typeof(Resource))]
        public string MasterPlanImageUrl { get; set; }

        [Display(Name = "ConvenientLocationTextEn", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "ConvenientLocationTextIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string ConvenientLocationTextEn { get; set; }
        
        [Display(Name = "ConvenientLocationTextAr", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "ConvenientLocationTextIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string ConvenientLocationTextAr { get; set; }

        [Display(Name = "ConvenientLocationTextAr", ResourceType = typeof(Resource))]
        public string ConvenientLocationAttachmentUrl { get; set; }

        [Display(Name = "ConvenientLocationDirectionUrl", ResourceType = typeof(Resource))]
        public string ConvenientLocationDirectionUrl { get; set; }

        [Display(Name = "ConstructionUpdatesTextEn", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "ConstructionUpdatesTextIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string ConstructionUpdatesTextEn { get; set; }

        [Display(Name = "ConstructionUpdatesTextAr", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "ConstructionUpdatesTextIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string ConstructionUpdatesTextAr { get; set; }

        [Display(Name = "ConstructionUpdatesDirectionUrl", ResourceType = typeof(Resource))]
        public string ConstructionUpdatesDirectionUrl { get; set; }

        [Display(Name = "WebsiteUrl3D", ResourceType = typeof(Resource))]
        public string WebsiteUrl3D { get; set; }

        [Display(Name = "IsSpecialProject", ResourceType = typeof(Resource))]
        public bool IsSpecialProject { get; set; }
        [Display(Name = "IsHidden", ResourceType = typeof(Resource))]
        public bool IsHidden { get; set; }

        public string Code { get; set; }
        public string Logo { get; set; }

        public virtual ICollection<ProjectAmenitie> ProjectAmenities { get; set; }
        public virtual ICollection<ProjectPlane> ProjectPlanes { get; set; }
        public virtual ICollection<ProjectGallery> ProjectGallery { get; set; }
        public virtual ICollection<ConstructionUpdates> ConstructionUpdates { get; set; }



        #region notMapped
        [NotMapped] public string Title => MySession.IsArabic ? TitleAr : TitleEn;
        [NotMapped] public string Concept => MySession.IsArabic ? ConceptAr : ConceptEn;
        [NotMapped] public string HomeConcept => MySession.IsArabic ? HomeConceptAr : HomeConceptEn;

        [NotMapped] public string MasterPlan => MySession.IsArabic ? MasterPlanAr : MasterPlanEn;
        [NotMapped] public string ConvenientLocationText => MySession.IsArabic ?  ConvenientLocationTextAr: ConvenientLocationTextEn;
        [NotMapped] public string ConstructionUpdatesText => MySession.IsArabic ? ConstructionUpdatesTextAr : ConstructionUpdatesTextEn;
        [NotMapped] public string HandledLogo => Logo ?? string.Empty;
        [NotMapped] public string HandledCoverUrl => CoverUrl ?? string.Empty;
        [NotMapped] public string HandledMasterPlanImageUrl => MasterPlanImageUrl ?? string.Empty;
        [NotMapped] public string HandledConceptImageUrl => ConceptImageUrl ?? string.Empty;
        [NotMapped] public string HandledConvenientLocationAttachmentUrl => ConvenientLocationAttachmentUrl ?? string.Empty;
        #endregion
    }
}
