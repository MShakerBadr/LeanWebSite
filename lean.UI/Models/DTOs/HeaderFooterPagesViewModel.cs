using lean.UI.Models.Entities;
using PagedList;

namespace lean.UI.Models.DTOs
{
    public class HeaderFooterPagesViewModel
    {
        public HeaderFooterPagesFilter Filter { get; set; } = new HeaderFooterPagesFilter();
        public IPagedList<HeaderFooterPages> List { get; set; }
    }
}