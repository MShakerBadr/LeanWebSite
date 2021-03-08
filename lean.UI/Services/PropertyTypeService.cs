using lean.UI.Models.DTOs;
using lean.UI.Models.Entities;
using lean.UI.Repositories;
using PagedList;

namespace lean.UI.Services
{
    public class PropertyTypeService : BaseService<PropertyType, PropertyTypeFilter>
    {
        public PropertyTypeService(BaseRepository repo) : base(repo)
        {

        }

        public override IPagedList<PropertyType> FilterPage(PropertyTypeFilter filter, int pageNumber)
        {
            return base.GetPageWhere(pageNumber, x =>
                    (string.IsNullOrEmpty(filter.Name) || x.NameAr.Contains(filter.Name) || x.NameEn.Contains(filter.Name))
               );
        }
    }
}