using lean.UI.Helpers.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using lean.UI.LocalResources;
using System.Linq;
using System.Web;

namespace lean.UI.Models.Entities
{
    public class AboutUs :Entity
    {

        [Display(Name = "AboutUstEn", ResourceType =typeof(Resource))]
        public string TitleEn { get; set; }

        [Display(Name = "AboutUstAr",ResourceType =typeof(Resource))]
        public string TitleAr { get; set; }

        [Display(Name = "DescriptionAr", ResourceType =typeof(Resource))]
        public string DescEn { get; set; }

        [Display(Name = "DescriptionEn", ResourceType =typeof(Resource))]
        public string DescAr { get; set; }

        public string ImgPath{ get; set; }


        [Display(Name = "IsShow", ResourceType =typeof(Resource))]
        public bool IsShow { get; set; }

        [NotMapped] public string Title => MySession.IsArabic ? TitleAr : TitleEn;
        [NotMapped] public string Desc => MySession.IsArabic ? DescAr : DescEn;



    }
}