using lean.UI.Models.DTOs;
using lean.UI.Models.Entities;
using lean.UI.Repositories;
using PagedList;

namespace lean.UI.Services
{
    public class WhyUsService : BaseService< WhyUS,  WhyUsFilter>
    {
        public WhyUsService(BaseRepository repo) : base(repo)
        {

        }

        public override IPagedList< WhyUS> FilterPage(WhyUsFilter filter, int pageNumber)
        {
            return base.GetPageWhere(pageNumber, x =>
                      (string.IsNullOrEmpty(filter.Name) || x.TitleAR.Contains(filter.Name) || x.TitleEng.Contains(filter.Name)) &&
                      (string.IsNullOrEmpty(filter.Location)) &&
                      (string.IsNullOrEmpty(filter.Description) || x.DescriptionAr.Contains(filter.Description) || x.DescriptionEng.Contains(filter.Description)) 
               );
        }
    }
}