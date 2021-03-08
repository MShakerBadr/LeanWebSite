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
    public class Clients : Entity
    {

        public string NameAr { get; set; }

        public string NameEng { get; set; }

        public string DescAr { get; set; }

        public string DescEng { get; set; }

        public string imgUrl { get; set; }

        [Display(Name = "IsShow", ResourceType = typeof(Resource))]
        public bool IsShow { get; set; } = true;


        [NotMapped] public string Name => MySession.IsArabic ? NameAr : NameEng;
        [NotMapped] public string Description=> MySession.IsArabic ? DescAr: DescEng;
        

    }
}