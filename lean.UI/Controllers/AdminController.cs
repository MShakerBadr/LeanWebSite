using lean.UI.Helpers.Models;
using lean.UI.LocalResources;
using lean.UI.Models.DTOs;
using lean.UI.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace lean.UI.Controllers
{
    public class AdminController : BaseAuthorizedController
    {
        private readonly SettingsService _settingService;
        private readonly ProjectService _projectService;
        private readonly ContactUsRequestService _contactUsRequestService;
        private readonly JobRequestService _jobRequestService;

        public AdminController(SettingsService settingService, ProjectService projectService, ContactUsRequestService contactUsRequestService, JobRequestService jobRequestService)
        {
            _settingService = settingService;
            _projectService = projectService;
            _contactUsRequestService = contactUsRequestService;
            _jobRequestService = jobRequestService;
        }


        [HttpGet]
        [ActionName("Home")]
        public ActionResult Index()
        {
            var projects = _projectService.GetAll().ToList();
            var contactUs = _contactUsRequestService.GetAll().ToList();
            var jobRequests = _jobRequestService.GetAll().ToList();

            return View("index", new DashBoardDTO
            {
                AllProjectsCount = projects.Count,
                CommercialProjectsCount = projects.Where(x => x.ProjectTypeId == 1).Count(),
                ResdentialProjectsCount = projects.Where(x => x.ProjectTypeId == 2).Count(),
                FeaturedProjectsCount = projects.Where(x => x.IsSpecialProject).Count(),
                AllContactUsRequestsProjectsCount = contactUs.Count,
                NewcontactUsRequestsProjectsCount = contactUs.Where(x => x.RequestDate >= DateTime.Now.AddDays(-1)).Count(),
                AllAppliedJobRequests = jobRequests.Count,
                NewAppliedJobRequests = jobRequests.Where(x => x.RequestDate >= DateTime.Now.AddDays(-1)).Count(),
            });
        }

        #region SETTINGS
        [HttpGet]
        public ActionResult Settings() { return View(); }

        [HttpPost]
        public async Task<ActionResult> ChangeUsername(string oldUsername, string newUsername)
        {
            var res = await _settingService.ChangeUsername(oldUsername, newUsername);
            return Json(new Response { Success = res, Message = res ? Resource.UsernameChangedSuccessfully : Resource.OldUsernameNotCorrect });
        }

        [HttpPost]
        public async Task<ActionResult> ChangePassword(string oldPassword, string newPassword)
        {
            var res = await _settingService.ChangePassword(oldPassword, newPassword);
            return Json(new Response { Success = res, Message = res ? Resource.PasswordChangedSuccessfully : Resource.OldPasswordNotCorrect });
        }
        #endregion
    }
}