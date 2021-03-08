using System.ComponentModel.DataAnnotations.Schema;

namespace lean.UI.Models.Entities
{
    public class WhatWeDeliveredGallery : Entity
    {
        [ForeignKey("WhatWeDeliveredId")]
        public WhatWeDelivered WhatWeDelivered { get; set; }
        public long WhatWeDeliveredId { get; set; }
        public string AttachmentUrl { get; set; }
        public string AttachmentFullUrl { get; set; }
        public bool IsVideo { get; set; }
    }
}
