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
    public class WhyUsController : BaseAuthorizedController
    {
        private readonly BaseRepository _baseRepository;
        private readonly WhyUsService _whyUsService;
        private readonly FileService _fileService;

        public WhyUsController(WhyUsService whatWeDeliveredService, FileService fileService, BaseRepository baseRepository)
        {
            _whyUsService = whatWeDeliveredService;
            _fileService = fileService;
            _baseRepository = baseRepository;
           
        }




        [HttpGet]
        public ActionResult Home(WhyUsFilter filter, int page = 1)
        {
            var model = _whyUsService.FilterPage(filter, page);
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Views/WhyUs/Partial/WhatWeDeliveredList.cshtml", model);
            }

            return View(new WhyUsViewModel
            {
                Filter = filter,
                List = model,
            });
        }

        [HttpGet]
        [AjaxOnly]
        public ActionResult WhyUsPartial(long Id)
        {
            var model = Id == 0 ? new WhyUS() : _whyUsService.FirstOrDefault(Id);

            return PartialView("~/Views/WhyUs/Partial/WhatWeDeliveredData.cshtml", model);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult Save(WhyUS newsAndEvents)
        {
            var res = _whyUsService.Save(newsAndEvents);
            return Json(new Response
            {
                Success = res,
                Message = res ? Resource.SavedSuccessfully : Resource.ErrorsOccurred,
                Data = new { WhatWeDeliveredId = newsAndEvents.Id }
            });
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult SaveWhyUsPhoto(long whyusId)
        {
            var files = Request.Files;
            var uploaded = _fileService.UploadFile(MyConstants.UploadsPath, files[0]);

            WhyUS newsAndEvents = _whyUsService.FirstOrDefault(x => x.Id == whyusId);
            newsAndEvents.ImgUrl = uploaded.Path;

            _whyUsService.Update(newsAndEvents);
            _whyUsService.SaveChanges();
            return Json(true);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult Delete(long Id)
        {
            _whyUsService.Remove(Id);
            var res = _whyUsService.SaveChanges();
            return Json(new Response { Success = res, Message = res ? Resource.DeletedSuccessfully : Resource.ErrorsOccurred });
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult UploadWhyUsAttachment(long whyUsId)
        {
            var files = Request.Files;
            var uploaded = _fileService.UploadFiles(MyConstants.UploadsPath, files);

            foreach (var item in uploaded)
            {
                _baseRepository.Add(new WhyUSGalleries
                {
                    WhyUsId = whyUsId,
                    AttachmentUrl = item.Path,
                    IsVideo = false,
                });
            }
            return Json(_baseRepository.SaveChanges());
        }

        [HttpGet]
        [AjaxOnly]
        public ActionResult LoaDeliveredAttachmentImages(int whyUsId)
        {
            var model = _baseRepository.GetAllWhere<WhyUSGalleries>(x => x.WhyUsId == whyUsId && x.IsVideo == false).ToList();
            return PartialView("~/Views/WhyUs/Partial/LoaDeliveredAttachmentImages.cshtml", model);
        }


        [HttpPost]
        [AjaxOnly]
        public ActionResult RemoveWhyUSAttachmentImg(long imgId)
        {
            var model = _baseRepository.FirstOrDefault<WhyUSGalleries>(x => x.Id == imgId);
            if (model != null)
            {
                _baseRepository.Remove<WhyUSGalleries>(model);
                _baseRepository.SaveChanges();
            }
            return Json(true);
        }

    }
}