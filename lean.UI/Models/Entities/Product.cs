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
    public class Product : Entity
    {

        [Display(Name = "TitleEn", ResourceType =typeof(Resource))]
        public string TitleEn { get; set; }
        
        [Display(Name = "TitleAr", ResourceType =typeof(Resource))]
        public string TitleAr { get; set; }

        [Display(Name = "DescriptionAr", ResourceType =typeof(Resource))]
        public string DescAr { get; set; }
        
        [Display(Name = "DescriptionEn", ResourceType =typeof(Resource))]
        public string DescEn { get; set; }

        [Display(Name = "ImageUrl", ResourceType = typeof(Resource))]
        public string ImgPath { get; set; }


        [Display(Name = "IsShow", ResourceType = typeof(Resource))]
        public bool IsShow { get; set; } =true;

        [NotMapped] public string Title => MySession.IsArabic ? TitleAr : TitleEn;
        [NotMapped] public string Desc => MySession.IsArabic ? DescAr : DescEn;





    }
}