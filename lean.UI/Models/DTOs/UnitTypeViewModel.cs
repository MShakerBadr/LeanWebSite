using lean.UI.Models.Entities;
using PagedList;

namespace lean.UI.Models.DTOs
{
    public class UnitTypeViewModel
    {
        public UnitTypeFilter Filter { get; set; } = new UnitTypeFilter();
        public IPagedList<UnitType> List { get; set; }
    }
}