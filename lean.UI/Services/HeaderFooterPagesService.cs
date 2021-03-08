using lean.UI.Models.DTOs;
using lean.UI.Models.Entities;
using lean.UI.Repositories;
using PagedList;

namespace lean.UI.Services
{
    public class HeaderFooterPagesService : BaseService<HeaderFooterPages, HeaderFooterPagesFilter>
    {
        private readonly BaseRepository _repo;

        public HeaderFooterPagesService(BaseRepository repo) : base(repo)
        {
            _repo = repo;
        }



        public override IPagedList<HeaderFooterPages> FilterPage(HeaderFooterPagesFilter filter, int pageNumber)
        {
            var res = base.GetPageWhere(pageNumber, x => (filter.IsHeader == null || x.IsHeader == filter.IsHeader));
            return res;
        }
    }
}