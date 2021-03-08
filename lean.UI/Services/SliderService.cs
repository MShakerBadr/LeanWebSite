using lean.UI.Models.DTOs;
using lean.UI.Models.Entities;
using lean.UI.Repositories;
using PagedList;

namespace lean.UI.Services
{
    public class SliderService : BaseService<Slider, SliderFilter>
    {
        private readonly BaseRepository _repo;

        public SliderService(BaseRepository repo) : base(repo)
        {
            _repo = repo;
        }


        public override IPagedList<Slider> FilterPage(SliderFilter filter, int pageNumber)
        {
            var Slider = base.GetPageWhere(pageNumber, x =>
                      (string.IsNullOrEmpty(filter.Name) || x.NameAr.Contains(filter.Name) || x.NameEn.Contains(filter.Name)) 
                    
               );
            return Slider;
        }

        public Slider GetSlider(long id)
        {
            if (id == 0)
            {
                return new Slider();
            }
            else
            {
                var Slider = FirstOrDefault(x => x.Id == id);
                return Slider;
            }
        }

        public bool SaveSlider(Slider slider)
        {
            return Save(slider);
        }
    }
}
