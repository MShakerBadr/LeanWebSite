using lean.UI.Models.DTOs;
using lean.UI.Models.Entities;
using lean.UI.Repositories;
using PagedList;
using System.IO;
using System.Web;

namespace lean.UI.Services
{
    public class ManagmentService : BaseService<Managment, ManagmentFilter>
    {
        private readonly BaseRepository _repo;

        public ManagmentService(BaseRepository repo) : base(repo)
        {
            _repo = repo;
        }


        public override IPagedList<Managment> FilterPage(ManagmentFilter filter, int pageNumber)
        {
            var Managments = base.GetPageWhere(pageNumber, x =>
                      (string.IsNullOrEmpty(filter.Name) || x.NameAr.Contains(filter.Name) || x.NameEn.Contains(filter.Name)) &&
                      (string.IsNullOrEmpty(filter.Position) || x.PositionAr.Contains(filter.Position) || x.PositionEn.Contains(filter.Position))
               );
            return Managments;
        }

        public Managment GetManagment(long id)
        {
            if (id == 0)
            {
                return new Managment();
            }
            else
            {
                var Managment = FirstOrDefault(x => x.Id == id);
                return Managment;
            }
        }

        public bool SaveManagment(Managment Managment)
        {
            StringWriter DescriptionArWriter = new StringWriter();
            HttpUtility.HtmlDecode(Managment.DescriptionAr, DescriptionArWriter); Managment.DescriptionAr = DescriptionArWriter.ToString();

            StringWriter DescriptionEnWriter = new StringWriter();
            HttpUtility.HtmlDecode(Managment.DescriptionEn, DescriptionEnWriter); Managment.DescriptionEn = DescriptionEnWriter.ToString();

            return Save(Managment);
        }
    }
}
