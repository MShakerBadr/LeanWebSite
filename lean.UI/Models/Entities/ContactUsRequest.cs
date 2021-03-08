using lean.UI.Helpers.Models;
using lean.UI.LocalResources;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lean.UI.Models.Entities
{
    public class ContactUsRequest : Entity
    {
        [Display(Name = "Name", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "NameIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string Name { get; set; }
        
        [Display(Name = "Email", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "EmailIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string Email { get; set; }
        
        [Display(Name = "MobileNumber", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "MobileNumberIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string MobileNumber { get; set; }

        [ForeignKey("ContactUsReasonId")]
        public ContactUsReason ContactUsReason { get; set; }
        [Display(Name = "Reason", ResourceType = typeof(Resource))]
        public Nullable<long> ContactUsReasonId { get; set; }
        
        public string ContactUsReasonTextEn { get; set; }
        public string ContactUsReasonTextAr { get; set; }
        
        [Display(Name = "Message", ResourceType = typeof(Resource))]
        public string Message { get; set; }

        [Display(Name = "RequestDate", ResourceType = typeof(Resource))]
        public DateTime RequestDate { get; set; }


        [NotMapped]
        public string ContactUsReasonText => MySession.IsArabic ? ContactUsReasonTextAr : ContactUsReasonTextEn;

    }
}
