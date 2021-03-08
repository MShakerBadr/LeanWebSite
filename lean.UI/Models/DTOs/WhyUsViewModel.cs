using lean.UI.Models.Entities;
using PagedList;

namespace lean.UI.Models.DTOs
{
    public class WhyUsViewModel
    {
        public WhyUsFilter Filter { get; set; } = new WhyUsFilter();
        public IPagedList<WhyUS> List { get; set; }
    }
}