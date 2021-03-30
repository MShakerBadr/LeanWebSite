using lean.UI.Helpers.Methods;
using lean.UI.Models.Entities;
using lean.UI.Repositories;
using lean.UI.Services;
using System.Linq;
using System.Web.Mvc;

namespace lean.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly BaseRepository _repo;

        public HomeController(BaseRepository repo, BaseService baseService)
        {
            _repo = repo;
        }


        [HttpGet]
        public ActionResult Home()
        {
            ViewBag.WhatWeDeliver = _repo.GetAll<WhatWeDelivered>().ToList();
            ViewBag.Portfolio = _repo.GetAll<Project>().ToList();
            ViewBag.WhyUs = _repo.GetQueryWhere<WhyUS>(w=>w.IsShow == true).ToList();
            ViewBag.Clients = _repo.GetQueryWhere<Clients>(c => c.IsShow == true).Take(8).ToList();


           
            StaticContent staticContent =_repo.GetAll<StaticContent>().FirstOrDefault();
            ViewBag.StaticContent = staticContent;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.AboutUs = _repo.FirstOrDefault<StaticContent>();
            ViewBag.AboutUsData = _repo.GetAll<AboutUs>();

            return View();
        }

        public ActionResult Contact()
        {
            var ContactReason = _repo.GetAll<ContactUsReason>();
            ContactReason.Insert(0, new ContactUsReason { Id = 0, NameAr = "اختر سبب التواصل ..", NameEn = "Choose Contact Us .." });
            ViewBag.ContactReason = ContactReason.ToSelectList();

            return View("Contact");
        }


        [HttpGet]
        public ActionResult Clients()
        {

            var clients = _repo.GetQueryWhere<Clients>(c => c.IsShow == true).ToList();

            return View(clients);
        }


        [HttpGet]
        public ActionResult Products()
        {
            var Products = _repo.GetAll<Product>().ToList();
            return View(Products);
        }

        [HttpGet]
        public ActionResult Services()
        {
            var services = _repo.GetAll<NewsAndEvents>();
            return View(services);
        }


        public ActionResult WhatWeDeliverd()
        {
            ViewBag.WhatWeDelivered = _repo.GetQuery<StaticContent>().FirstOrDefault().WhatWeDelivered;
            var whatweDelevired = _repo.GetAll<WhatWeDelivered>(x=>x.WhatWeDeliveredGallery).ToList();
            return View(whatweDelevired);
        }
    }
}