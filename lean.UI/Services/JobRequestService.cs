using lean.UI.Helpers.Methods;
using lean.UI.Models.DTOs;
using lean.UI.Models.Entities;
using lean.UI.Repositories;
using PagedList;
using System;

namespace lean.UI.Services
{
    public class JobRequestService : BaseService<JobRequest, JobRequestFilter>
    {
        private readonly BaseRepository _repo;

        public JobRequestService(BaseRepository repo) : base(repo)
        {
            _repo = repo;
        }

        public override IPagedList<JobRequest> FilterPage(JobRequestFilter filter, int pageNumber)
        {
            return base.GetPageWhere(pageNumber, x =>
                   (string.IsNullOrEmpty(filter.Email) || x.Email.Contains(filter.Email)) &&
                   (string.IsNullOrEmpty(filter.MobileNumber) || x.MobileNumber.Contains(filter.MobileNumber)) &&
                   (filter.AvilableJobId == null || x.AvilableJobId == filter.AvilableJobId),
                    x => x.AvilableJob
               );
        }
        public bool AddContactUsRequest(JobRequest request)
        {
            request.RequestDate = DateTime.UtcNow;
            _repo.Add(request);
            bool result = _repo.SaveChanges();
            
            return result;
        }
    }
}