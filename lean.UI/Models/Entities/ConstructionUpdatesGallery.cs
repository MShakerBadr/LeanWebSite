using System.ComponentModel.DataAnnotations.Schema;

namespace lean.UI.Models.Entities
{
    public class ConstructionUpdatesGallery : Entity
    {
        [ForeignKey("ConstructionUpdatesId")]
        public ConstructionUpdates ConstructionUpdates { get; set; }
        public long ConstructionUpdatesId { get; set; }

        public string AttachmentUrl { get; set; }
        public string AttachmentFullUrl { get; set; }
        public bool IsVideo { get; set; }
    }
}
