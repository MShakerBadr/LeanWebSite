using lean.UI.Models.Entities;
using PagedList;

namespace lean.UI.Models.DTOs
{
    public class GalleryViewModel
    {
        public GalleryFilter Filter { get; set; } = new GalleryFilter();
        public IPagedList<Gallery> List { get; set; }
    }
}