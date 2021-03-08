using lean.UI.LocalResources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lean.UI.Models.Entities
{
    public class ProjectGallery : Entity
    {
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        public long ProjectId { get; set; }


        [Display(Name = "ImageUrl", ResourceType = typeof(Resource))]
        public string ImageUrl { get; set; }
      
        
        [NotMapped] public bool IsImgChanged { get; set; } = false;
        [NotMapped] public string HandledImageUrl => ImageUrl ?? "/Assets/imgs/default-photo.png";

        [Display(Name = "TabOrder", ResourceType = typeof(Resource))]
        public int TabOrder { get; set; }
    }
}
