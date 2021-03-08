using lean.UI.Models.DTOs;
using lean.UI.Models.Entities;
using lean.UI.Repositories;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lean.UI.Services
{
    public class NewsAndEventsService: BaseService<NewsAndEvents, NewsAndEventsFilter>
    {
        public NewsAndEventsService(BaseRepository repo) : base(repo)
        {

        }


        public override IPagedList<NewsAndEvents> FilterPage(NewsAndEventsFilter filter, int pageNumber)
        {
            var Managments = base.GetPageWhere(pageNumber, x =>
                      (string.IsNullOrEmpty(filter.Name) || x.NameAr.Contains(filter.Name) || x.NameEn.Contains(filter.Name)) &&
                      (string.IsNullOrEmpty(filter.Description) || x.DescriptionAr.Contains(filter.Description) || x.DescriptionEn.Contains(filter.Description)) &&
                      (filter.IsEvent == null || x.IsEvent == filter.IsEvent)
               );
            return Managments;
        }
    }
}