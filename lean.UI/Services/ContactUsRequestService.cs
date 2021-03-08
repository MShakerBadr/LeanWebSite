using lean.UI.Helpers.Methods;
using lean.UI.Models.DTOs;
using lean.UI.Models.Entities;
using lean.UI.Repositories;
using PagedList;
using System;

namespace lean.UI.Services
{
    public class ContactUsRequestService : BaseService<ContactUsRequest, ContactUsRequestFilter>
    {
        private readonly BaseRepository _repo;

        public ContactUsRequestService(BaseRepository repo) : base(repo)
        {
            _repo = repo;
        }
        public override IPagedList<ContactUsRequest> FilterPage(ContactUsRequestFilter filter, int pageNumber)
        {
            return base.GetPageWhere(pageNumber, x =>
                    (string.IsNullOrEmpty(filter.Email) || x.Email.Contains(filter.Email)) &&
                    (string.IsNullOrEmpty(filter.MobileNumber) || x.MobileNumber.Contains(filter.MobileNumber)) &&
                    (filter.ContactUsReasonId == null || x.ContactUsReasonId == filter.ContactUsReasonId),
                     x => x.ContactUsReason
                );

        }

        public ContactUsRequest GetContactUsRequest(long id)
        {
            return FirstOrDefault(x => x.Id == id, x => x.ContactUsReason);
        }

        public bool AddContactUsRequest(ContactUsRequest request)
        {
            request.RequestDate = DateTime.UtcNow;
            _repo.Add(request);
            
            return _repo.SaveChanges();
        }

    }
}