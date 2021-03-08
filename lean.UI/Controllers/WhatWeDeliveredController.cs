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
    public class WhatWeDeliveredController : BaseAuthorizedController
    {
        private readonly BaseRepository _baseRepository;
        private readonly WhatWeDeliveredService _whatWeDeliveredService;
        private readonly FileService _fileService;

        public WhatWeDeliveredController(WhatWeDeliveredService whatWeDeliveredService, FileService fileService, BaseRepository baseRepository)
        {
            _whatWeDeliveredService = whatWeDeliveredService;
            _fileService = fileService;
            _baseRepository = baseRepository;
           
        }



        [HttpGet]
        public ActionResult Home(WhatWeDeliveredFilter filter, int page = 1)
        {
            var model = _whatWeDeliveredService.FilterPage(filter, page);
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Views/WhatWeDelivered/Partial/WhatWeDeliveredList.cshtml", model);
            }

            return View(new WhatWeDeliveredViewModel
            {
                Filter = filter,
                List = model,
            });
        }

        [HttpGet]
        [AjaxOnly]
        public ActionResult WhatWeDeliveredPartial(long Id)
        {
            var model = Id == 0 ? new WhatWeDelivered() : _whatWeDeliveredService.FirstOrDefault(Id);

            return PartialView("~/Views/WhatWeDelivered/Partial/WhatWeDeliveredData.cshtml", model);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult Save(WhatWeDelivered newsAndEvents)
        {
            var res = _whatWeDeliveredService.Save(newsAndEvents);
            return Json(new Response
            {
                Success = res,
                Message = res ? Resource.SavedSuccessfully : Resource.ErrorsOccurred,
                Data = new { WhatWeDeliveredId = newsAndEvents.Id }
            });
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult SaveWhatWeDeliveredPhoto(long WhatWeDeliveredId)
        {
            var files = Request.Files;
            var uploaded = _fileService.UploadFile(MyConstants.UploadsPath, files[0]);

            WhatWeDelivered newsAndEvents = _whatWeDeliveredService.FirstOrDefault(x => x.Id == WhatWeDeliveredId);
            newsAndEvents.ImageUrl = uploaded.Path;

            _whatWeDeliveredService.Update(newsAndEvents);
            _whatWeDeliveredService.SaveChanges();
            return Json(true);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult Delete(long Id)
        {
            _whatWeDeliveredService.Remove(Id);
            var res = _whatWeDeliveredService.SaveChanges();
            return Json(new Response { Success = res, Message = res ? Resource.DeletedSuccessfully : Resource.ErrorsOccurred });
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult UploadWhatWeDeliveredAttachment(long WhatWeDeliveredId)
        {
            var files = Request.Files;
            var uploaded = _fileService.UploadFiles(MyConstants.UploadsPath, files);

            foreach (var item in uploaded)
            {
                _baseRepository.Add(new WhatWeDeliveredGallery
                {
                    WhatWeDeliveredId = WhatWeDeliveredId,
                    AttachmentUrl = item.Path,
                    IsVideo = false,
                });
            }
            return Json(_baseRepository.SaveChanges());
        }

        [HttpGet]
        [AjaxOnly]
        public ActionResult LoadWhatWeDeliveredAttachmentImages(int WhatWeDeliveredId)
        {
            var model = _baseRepository.GetAllWhere<WhatWeDeliveredGallery>(x => x.WhatWeDeliveredId == WhatWeDeliveredId && x.IsVideo == false).ToList();
            return PartialView("~/Views/WhatWeDelivered/Partial/LoaDeliveredAttachmentImages.cshtml", model);
        }


        [HttpPost]
        [AjaxOnly]
        public ActionResult RemoveWhatWeDeliveredAttachmentImg(long imgId)
        {
            var model = _baseRepository.FirstOrDefault<WhatWeDeliveredGallery>(x => x.Id == imgId);
            if (model != null)
            {
                _baseRepository.Remove<WhatWeDeliveredGallery>(model);
                _baseRepository.SaveChanges();
            }
            return Json(true);
        }

    }
}