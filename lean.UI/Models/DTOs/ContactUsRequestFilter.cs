using System;

namespace lean.UI.Models.DTOs
{
    public class ContactUsRequestFilter
    {
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public Nullable<long> ContactUsReasonId { get; set; }
    }
}