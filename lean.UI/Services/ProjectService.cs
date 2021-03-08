using lean.UI.Helpers.Models;
using lean.UI.Models.DTOs;
using lean.UI.Models.Entities;
using lean.UI.Repositories;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;

namespace lean.UI.Services
{
    public class ProjectService : BaseService<Project, ProjectFilter>
    {
        private readonly BaseRepository _repo;
        private readonly FileService _fileService;

        public ProjectService(BaseRepository repo, FileService fileService) : base(repo)
        {
            _repo = repo;
            _fileService = fileService;
        }


        public override IPagedList<Project> FilterPage(ProjectFilter filter, int pageNumber)
        {
            return base.GetPageWhere(pageNumber, x =>
                  (filter.LocationId == null || x.LocationId == filter.LocationId) &&
                  (filter.ProjectTypeId == null || x.ProjectTypeId == filter.ProjectTypeId) &&
                  (filter.PropertyTypeId == null || x.PropertyTypeId == filter.PropertyTypeId) &&
                  (filter.UnitTypeId == null || x.UnitTypeId == filter.UnitTypeId) &&
                  (filter.IsSpecialProject == null || x.IsSpecialProject == filter.IsSpecialProject),
                  x => x.ProjectType,
                  x => x.PropertyType,
                  x => x.Location,
                  x => x.UnitType
               );
        }

        public Project GetProject(string code)
        {
            return FirstOrDefault(x => x.Code == code,
                x => x.ProjectType,
                  x => x.PropertyType,
                  x => x.Location,
                  x => x.UnitType);
            
            
        }

