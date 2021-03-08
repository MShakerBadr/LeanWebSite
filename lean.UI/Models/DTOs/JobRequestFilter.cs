using System;

namespace lean.UI.Models.DTOs
{
    public class JobRequestFilter
    {
        public string Email { get; set; }

        public string MobileNumber { get; set; }

        public Nullable<long> AvilableJobId { get; set; }
    }
}