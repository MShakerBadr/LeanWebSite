using lean.UI.Models.Entities;
using PagedList;

namespace lean.UI.Models.DTOs
{
    public class ProjectViewModel
    {
        public ProjectFilter Filter { get; set; } = new ProjectFilter();
        public IPagedList<Project> List { get; set; }
    }
}