using Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Service;

namespace STRoadMap.Controllers
{
    public class MentorController : Controller
    {
        private readonly IMentorLogic MentorLogic;

        public MentorController(IMentorLogic MentorLogic)
        {
            this.MentorLogic = MentorLogic;
        }
        // GET: Mentor
        private bool IsAuthorized()
        {
            return HttpContext.User.IsInRole("HR")|| HttpContext.User.IsInRole("Mentor");
        }
        [HttpGet]
        public ActionResult EmployeeList()
        {
            if (!IsAuthorized())
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }
            IEnumerable<Employee> spec = MentorLogic.GetEmployeeList();
            if (spec == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(spec);
            }
        }

        [HttpGet]
        public ActionResult EmployeeProfile(int? EmployeeId=100)
        {
            if (!IsAuthorized())
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }
            if (EmployeeId==null)
            {
                return HttpNotFound();
            }
            else
            {
                var user = MentorLogic.GetEmployeesProfile((int) EmployeeId);
                if (user != null)
                {
                    return View(user);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpGet]
        public ActionResult RoadMap(int? EmployeeId)
        {
            if (!IsAuthorized())
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }
            if (EmployeeId == null)
            {
                return HttpNotFound();
            }
            else
            {
                var roadMap = MentorLogic.GetEmployeesRoadMap((int)EmployeeId);
                if (roadMap != null)
                {
                    return View(roadMap);
                }
                else
                {
                    return View("RoadMapNotExists",MentorLogic.GetEmployeesProfile((int)EmployeeId) );
                }
            }
        }

        [HttpPost]
        public ActionResult RefuseCheckpoint(int? RMCheckpointId, int? EmployeeId)
        {
            if (!IsAuthorized())
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }
            if (RMCheckpointId != null)
            {
                if (MentorLogic.RefuseCheckpoint((int)RMCheckpointId))
                {
                    return RedirectToAction("RoadMap", "Mentor", new { EmployeeId = EmployeeId });
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
        public ActionResult AcceptCheckpoint(int? RMCheckpointId, int? EmployeeId)
        {
            if (!IsAuthorized())
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }
            if (RMCheckpointId != null)
            {
                if (MentorLogic.AcceptCheckpoint((int)RMCheckpointId))
                {
                    return RedirectToAction("RoadMap", "Mentor", new { EmployeeId = EmployeeId });
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
    }
}