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
    public class ProductController : BaseAuthorizedController
    {
        private readonly BaseRepository _baseRepository;
        private readonly ProductService _productService;
        private readonly FileService _fileService;
        public ProductController(ProductService productService, FileService fileService, BaseRepository baseRepository)
        {
            _productService = productService;
            _fileService = fileService;
            _baseRepository = baseRepository;

        }



        [HttpGet]
        public ActionResult Home(ProductFilter filter, int page = 1)
        {
            var model = _productService.FilterPage(filter, page);
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Views/Product/Partial/ProductList.cshtml", model);
            }

            return View(new ProductViewModel { 
                Filter=filter,
                list= model
            });
            
        }


        [HttpGet]
        [AjaxOnly]
        public ActionResult ProductPartial(long Id)
        {
            var model = Id == 0 ? new Product() : _productService.FirstOrDefault(Id);

            return PartialView("~/Views/Product/Partial/ProductData.cshtml", model);
        }



        [HttpPost]
        [AjaxOnly]
        public ActionResult Save(Product product)
        {
            if(product.ImgPath== null)
            {
                product.ImgPath = "";

            }
            var res = _productService.Save(product);
            return Json(new Response
            {
                Success = res,
                Message = res ? Resource.SavedSuccessfully : Resource.ErrorsOccurred,
                Data = new { productId = product.Id }
            });
        }




        [HttpPost]
        [AjaxOnly]
        public ActionResult SaveProductPhoto(long productId)
        {
            var files = Request.Files;
            var uploaded = _fileService.UploadFile(MyConstants.UploadsPath, files[0]);

            Product product = _productService.FirstOrDefault(x => x.Id == productId);
          
            product.ImgPath = uploaded.Path;

            _productService.Update(product);
            _productService.SaveChanges();
            return Json(true);
        }


        [HttpPost]
        [AjaxOnly]
        public ActionResult Delete(long Id)
        {
            _productService.Remove(Id);
            var res = _productService.SaveChanges();
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