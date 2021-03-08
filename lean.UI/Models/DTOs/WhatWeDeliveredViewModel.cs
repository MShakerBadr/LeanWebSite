using lean.UI.Models.Entities;
using PagedList;

namespace lean.UI.Models.DTOs
{
    public class WhatWeDeliveredViewModel
    {
        public WhatWeDeliveredFilter Filter { get; set; } = new WhatWeDeliveredFilter();
        public IPagedList<WhatWeDelivered> List { get; set; }
    }
}