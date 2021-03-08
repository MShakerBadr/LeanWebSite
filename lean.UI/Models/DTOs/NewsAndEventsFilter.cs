using System;

namespace lean.UI.Models.DTOs
{
    public class NewsAndEventsFilter
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Nullable<bool> IsEvent { get; set; }

    }
}