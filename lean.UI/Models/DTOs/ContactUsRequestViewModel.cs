using lean.UI.Models.Entities;
using PagedList;

namespace lean.UI.Models.DTOs
{
    public class ContactUsRequestViewModel
    {
        public ContactUsRequestFilter Filter { get; set; } = new ContactUsRequestFilter();
        public IPagedList<ContactUsRequest> List { get; set; }
    }
}