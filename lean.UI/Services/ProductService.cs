using lean.UI.Models.DTOs;
using lean.UI.Models.Entities;
using lean.UI.Repositories;
using PagedList;

namespace lean.UI.Services
{
    public class ProductService : BaseService<Product, ProductFilter>
    {
        public ProductService(BaseRepository repo) : base(repo)
        {

        }

        public override IPagedList<Product> FilterPage(ProductFilter filter, int pageNumber)
        {
            return base.GetPageWhere(pageNumber, x =>
                      (string.IsNullOrEmpty(filter.Name) || x.TitleAr.Contains(filter.Name) || x.TitleEn.Contains(filter.Name)));
        }
    }
}
