using lean.UI.Models.DTOs;
using lean.UI.Models.Entities;
using lean.UI.Repositories;
using PagedList;

namespace lean.UI.Services
{
    public class ConstructionUpdatesService : BaseService< ConstructionUpdates,  ConstructionUpdatesFilter>
    {
        public ConstructionUpdatesService(BaseRepository repo) : base(repo)
        {

        }

        public override IPagedList< ConstructionUpdates> FilterPage(ConstructionUpdatesFilter filter, int pageNumber)
        {
            return base.GetPageWhere(pageNumber, x =>
                      (string.IsNullOrEmpty(filter.Name) || x.NameAr.Contains(filter.Name) || x.NameEn.Contains(filter.Name)) 
               );
        }
    }
}