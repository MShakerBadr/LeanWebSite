using lean.UI.LocalResources;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lean.UI.Models.Entities
{
    public class JobRequest : Entity
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
        
        [Display(Name = "Job", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "JobIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string Job { get; set; }
        
        [ForeignKey("AvilableJobId")]
        public AvilableJob AvilableJob { get; set; }
        public long AvilableJobId { get; set; }

        [Display(Name = "CvUrl", ResourceType = typeof(Resource))]
        public string CvUrl { get; set; }
        
        [Display(Name = "Message", ResourceType = typeof(Resource))]
        public string Message { get; set; }
        [Display(Name = "RequestDate", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "RequestDateIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public DateTime RequestDate { get; set; }

    }
}
