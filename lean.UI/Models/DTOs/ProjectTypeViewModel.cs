using lean.UI.Models.Entities;
using PagedList;

namespace lean.UI.Models.DTOs
{
    public class ProjectTypeViewModel
    {
        public ProjectTypeFilter Filter { get; set; } = new ProjectTypeFilter();
        public IPagedList<ProjectType> List { get; set; }
    }
}