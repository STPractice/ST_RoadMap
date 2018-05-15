using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Extensibility;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using STRoadMap.Models;

namespace STRoadMap.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeLogic employeeLogic;

        protected ApplicationDbContext ApplicationDbContext { get; set; }

        protected UserManager<ApplicationUser> UserManager { get; set; }

        public EmployeeController(IEmployeeLogic EmployeeLogic)
        {
            this.employeeLogic = EmployeeLogic;
        }
        private bool IsAuthorized()
        {
            return HttpContext.User.IsInRole("HR") || HttpContext.User.IsInRole("Mentor") || HttpContext.User.IsInRole("Employee");
        }
        // GET: Employee
        
        [HttpGet]
        public ActionResult PerformanceReview()
        {
            if(IsAuthorized() == false)
            {
                return HttpNotFound();
            }
            IEnumerable<Specialization> specs = employeeLogic.GetSpecializations();
            return View(specs);
        }

        [HttpPost]
        public ActionResult PerformanceReview(SkillMatrix position)
        {
            if (IsAuthorized() != true)
            {
                return HttpNotFound();
            }
            if (position == null)
            {
                return HttpNotFound();
            }
            else
            {
                this.ApplicationDbContext = new ApplicationDbContext();
                this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
                if (employeeLogic.CreateSkillMatrix(position, UserManager.FindByName(HttpContext.User.Identity.Name).Id))
                {
                    return RedirectToAction("EmployeeProfile", "Employee");
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        public ActionResult SkillMatrix()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            try
            {
                SkillMatrix matrix = employeeLogic.GetSkillMatrix(UserManager.FindByName(HttpContext.User.Identity.Name).Id);
                return View(matrix);
            }
            catch{
                return HttpNotFound();
            }
        }

        [HttpGet]
        public ActionResult EmployeeProfile()
        {
            if (IsAuthorized() != true)
            {
                return HttpNotFound();
            }
            string UserId = HttpContext.User.Identity.GetUserId();           
                Employee user = employeeLogic.GetProfile(UserId);
                if (user != null)
                {
                    return View(user);
                }
                else
                {
                    return HttpNotFound();
                }            

        }

        [HttpGet]
        public ActionResult RoadMap()
        {
            if (!IsAuthorized())
            {
                return HttpNotFound();
            }
            if (!employeeLogic.IsPerformanceReviewPassed(HttpContext.User.Identity.GetUserId()))
            {
                return View("PerformanceReviewNotPassed");
            }
            if (!employeeLogic.IsRoadMapExists(HttpContext.User.Identity.GetUserId()))
            {
                return View("RoadMapNotExists");
            }
            else
            {
                return View("RoadMap",employeeLogic.getRoadMap(HttpContext.User.Identity.GetUserId()));
            }
        }
        [HttpPost]
        public ActionResult PassCheckpoint(int? RMCheckpointId, int? EmployeeId)
        {
            if (!IsAuthorized())
            {
                return HttpNotFound();
            }
            if (RMCheckpointId != null)
            {
                if (employeeLogic.PassCheckpoint((int)RMCheckpointId))
                {
                    return RedirectToAction("RoadMap", "Employee");
                }
                else
                {
                    return HttpNotFound();
                }
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public string ChangeSkillCondition (int? RMCheckpointId, int? SkillLevelId)
        {
            if (!IsAuthorized())
            {
                return "false";
            }
            if (RMCheckpointId != null && SkillLevelId != null)
            {   
                return employeeLogic.ChangeSkillCondition((int)RMCheckpointId, (int)SkillLevelId).ToString();
            }
            else
            {
                return false.ToString();
            }
            
        }
    }
}