using lean.UI.Models.Entities;
using PagedList;

namespace lean.UI.Models.DTOs
{
    public class AvailableJobsViewModel
    {
        public AvailableJobsFilter Filter { get; set; } = new AvailableJobsFilter();
        public IPagedList<AvilableJob> List { get; set; }
    }
}