using lean.UI.Filters;
using lean.UI.Helpers.Models;
using lean.UI.LocalResources;
using lean.UI.Models.DTOs;
using lean.UI.Models.Entities;
using lean.UI.Services;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace lean.UI.Controllers
{
    public class ProjectsController : BaseAuthorizedController
    {
        private readonly FileService _fileService;
        private readonly ProjectService _projectService;
        private readonly LocationService _locationService;
        private readonly PropertyTypeService _propertyTypeService;
        private readonly ProjectTypeService _projectTypeService;
        private readonly UnitTypeService _unitTypeService;

        public ProjectsController(FileService fileService, ProjectService projectService, LocationService locationService, ProjectTypeService projectTypeService, PropertyTypeService propertyTypeService, UnitTypeService unitTypeService)
        {
            _fileService = fileService;
            _projectService = projectService;
            _locationService = locationService;
            _projectTypeService = projectTypeService;
            _propertyTypeService = propertyTypeService;
            _unitTypeService = unitTypeService;
        }


        [HttpGet]
        public ActionResult Index(ProjectFilter filter, int page = 1)
        {
            var model = _projectService.FilterPage(filter, page);
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Views/Projects/Partial/ProjectsList.cshtml", model);
            }
            else
            {
                GetViewBags();
            }

            return View(new ProjectViewModel
            {
                Filter = filter,
                List = model,
            });
        }

        [HttpGet]
        public ActionResult ProjectData(string code)
        {
            var model = string.IsNullOrEmpty(code) ? new Project() : _projectService.GetProject(code);
            GetViewBags();
            return View(model);
        }

        [HttpPost]
        public ActionResult Save(Project project, 
            [Bind(Prefix = "ProjectAmenitie")] List<ProjectAmenitie> projectAmenitie,
            [Bind(Prefix = "ProjectPlane")] List<ProjectPlane> projectPlane,
            [Bind(Prefix = "ProjectGallery")] List<ProjectGallery> projectGallery,
            HttpPostedFileBase Logo ,
            HttpPostedFileBase CoverUrlUpload,
            HttpPostedFileBase MasterPlanImageUrlUpload,
            HttpPostedFileBase ConvenientLocationAttachmentUrlUpload,
            HttpPostedFileBase[] AmenitieAttachmentUrlUpload,
            HttpPostedFileBase[] ProjectPlaneAttachments,
            HttpPostedFileBase[] ProjectGalleryAttachments,
            HttpPostedFileBase ConceptImageUrlUpload)
        {

            _projectService.SaveProject(project, projectAmenitie, projectPlane, projectGallery, Logo,CoverUrlUpload, MasterPlanImageUrlUpload, ConvenientLocationAttachmentUrlUpload, AmenitieAttachmentUrlUpload, ProjectPlaneAttachments, ProjectGalleryAttachments , ConceptImageUrlUpload); 
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult Delete(string code)
        {
            var project = _projectService.FirstOrDefault(x => x.Code == code);
            _projectService.Remove(project);
            var res = _projectService.SaveChanges();
            return Json(new Response { Success = res, Message = res ? Resource.DeletedSuccessfully : Resource.ErrorsOccurred });
        }

        private void GetViewBags()
        {
            ViewBag.Locations = new SelectList(_locationService.GetAll(), "Id", "Name");
            ViewBag.ProjectTypes = new SelectList(_projectTypeService.GetAll(), "Id", "Name");
            ViewBag.PropertyTypes = new SelectList(_propertyTypeService.GetAll(), "Id", "Name");
            ViewBag.UnitTypeS = new SelectList(_unitTypeService.GetAll(), "Id", "Name");
        }
    }
}
