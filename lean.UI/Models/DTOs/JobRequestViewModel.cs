using lean.UI.Models.Entities;
using PagedList;

namespace lean.UI.Models.DTOs
{
    public class JobRequestViewModel
    {
        public JobRequestFilter Filter { get; set; } = new JobRequestFilter();
        public IPagedList<JobRequest> List { get; set; }
    }
}