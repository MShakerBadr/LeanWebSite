using lean.UI.Models.Entities;
using lean.UI.Repositories;

namespace lean.UI.Services
{
    public class StaticContentService : BaseService<StaticContent, StaticContent>
    {
        public StaticContentService(BaseRepository repo) :base(repo)
        {

        }
    }
}