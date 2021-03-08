using lean.UI.Models.Entities;
using PagedList;

namespace lean.UI.Models.DTOs
{
    public class SliderViewModel
    {
        public SliderFilter Filter { get; set; } = new SliderFilter();
        public IPagedList<Slider> List { get; set; }
    }
}