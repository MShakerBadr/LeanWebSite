using lean.UI.Models.DTOs;
using lean.UI.Models.Entities;
using lean.UI.Repositories;
using PagedList;

namespace lean.UI.Services
{
    public class ClientService : BaseService< Clients,  ClientFilter>
    {
        public ClientService(BaseRepository repo) : base(repo)
        {

        }

        public override IPagedList< Clients> FilterPage(ClientFilter filter, int pageNumber)
        {
            return base.GetPageWhere(pageNumber, x =>
                      (string.IsNullOrEmpty(filter.Name) || x.NameAr.Contains(filter.Name) || x.NameEng.Contains(filter.Name)));
        }
    }
}