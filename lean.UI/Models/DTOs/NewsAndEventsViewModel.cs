using lean.UI.Models.Entities;
using PagedList;

namespace lean.UI.Models.DTOs
{
    public class NewsAndEventsViewModel
    {
        public NewsAndEventsFilter Filter { get; set; } = new NewsAndEventsFilter();
        public IPagedList<NewsAndEvents> List { get; set; }
    }
}