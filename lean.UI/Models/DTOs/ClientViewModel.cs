using lean.UI.Models.Entities;
using PagedList;

namespace lean.UI.Models.DTOs
{
    public class ClientViewModel
    {
        public ClientFilter Filter { get; set; } = new ClientFilter();
        public IPagedList<Clients> List { get; set; }
    }
}