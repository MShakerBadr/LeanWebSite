using lean.UI.Filters;
using lean.UI.Helpers.Models;
using lean.UI.LocalResources;
using lean.UI.Models.DTOs;
using lean.UI.Models.Entities;
using lean.UI.Repositories;
using lean.UI.Services;
using System.Linq;
using System.Web.Mvc;

namespace lean.UI.Controllers
{
    public class NewsAndEventsController : BaseAuthorizedController
    {
        private readonly BaseRepository _baseRepository;
        private readonly NewsAndEventsService _newsEventService;
        private readonly FileService _fileService;
        public NewsAndEventsController(NewsAndEventsService NewsEventService, FileService fileService, BaseRepository baseRepository)
        {
            _newsEventService = NewsEventService;
            _fileService = fileService;
            _baseRepository = baseRepository;

        }



        [HttpGet]
        public ActionResult Index(NewsAndEventsFilter filter, int page = 1)
        {
            var model = _newsEventService.FilterPage(filter, page);
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Views/NewsAndEvents/Partial/NewsAndEventsList.cshtml", model);
            }

            return View(new NewsAndEventsViewModel
            {
                Filter = filter,
                List = model,
            });
        }

        [HttpGet]
        [AjaxOnly]
        public ActionResult NewsAndEventsPartial(long Id)
        {
            var model = Id == 0 ? new NewsAndEvents() : _newsEventService.FirstOrDefault(x => x.Id == Id, x => x.NewsAndEventsGallery);

            return PartialView("~/Views/NewsAndEvents/Partial/NewsAndEventsData.cshtml", model);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult Save(NewsAndEvents newsAndEvents)
        {
            var res = _newsEventService.Save(newsAndEvents);
            return Json(new Response
            {
                Success = res,
                Message = res ? Resource.SavedSuccessfully : Resource.ErrorsOccurred,
                Data = new { NewsAndEventsId = newsAndEvents.Id }
            });
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult SaveNewsAndEventsPhoto(long NewsAndEventsId)
        {
            var files = Request.Files;
            var uploaded = _fileService.UploadFile(MyConstants.UploadsPath, files[0]);

            NewsAndEvents newsAndEvents = _newsEventService.FirstOrDefault(x => x.Id == NewsAndEventsId);
            newsAndEvents.AttachmentUrl = uploaded.Path;

            _newsEventService.Update(newsAndEvents);
            _newsEventService.SaveChanges();
            return Json(true);
        }



        [HttpPost]
        [AjaxOnly]
        public ActionResult UploadNewsAndEventsAttachment(long NewsAndEventsId)
        {
            var files = Request.Files;
            var uploaded = _fileService.UploadFiles(MyConstants.UploadsPath, files);

            foreach (var item in uploaded)
            {
                _baseRepository.Add(new NewsAndEventsGallery
                {
                    NewsAndEventsId = NewsAndEventsId,
                    AttachmentUrl = item.Path,
                    IsVideo = false,
                });
            }
            return Json(_baseRepository.SaveChanges());
        }

        [HttpGet]
        [AjaxOnly]
        public ActionResult LoadNewsAndEventsAttachmentImages(int newsAndEventId)
        {
            var model = _baseRepository.GetAllWhere<NewsAndEventsGallery>(x => x.NewsAndEventsId == newsAndEventId && x.IsVideo == false).ToList();
            return PartialView("~/Views/NewsAndEvents/Partial/LoadNewsAndEventsAttachmentImages.cshtml", model);
        }


        [HttpPost]
        [AjaxOnly]
        public ActionResult RemoveNewsAndEventsAttachmentImg(long imgId)
        {
            var model = _baseRepository.FirstOrDefault<NewsAndEventsGallery>(x => x.Id == imgId);
            if (model != null)
            {
                _baseRepository.Remove<NewsAndEventsGallery>(model);
                _baseRepository.SaveChanges();
            }
            return Json(true);
        }
        [HttpPost]
        [AjaxOnly]
        public ActionResult UploadNewsAndEventsVideo(long NewsAndEventsId, string url)
        {
            var lastIndex = url.LastIndexOf("=") > 0 ? url.LastIndexOf("=") : url.LastIndexOf("/");
            string videoUrl = "https://www.youtube.com/embed/" + url.Substring(lastIndex + 1);
            _baseRepository.Add(new NewsAndEventsGallery
            {
                NewsAndEventsId = NewsAndEventsId,
                AttachmentUrl = videoUrl,
                IsVideo = true,
                AttachmentFullUrl = url,
            }); ;
            return Json(_baseRepository.SaveChanges());
        }
        [HttpGet]
        [AjaxOnly]
        public ActionResult LoadNewsAndEventsAttachmentVideos(int newsAndEventId)
        {
            var model = _baseRepository.GetAllWhere<NewsAndEventsGallery>(x => x.NewsAndEventsId == newsAndEventId && x.IsVideo == true).ToList();
            return PartialView("~/Views/NewsAndEvents/Partial/LoadNewsAndEventsAttachmentVideos.cshtml", model);
        }

       
        [HttpPost]
        [AjaxOnly]
        public ActionResult Delete(long Id)
        {
            _newsEventService.Remove(Id);
            var res = _newsEventService.SaveChanges();
            return Json(new Response { Success = res, Message = res ? Resource.DeletedSuccessfully : Resource.ErrorsOccurred });
        }
    }
}