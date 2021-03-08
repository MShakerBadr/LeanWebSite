using lean.UI.Models.DTOs;
using lean.UI.Models.Entities;
using lean.UI.Repositories;
using PagedList;

namespace lean.UI.Services
{
    public class AboutUsService : BaseService<AboutUs, AboutUsFilter>
    {
        public AboutUsService(BaseRepository repo) : base(repo)
        {

        }

        public override IPagedList<AboutUs> FilterPage(AboutUsFilter filter, int pageNumber)
        {
            return base.GetPageWhere(pageNumber, x =>
                      (string.IsNullOrEmpty(filter.Name) || x.TitleAr.Contains(filter.Name) || x.TitleEn.Contains(filter.Name)));
        }
    }
}
