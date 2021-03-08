using lean.UI.Models.DTOs;
using lean.UI.Models.Entities;
using lean.UI.Repositories;
using PagedList;

namespace lean.UI.Services
{
    public class WhatWeDeliveredService : BaseService< WhatWeDelivered,  WhatWeDeliveredFilter>
    {
        public WhatWeDeliveredService(BaseRepository repo) : base(repo)
        {

        }

        public override IPagedList< WhatWeDelivered> FilterPage( WhatWeDeliveredFilter filter, int pageNumber)
        {
            return base.GetPageWhere(pageNumber, x =>
                      (string.IsNullOrEmpty(filter.Name) || x.NameAr.Contains(filter.Name) || x.NameEn.Contains(filter.Name)) &&
                      (string.IsNullOrEmpty(filter.Location) || x.LocationAr.Contains(filter.Location) || x.LocationEn.Contains(filter.Location)) &&
                      (string.IsNullOrEmpty(filter.Description) || x.DescriptionAr.Contains(filter.Description) || x.DescriptionEn.Contains(filter.Description)) 
               );
        }
    }
}