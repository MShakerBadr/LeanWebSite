using lean.UI.Filters;
using lean.UI.Helpers.Models;
using lean.UI.LocalResources;
using lean.UI.Models.DTOs;
using lean.UI.Models.Entities;
using lean.UI.Services;
using System.Web.Mvc;

namespace lean.UI.Controllers
{
    public class ContactUsReasonController : BaseAuthorizedController
    {
        private readonly ContactUsReasonService _contactUsReasonService;

        public ContactUsReasonController(ContactUsReasonService contactUsReasonService)
        {
            _contactUsReasonService = contactUsReasonService;
        }

        [HttpGet]
        public ActionResult Index(ContactUsReasonFilter filter, int page = 1)
        {
            var model = _contactUsReasonService.FilterPage(filter, page);
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Views/ContactUsReason/Partial/ContactUsReasonList.cshtml", model);
            }

            return View(new ContactUsReasonViewModel
            {
                Filter = filter,
                List = model,
            });
        }

        [HttpGet]
        [AjaxOnly]
        public ActionResult ContactUsReasonPartial(long Id)
        {
            var model = Id == 0 ? new ContactUsReason() : _contactUsReasonService.FirstOrDefault(Id);

            return PartialView("~/Views/ContactUsReason/Partial/ContactUsReasonData.cshtml", model);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult Save(ContactUsReason ContactUsReason)
        {
            var res = _contactUsReasonService.Save(ContactUsReason);
            return Json(new Response { Success = res, Message = res ? Resource.SavedSuccessfully : Resource.ErrorsOccurred});
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult Delete(long Id)
        {
            _contactUsReasonService.Remove(Id);
            var res = _contactUsReasonService.SaveChanges();
            return Json(new Response { Success = res, Message = res ? Resource.DeletedSuccessfully : Resource.ErrorsOccurred });
        }
    }
}