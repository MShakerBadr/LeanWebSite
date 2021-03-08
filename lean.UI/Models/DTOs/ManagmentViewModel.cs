using lean.UI.Models.Entities;
using PagedList;

namespace lean.UI.Models.DTOs
{
    public class ManagmentViewModel
    {
        public ManagmentFilter Filter { get; set; } = new ManagmentFilter();
        public IPagedList<Managment> List { get; set; }
    }
}