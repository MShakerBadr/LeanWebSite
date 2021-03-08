using lean.UI.Models.Entities;
using PagedList;

namespace lean.UI.Models.DTOs
{
    public class LocationViewModel
    {
        public LocationFilter Filter { get; set; } = new LocationFilter();
        public IPagedList<Location> List { get; set; }
    }
}