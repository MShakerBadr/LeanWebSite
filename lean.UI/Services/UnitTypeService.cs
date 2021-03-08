using lean.UI.Models.DTOs;
using lean.UI.Models.Entities;
using lean.UI.Repositories;
using PagedList;

namespace lean.UI.Services
{
    public class UnitTypeService : BaseService<UnitType, UnitTypeFilter>
    {
        public UnitTypeService(BaseRepository repo):base(repo)
        {

        }

        public override IPagedList<UnitType> FilterPage(UnitTypeFilter filter, int pageNumber)
        {
            return base.GetPageWhere(pageNumber, x =>
                    (string.IsNullOrEmpty(filter.Name) || x.NameAr.Contains(filter.Name) || x.NameEn.Contains(filter.Name))
               );
        }
    }
}