using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace lean.UI.Models.Entities
{
    public class WhyUSGalleries :Entity
    {
        [ForeignKey("WhyUsId")]
        public WhyUS WhyUS { get; set; }
        public long WhyUsId { get; set; }

        public string AttachmentUrl { get; set; }

        public string AttachmentFullUrl { get; set; }

        public bool IsVideo { get; set; }
    }
}