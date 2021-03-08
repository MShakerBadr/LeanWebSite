using System;

namespace lean.UI.Models.DTOs
{
    public class ProjectFilter
    {
        public Nullable<long> ProjectTypeId { get; set; }
        public Nullable<long> PropertyTypeId { get; set; }
        public Nullable<long> UnitTypeId { get; set; }
        public Nullable<long> LocationId { get; set; }
        public Nullable<bool> IsSpecialProject { get; set; }
    }
}