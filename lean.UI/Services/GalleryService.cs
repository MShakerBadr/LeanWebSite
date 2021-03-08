using lean.UI.Models.DTOs;
using lean.UI.Models.Entities;
using lean.UI.Repositories;
using PagedList;

namespace lean.UI.Services
{
    public class GalleryService : BaseService<Gallery, GalleryFilter>
    {
        public GalleryService(BaseRepository repo) : base(repo)
        {

        }


        public override IPagedList<Gallery> FilterPage(GalleryFilter filter, int pageNumber)
        {
            var Managments = base.GetPageWhere(pageNumber, x =>
                      (string.IsNullOrEmpty(filter.Name) || x.AttchmentNameAr.Contains(filter.Name) || x.AttchmentNameEn.Contains(filter.Name)) &&
                      (filter.IsVideo == null || x.IsVideo == filter.IsVideo)
               );
            return Managments;
        }

    }
}
