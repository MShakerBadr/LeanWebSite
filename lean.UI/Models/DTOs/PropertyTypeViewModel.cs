using lean.UI.Models.Entities;
using PagedList;

namespace lean.UI.Models.DTOs
{
    public class PropertyTypeViewModel
    {
        public PropertyTypeFilter Filter { get; set; } = new PropertyTypeFilter();
        public IPagedList<PropertyType> List { get; set; }
    }
}