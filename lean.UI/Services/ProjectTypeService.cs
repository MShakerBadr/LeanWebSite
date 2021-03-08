using lean.UI.Helpers.Models;
using lean.UI.Models.DTOs;
using lean.UI.Models.Entities;
using lean.UI.Repositories;
using PagedList;
using System.Collections.Generic;
using System.Linq;

namespace lean.UI.Services
{
    public class ProjectTypeService : BaseService
    {
        private readonly BaseRepository _repo;

        public ProjectTypeService(BaseRepository repo)
        {
            _repo = repo;
        }


        public List<ProjectType> GetAll()
        {
            return _repo.GetAll<ProjectType>();
        }

        public IPagedList<ProjectType> FilterPage(ProjectTypeFilter filter, int pageNumber)
        {
            return _repo.GetQueryWhere<ProjectType>(x =>
                    (string.IsNullOrEmpty(filter.Name) || x.NameAr.Contains(filter.Name) || x.NameEn.Contains(filter.Name))
               ).OrderBy(x => x.Id)
               .ToPagedList(pageNumber, MyConstants.PageSize10);
        }
    }
}