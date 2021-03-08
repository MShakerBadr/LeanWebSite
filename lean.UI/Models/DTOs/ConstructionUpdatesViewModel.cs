using lean.UI.Models.Entities;
using PagedList;

namespace lean.UI.Models.DTOs
{
    public class ConstructionUpdatesViewModel
    {
        public ConstructionUpdatesFilter Filter { get; set; } = new ConstructionUpdatesFilter();
        public IPagedList<ConstructionUpdates> List { get; set; }
    }
}