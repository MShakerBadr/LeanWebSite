using lean.UI.Filters;
using lean.UI.Helpers.Models;
using lean.UI.Models.DTOs;
using lean.UI.Models.Entities;
using lean.UI.Repositories;
using lean.UI.Services;
using lean.UI.LocalResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace lean.UI.Controllers
{
    public class AboutUsController : BaseAuthorizedController
    {
        private readonly BaseRepository _baseRepository;
        private readonly AboutUsService _aboutUsService;
        private readonly FileService _fileService;
        public AboutUsController(AboutUsService clientService, FileService fileService, BaseRepository baseRepository)
        {
            _aboutUsService = clientService;
            _fileService = fileService;
            _baseRepository = baseRepository;

        }



        [HttpGet]
        public ActionResult Home(AboutUsFilter filter, int page = 1)
        {
            var model = _aboutUsService.FilterPage(filter, page);
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Views/AboutUs/Partial/AboutUsList.cshtml", model);
            }

            return View(new AboutUsViewModel { 
                Filter=filter,
                List= model
            });
            
        }


        [HttpGet]
        [AjaxOnly]
        public ActionResult AboutUsPartial(long Id)
        {
            var model = Id == 0 ? new AboutUs() : _aboutUsService.FirstOrDefault(Id);

            return PartialView("~/Views/AboutUs/Partial/AboutUsData.cshtml", model);
        }



        [HttpPost]
        [AjaxOnly]
        public ActionResult Save(AboutUs aboutUs)
        {
            if(aboutUs.ImgPath== null)
            {
                aboutUs.ImgPath = "";

            }
            var res = _aboutUsService.Save(aboutUs);
            return Json(new Response
            {
                Success = res,
                Message = res ? Resource.SavedSuccessfully : Resource.ErrorsOccurred,
                Data = new { aboutUsID = aboutUs.Id }
            });
        }




        [HttpPost]
        [AjaxOnly]
        public ActionResult SaveAboutUsPhoto(long aboutUsId)
        {
            var files = Request.Files;
            var uploaded = _fileService.UploadFile(MyConstants.UploadsPath, files[0]);

            AboutUs aboutUs = _aboutUsService.FirstOrDefault(x => x.Id == aboutUsId);
          
            aboutUs.ImgPath = uploaded.Path;

            _aboutUsService.Update(aboutUs);
            _aboutUsService.SaveChanges();
            return Json(true);
        }


        [HttpPost]
        [AjaxOnly]
        public ActionResult Delete(long Id)
        {
            _aboutUsService.Remove(Id);
            var res = _aboutUsService.SaveChanges();
            return Json(new Response { Success = res, Message = res ? Resource.DeletedSuccessfully : Resource.ErrorsOccurred });
        }


        [HttpPost]
        
        public ActionResult DeleteImg(string path)
        {
            try
            {

                if (!string.IsNullOrWhiteSpace(path))
                {
                    
                    if (System.IO.File.Exists(Server.MapPath( path)))
                    {

                        System.IO.File.Delete(Server.MapPath( path));

                    }
                }
                return Json(new Response { Success = true, Message = true ? Resource.DeletedSuccessfully : Resource.ErrorsOccurred });
            }
            catch (Exception ex)
            {
                return Json(new Response { Success = false, Message = false ? Resource.DeletedSuccessfully : Resource.ErrorsOccurred });

            }

        }



















    }
}