        public bool SaveProject(Project project, List<ProjectAmenitie> projectAmenitie, List<ProjectPlane> projectPlane, List<ProjectGallery> projectGallery,
            HttpPostedFileBase Logo, HttpPostedFileBase CoverUrlUpload, HttpPostedFileBase MasterPlanImageUrlUpload, HttpPostedFileBase ConvenientLocationAttachmentUrlUpload,
            HttpPostedFileBase[] AmenitieAttachmentUrlUpload, HttpPostedFileBase[] ProjectPlaneAttachments, HttpPostedFileBase[] ProjectGalleryAttachments , HttpPostedFileBase ConceptImageUrlUpload)
        {

            #region getting alreadly existing data before inserting the new ones
            var oldAmenitie = _repo.GetAllWhere<ProjectAmenitie>(x => x.ProjectId == project.Id);
            var oldPlanes = _repo.GetAllWhere<ProjectPlane>(x => x.ProjectId == project.Id);
            var oldGallery = _repo.GetAllWhere<ProjectGallery>(x => x.ProjectId == project.Id);
            #endregion

            var LogoUploadPath = _fileService.UploadFile(MyConstants.UploadsPath, Logo);
            var CoverUrlUploadPath = _fileService.UploadFile(MyConstants.UploadsPath, CoverUrlUpload);
            var MasterPlanImageUrlUploadPath = _fileService.UploadFile(MyConstants.UploadsPath, MasterPlanImageUrlUpload);
            var ConvenientLocationAttachmentUrlUploadPath = _fileService.UploadFile(MyConstants.UploadsPath, ConvenientLocationAttachmentUrlUpload);
            var ConceptImageUrlUploadPath = _fileService.UploadFile(MyConstants.UploadsPath, ConceptImageUrlUpload);


            project.Code = project.TitleEn.Replace(" ", "");
            project.Logo = LogoUploadPath != null ? LogoUploadPath.Path : project.Logo;
            project.CoverUrl = CoverUrlUploadPath != null ? CoverUrlUploadPath.Path : project.CoverUrl;
            project.MasterPlanImageUrl = MasterPlanImageUrlUploadPath != null ? MasterPlanImageUrlUploadPath.Path : project.MasterPlanImageUrl;
            project.ConvenientLocationAttachmentUrl = ConvenientLocationAttachmentUrlUploadPath != null ? ConvenientLocationAttachmentUrlUploadPath.Path : project.ConvenientLocationAttachmentUrl;
            project.ConceptImageUrl = ConceptImageUrlUploadPath != null ? ConceptImageUrlUploadPath.Path : project.ConceptImageUrl;

            

            StringWriter ConceptArWriter = new StringWriter();
            StringWriter ConceptEnWriter = new StringWriter();
            StringWriter HomeConceptArWriter = new StringWriter();
            StringWriter HomeConceptEnWriter = new StringWriter();
            StringWriter MasterPlanArWriter = new StringWriter();
            StringWriter MasterPlanEnWriter = new StringWriter();
            StringWriter ConvenientLocationTextArWriter = new StringWriter();
            StringWriter ConvenientLocationTextEnWriter = new StringWriter();
            
            HttpUtility.HtmlDecode(project.ConceptAr, ConceptArWriter); project.ConceptAr = ConceptArWriter.ToString();
            HttpUtility.HtmlDecode(project.ConceptEn, ConceptEnWriter); project.ConceptEn = ConceptEnWriter.ToString();
            HttpUtility.HtmlDecode(project.HomeConceptAr, HomeConceptArWriter); project.HomeConceptAr = HomeConceptArWriter.ToString();
            HttpUtility.HtmlDecode(project.HomeConceptEn, HomeConceptEnWriter); project.HomeConceptEn = HomeConceptEnWriter.ToString();
            HttpUtility.HtmlDecode(project.MasterPlanAr, MasterPlanArWriter); project.MasterPlanAr = MasterPlanArWriter.ToString();
            HttpUtility.HtmlDecode(project.MasterPlanEn, MasterPlanEnWriter); project.MasterPlanEn = MasterPlanEnWriter.ToString();
            HttpUtility.HtmlDecode(project.ConvenientLocationTextAr, ConvenientLocationTextArWriter); project.ConvenientLocationTextAr = ConvenientLocationTextArWriter.ToString();
            HttpUtility.HtmlDecode(project.ConvenientLocationTextEn, ConvenientLocationTextEnWriter); project.ConvenientLocationTextEn = ConvenientLocationTextEnWriter.ToString();


            var AmenitieAttachmentUrlUploadPaths = _fileService.UploadFiles(MyConstants.UploadsPath, AmenitieAttachmentUrlUpload)?.Where(x => x != null)?.ToList();
            var ProjectPlaneAttachmentsPaths = _fileService.UploadFiles(MyConstants.UploadsPath, ProjectPlaneAttachments)?.Where(x => x != null)?.ToList();
            var ProjectGalleryAttachmentsPaths = _fileService.UploadFiles(MyConstants.UploadsPath, ProjectGalleryAttachments)?.Where(x => x != null)?.ToList();

            if (AmenitieAttachmentUrlUploadPaths != null && AmenitieAttachmentUrlUploadPaths.Count > 0)
            {
                var toloop = projectAmenitie.Where(x => x.IsImgChanged).ToList();
                for (int i = 0; i < toloop.Count; i++)
                {
                    toloop[i].AttachmentUrl = AmenitieAttachmentUrlUploadPaths.Count > i ? AmenitieAttachmentUrlUploadPaths[i].Path : string.Empty;
                }
            }

            if (ProjectPlaneAttachmentsPaths != null && ProjectPlaneAttachmentsPaths.Count > 0)
            {
                var toloop = projectPlane.Where(x => x.IsImgChanged).ToList();
                for (int i = 0; i < toloop.Count; i++)
                {
                    toloop[i].AttachmentUrl = ProjectPlaneAttachmentsPaths.Count > i ? ProjectPlaneAttachmentsPaths[i]?.Path : string.Empty;
                }
            }

            if (ProjectGalleryAttachmentsPaths != null && ProjectGalleryAttachmentsPaths.Count > 0)
            {
                var toloop = projectGallery.Where(x => x.IsImgChanged).ToList();
                for (int i = 0; i < toloop.Count; i++)
                {
                    toloop[i].ImageUrl = ProjectGalleryAttachmentsPaths.Count > i ? ProjectGalleryAttachmentsPaths[i].Path : string.Empty;
                }
            }

            project.ProjectAmenities = null;
            project.ProjectPlanes = null;
            project.ProjectGallery = null;

            var res = Save(project);

            if (projectAmenitie != null) projectAmenitie.ForEach(x => x.ProjectId = project.Id);
            if (projectPlane != null) projectPlane.ForEach(x => x.ProjectId = project.Id);
            if (projectGallery != null) projectGallery.ForEach(x => x.ProjectId = project.Id);

            if (projectAmenitie != null) _repo.AddRange<ProjectAmenitie>(projectAmenitie);
            if (projectPlane != null) _repo.AddRange<ProjectPlane>(projectPlane);
            if (projectGallery != null) _repo.AddRange<ProjectGallery>(projectGallery);

            var result= _repo.SaveChanges();
            if (result)
            {
                if (project.Id > 0)
                {

                    _repo.RemoveRange<ProjectAmenitie>(oldAmenitie);
                    _repo.RemoveRange<ProjectPlane>(oldPlanes);
                    _repo.RemoveRange<ProjectGallery>(oldGallery);
                    _repo.SaveChanges();
                }
            }

            return res;
        }
    }
}
