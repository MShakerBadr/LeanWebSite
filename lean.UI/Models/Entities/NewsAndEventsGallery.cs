using System.ComponentModel.DataAnnotations.Schema;

namespace lean.UI.Models.Entities
{
    public class NewsAndEventsGallery : Entity
    {
        [ForeignKey("NewsAndEventsId")]
        public NewsAndEvents NewsAndEvents { get; set; }
        public long NewsAndEventsId { get; set; }

        public string AttachmentUrl { get; set; }
        public string AttachmentFullUrl { get; set; }

        public bool IsVideo { get; set; }
    }
}
