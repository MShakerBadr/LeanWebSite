using lean.UI.Models.DTOs;
using lean.UI.Models.Entities;
using lean.UI.Repositories;
using PagedList;

namespace lean.UI.Services
{
    public class AvailableJobsService : BaseService<AvilableJob, AvailableJobsFilter>
    {
        public AvailableJobsService(BaseRepository repo):base(repo)
        {

        }

        public override IPagedList<AvilableJob> FilterPage(AvailableJobsFilter filter, int pageNumber)
        {
            return base.GetPageWhere(pageNumber, x =>
                    (string.IsNullOrEmpty(filter.Name) || x.NameAr.Contains(filter.Name) || x.NameEn.Contains(filter.Name))
               );
        }
    }
}