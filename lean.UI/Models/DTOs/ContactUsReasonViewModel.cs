using lean.UI.Models.Entities;
using PagedList;

namespace lean.UI.Models.DTOs
{
    public class ContactUsReasonViewModel
    {
        public ContactUsReasonFilter Filter { get; set; } = new ContactUsReasonFilter();
        public IPagedList<ContactUsReason> List { get; set; }
    }
}