using lean.UI.Filters;
using lean.UI.Helpers.Methods;
using lean.UI.Helpers.Models;
using lean.UI.LocalResources;
using lean.UI.Models.DTOs;
using lean.UI.Models.Entities;
using lean.UI.Services;
using System;
using System.Web.Hosting;
using System.Web.Mvc;

namespace lean.UI.Controllers
{
    public class ContactUsRequestController : BaseAuthorizedController
    {
        private readonly ContactUsRequestService _contactUsRequestService;
        private readonly ContactUsReasonService _contactUsReasonService;

        public ContactUsRequestController(ContactUsRequestService contactUsRequestService, ContactUsReasonService contactUsReasonService)
        {
            _contactUsRequestService = contactUsRequestService;
            _contactUsReasonService = contactUsReasonService;
        }

        [HttpGet]
        public ActionResult Index(ContactUsRequestFilter filter, int page = 1)
        {
            var model = _contactUsRequestService.FilterPage(filter, page);
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Views/ContactUsRequest/Partial/ContactUsRequestList.cshtml", model);
            }
            else
            {
                ViewBag.ContactUsReasons = new SelectList(_contactUsReasonService.GetAll(), "Id", "Name");
            }

            return View(new ContactUsRequestViewModel
            {
                Filter = filter,
                List = model,
            });
        }

        [HttpGet]
        [AjaxOnly]
        public ActionResult ContactUsRequestPartial(long Id)
        {
            var model = Id == 0 ? new ContactUsRequest() : _contactUsRequestService.GetContactUsRequest(Id);

            return PartialView("~/Views/ContactUsRequest/Partial/ContactUsRequestData.cshtml", model);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult Delete(long Id)
        {
            _contactUsRequestService.Remove(Id);
            var res = _contactUsRequestService.SaveChanges();
            return Json(new Response { Success = res, Message = res ? Resource.DeletedSuccessfully : Resource.ErrorsOccurred });
        }

        [HttpPost]
        [AllowAnonymous]
        [AjaxOnly]
        public  ActionResult AddContactUsRequest(ContactUsRequest request)
        {
            request.RequestDate = System.DateTime.UtcNow;
            var res = _contactUsRequestService.AddContactUsRequest(request);
            //return RedirectToAction("Home", "Home");
            return Json(new Response { Success = res, Message = res ? Resource.SandSuccessfully : Resource.ErrorsOccurred });
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult AddEmailNotificationRequest(ContactUsRequest request, int type = 1)
        {
            try
            {
                //Task.Run(() => SMTPHelper.SendGridMail());
                ContactUsInfoMail newsLetterMail = new ContactUsInfoMail();
                if (type == 1)
                {
                    request.ContactUsReasonTextEn = "Email NotificationRequest";
                    request.ContactUsReasonTextAr = "طلب اشعار البريد الإلكترونى";
                    newsLetterMail.MailSubject = $"{request.ContactUsReasonTextEn} - {request.ContactUsReasonTextAr}";
                    newsLetterMail.MailType = $"{request.ContactUsReasonTextEn} - {request.ContactUsReasonTextAr}";
                }
                else
                {
                    //request.ContactUsReasonTextEn = "sunscription request";
                    //request.ContactUsReasonTextAr = "طلب إشتراك";
                    //newsLetterMail.MailSubject = $"{request.ContactUsReasonTextEn} - {request.ContactUsReasonTextAr}";
                    //newsLetterMail.MailType = $"{request.ContactUsReasonTextEn} - {request.ContactUsReasonTextAr}";
                }

                request.RequestDate = System.DateTime.UtcNow;
                request.Message = "-";
                request.Name = "-";
                request.MobileNumber = "-";
                _contactUsRequestService.AddContactUsRequest(request);


            }
            catch (Exception ex)
            {
                var path = HostingEnvironment.MapPath("~/ErrorTxt/errorFile.txt");
                System.IO.File.WriteAllText(path, ex.Message);
            }
           
                return RedirectToAction("Home", "Home");
           
        }


        [HttpPost]
        [AllowAnonymous]
        [AjaxOnly]
        public ActionResult AddProjectRequest(ContactUsRequest request)
        {
            request.ContactUsReasonTextEn = "Project Request";
            request.ContactUsReasonTextAr = "طلب مشروع";
            request.RequestDate = System.DateTime.UtcNow;
            var res = _contactUsRequestService.AddContactUsRequest(request);

            if (res) //if true  ==> insert the same request to MySql DataBase to Trigger MailService to Send Mail from (MySql DataBase)
            {
                var result = MySQLTransactions.InsertIntoContactUsRequest(request);
            }

            return Json(new Response { Success = res, Message = res ? Resource.SandSuccessfully : Resource.ErrorsOccurred });
        }

    }
}