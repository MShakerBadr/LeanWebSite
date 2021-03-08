using lean.UI.Helpers.Models;
using lean.UI.LocalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace lean.UI.Models.Entities
{
    public class Slider : Entity
    {
        [Display(Name = "NameAr", ResourceType = typeof(Resource))]
        public string NameAr { get; set; }

        [Display(Name = "NameEn", ResourceType = typeof(Resource))]
        public string NameEn { get; set; }

        [Display(Name = "PhotoUrl", ResourceType = typeof(Resource))]
        public string PhotoUrl { get; set; }

        #region notMapped
        [NotMapped]
        public string Name => MySession.IsArabic ? NameAr : NameEn;
        #endregion

    }
}