using lean.UI.Models.Entities;
using System.Collections.Generic;

namespace lean.UI.Models.DTOs
{
    public class ConstructionUpdatesProject
    {
        public long ProjectId { get; set; }
        public List<ConstructionUpdates> constructionUpdates { get; set; }
    }
}