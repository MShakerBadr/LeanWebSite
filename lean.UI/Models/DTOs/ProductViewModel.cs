using lean.UI.Models.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lean.UI.Models.DTOs
{
    public class ProductViewModel
    {
        public ProductFilter Filter { get; set; }
        public IPagedList<Product> list{ get; set; }
    }
}