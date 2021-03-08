using lean.UI.Filters;
using lean.UI.Helpers.Models;
using lean.UI.Models.DTOs;
using lean.UI.Models.Entities;
using lean.UI.Services;
using System.Web.Mvc;
using lean.UI.LocalResources;
using lean.UI.Repositories;
using System.Linq;


namespace lean.UI.Controllers
{
    public class ClientController : BaseAuthorizedController
    {
        private readonly BaseRepository _baseRepository;
        private readonly ClientService _clientService;
        private readonly FileService _fileService;

        public ClientController(ClientService clientService, FileService fileService, BaseRepository baseRepository)
        {
            _clientService = clientService;
            _fileService = fileService;
            _baseRepository = baseRepository;
           
        }



        [HttpGet]
        public ActionResult Home(ClientFilter filter, int page = 1)
        {
            var model = _clientService.FilterPage(filter, page);
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Views/Client/Partial/ClientList.cshtml", model);
            }

            return View(new ClientViewModel
            {
                Filter = filter,
                List = model,
            });
        }

        [HttpGet]
        [AjaxOnly]
        public ActionResult ClientPartial(long Id)
        {
            var model = Id == 0 ? new Clients() : _clientService.FirstOrDefault(Id);

            return PartialView("~/Views/Client/Partial/ClientData.cshtml", model);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult Save(Clients newsAndEvents)
        {
            var res = _clientService.Save(newsAndEvents);
            return Json(new Response
            {
                Success = res,
                Message = res ? Resource.SavedSuccessfully : Resource.ErrorsOccurred,
                Data = new { WhatWeDeliveredId = newsAndEvents.Id }
            });
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult SaveClientPhoto(long whyusId)
        {
            var files = Request.Files;
            var uploaded = _fileService.UploadFile(MyConstants.UploadsPath, files[0]);

            Clients newsAndEvents = _clientService.FirstOrDefault(x => x.Id == whyusId);
            newsAndEvents.imgUrl = uploaded.Path;

            _clientService.Update(newsAndEvents);
            _clientService.SaveChanges();
            return Json(true);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult Delete(long Id)
        {
            _clientService.Remove(Id);
            var res = _clientService.SaveChanges();
            return Json(new Response { Success = res, Message = res ? Resource.DeletedSuccessfully : Resource.ErrorsOccurred });
        }

        //[HttpPost]
        //[AjaxOnly]
        //public ActionResult UploadWhyUsAttachment(long whyUsId)
        //{
        //    var files = Request.Files;
        //    var uploaded = _fileService.UploadFiles(MyConstants.UploadsPath, files);

        //    foreach (var item in uploaded)
        //    {
        //        _baseRepository.Add(new WhyUSGalleries
        //        {
        //            WhyUsId = whyUsId,
        //            AttachmentUrl = item.Path,
        //            IsVideo = false,
        //        });
        //    }
        //    return Json(_baseRepository.SaveChanges());
        //}

        //[HttpGet]
        //[AjaxOnly]
        //public ActionResult LoaDeliveredAttachmentImages(int whyUsId)
        //{
        //    var model = _baseRepository.GetAllWhere<WhyUSGalleries>(x => x.WhyUsId == whyUsId && x.IsVideo == false).ToList();
        //    return PartialView("~/Views/WhyUs/Partial/LoaDeliveredAttachmentImages.cshtml", model);
        //}


        //[HttpPost]
        //[AjaxOnly]
        //public ActionResult RemoveWhyUSAttachmentImg(long imgId)
        //{
        //    var model = _baseRepository.FirstOrDefault<WhyUSGalleries>(x => x.Id == imgId);
        //    if (model != null)
        //    {
        //        _baseRepository.Remove<WhyUSGalleries>(model);
        //        _baseRepository.SaveChanges();
        //    }
        //    return Json(true);
        //}

    }
}