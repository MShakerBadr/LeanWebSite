using lean.UI.Helpers.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lean.UI.Models.Entities
{
    public class WhyUS :Entity
    {
        public string TitleEng { get; set; }

        public string TitleAR { get; set; }

        public string DescriptionAr { get; set; }
        public string DescriptionEng { get; set; }

        public string ImgUrl { get; set; }
        public bool IsShow { get; set; } = true;
        public virtual ICollection<WhyUSGalleries> WhyUsGallery { get; set; }
        #region notMapped
        [NotMapped]
        public string Title => MySession.IsArabic ? TitleAR : TitleEng;

        [NotMapped]
        public string Description => MySession.IsArabic ? DescriptionAr : DescriptionEng;
        #endregion
    }
}