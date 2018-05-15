using Extensibility;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Domain;

namespace STRoadMap.Controllers
{
    public class HRController : Controller
    {
        private readonly IHRLogic HRLogic;
        private readonly IAccountLogic AccountLogic;

        public HRController(IHRLogic HRLogic, IAccountLogic accountLogic)
        {
            this.HRLogic = HRLogic;
            this.AccountLogic = accountLogic;
           
        }       
        

        private bool IsAuthorized()
        {
            return HttpContext.User.IsInRole("HR");
        }

        [HttpGet]
        public ActionResult CreateSkill()
        {
            if (!IsAuthorized()) {
                Response.StatusCode = 404;
                return HttpNotFound();
            }
            return View();
        }
        [HttpPost]
        public ActionResult CreateSkill(Skill skill)
        {
            if (!IsAuthorized())
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }
            if (skill == null)
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }
            else
            {
                if (HRLogic.CreateSkill(skill))
                {
                    return RedirectToAction("SkillList", "HR");
                }
                else
                {
                    Response.StatusCode = 404;
                    return HttpNotFound();
                }
            }
        }
        [HttpGet]
        public ActionResult SkillList()
        {
            if (!IsAuthorized())
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }
            IEnumerable<Skill> skillList = HRLogic.GetSkillList();
            return View(skillList);
        }

        [HttpPost]
        public ActionResult SkillList(int? SkillId)
        {
            if (!IsAuthorized())
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }

            if (SkillId == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (HRLogic.DeleteSkill(int.Parse(SkillId.ToString())) == true)
                {
                    return RedirectToAction("SkillList");
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }
        public ActionResult EmployeeList()
        {
            if (!IsAuthorized())
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }
            IEnumerable<Employee> spec = HRLogic.GetEmployeeList();
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
        public ActionResult SpecializationList()
        {
            if (!IsAuthorized())
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }
            IEnumerable<Specialization> spec = HRLogic.GetSpecializationList();
            if (spec == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(spec);
            }
        }

        [HttpPost]
        public ActionResult SpecializationList(int? SpecializationId)
        {
            if (!IsAuthorized())
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }
            if (SpecializationId == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (HRLogic.DeleteSpecialization(int.Parse(SpecializationId.ToString())))
                {
                    return RedirectToAction("SpecializationList", "HR");
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpGet]
        public ActionResult Specialization(int? specializationId)
        {
            if (!IsAuthorized())
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }
            if (specializationId == null)
            {
                return HttpNotFound();
            }
            else
            {
                var specialization = HRLogic.GetSpecialization((int)specializationId);
                if (specialization != null)
                {
                    return View(specialization);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        public ActionResult Specialization(Specialization specialization)
        {
            if (!IsAuthorized())
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }
            if (specialization != null)
            {
                if (HRLogic.DeleteSpecialization(specialization.SpecializationId))
                {
                    return RedirectToAction("SpecializationList", "HR");
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

        [HttpGet]
        public ActionResult Skill(int? skillId)
        {
            if (!IsAuthorized())
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }
            if (skillId == null)
            {
                return HttpNotFound();
            }
            else
            {
                var skill = HRLogic.GetSkill((int)skillId);
                if (skill != null)
                {
                    return View(skill);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        public ActionResult Skill(Skill skill)
        {
            if (!IsAuthorized())
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }
            if (skill == null)
            {
                return HttpNotFound();
            }
            else
            {                
                if (HRLogic.DeleteSkill(skill.SkillId))
                {
                    return RedirectToAction("SkillList", "HR");
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpGet]
        public ActionResult EditSkill(int? SkillId)
        {
            if (!IsAuthorized())
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }
            if (SkillId == null)
            {
                return HttpNotFound();
            }
            else
            {
                Skill skill = HRLogic.GetSkill((int)SkillId);
                if (skill != null)
                {
                    return View(skill);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        public ActionResult EditSkill(Skill skill)
        {
            if (!IsAuthorized())
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }
            if (skill == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (HRLogic.EditSkill(skill))
                {
                    return RedirectToAction("SkillList", "HR");
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpGet]
        public ActionResult PositionList(int? SpecializationId)
        {
            if (!IsAuthorized())
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }
            if (SpecializationId == null)
            {
                return HttpNotFound();
            }
            else
            {
                IEnumerable<Position> pos = HRLogic.GetPositionList((int)SpecializationId);
                if (pos != null)
                {
                    ViewBag.SpecializationId = SpecializationId;
                    return View(pos);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        public ActionResult PositionList(int? PositionId, int? SpecializationId)
        {
            if (!IsAuthorized())
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }
            if (PositionId == null || SpecializationId == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (HRLogic.DeletePosition((int)PositionId) == true)
                {
                    ViewBag.SpecializationId = SpecializationId;
                    return RedirectToAction("PositionList", new { SpecializationId = SpecializationId });
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpGet]
        public ActionResult CreatePosition(int? SpecializationId=103)
        {
            if (!IsAuthorized())
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }
            if (SpecializationId == null)
            {
                return HttpNotFound();
            }
            else
            {
                Specialization spec = HRLogic.GetSpecialization((int)SpecializationId);
                if (spec == null)
                {
                    return HttpNotFound();
                }
                else
                {

                    return View(spec);
                }
            }
        }
        [HttpPost]
        public ActionResult CreatePosition(Position position)
        {
            if (!IsAuthorized())
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }
            if (position == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (HRLogic.CreatePosition(position))
                {
                    return RedirectToAction("PositionList", "HR", new { SpecializationId=position.SpecializationId });
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpGet]
        public ActionResult CreateSpecialization()
        {
            if (!IsAuthorized())
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }
            List<Skill> skills = HRLogic.GetSkillList().ToList<Skill>();
            if (skills != null)
            {
                return View(skills);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult CreateSpecialization(Specialization specialization)
        {
            if (!IsAuthorized())
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }
            if (specialization == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (HRLogic.CreateSpecialization(specialization))
                {
                    return RedirectToAction("SpecializationList", "HR");
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }



        [HttpGet]
        public ActionResult EditPosition(int? PositionId)
        {
            if (!IsAuthorized())
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }
            if (PositionId == null)
            {
                return HttpNotFound();
            }
            else
            {
                Position position = HRLogic.GetPosition((int)PositionId);
                if (position != null)
                {
                    return View(position);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        public ActionResult EditPosition(Position position)
        {
            if (!IsAuthorized())
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }
            if (position == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (HRLogic.EditPosition(position))
                {
                    return RedirectToAction("PositionList", "HR", new { SpecializationId = position.SpecializationId });
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
            if (EmployeeId != null)
            {                
                RoadMap roadMap = HRLogic.GetRoadMap((int)EmployeeId);
                ViewBag.EmployeeId = EmployeeId;                
                return View(roadMap);                
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult DeleteRoadMap(int? RoadMapId)
        {
            if (!IsAuthorized())
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }
            if (RoadMapId != null)
            {                
                if (HRLogic.DeleteRoadMap((int)RoadMapId))
                {
                    return RedirectToAction("EmolyeeList", "HR");
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
        public ActionResult RefuseCheckpoint (int? RMCheckpointId, int? EmployeeId)
        {
            if (!IsAuthorized())
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }
            if (RMCheckpointId != null)
            {
                if (HRLogic.RefuseCheckpoint((int)RMCheckpointId))
                {
                    return RedirectToAction("RoadMap", "HR", new {EmployeeId=  EmployeeId});
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
                if (HRLogic.AcceptCheckpoint((int)RMCheckpointId))
                {
                    return RedirectToAction("RoadMap", "HR", new { EmployeeId = EmployeeId });
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

        [HttpGet]
        public ActionResult EditSpecialization(int? SpecializationId)
        {
            if (!IsAuthorized())
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }

            if (SpecializationId == null)
            {
                return HttpNotFound();
            }
            else
            {
                Specialization specialization = HRLogic.GetSpecialization((int)SpecializationId);
                if (specialization != null)
                {
                    ViewBag.Skills = HRLogic.GetSkillList();
                    return View(specialization);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        public ActionResult EditSpecialization(Specialization specialization)
        {            
            if (!IsAuthorized()) { 
                Response.StatusCode = 404;
                return HttpNotFound();
            }
            if (specialization == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (HRLogic.EditSpecialization(specialization))
                {                    
                    return RedirectToAction("SpecializationList", "HR");
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpGet]
        public ActionResult CreateRoadMap(int? EmployeeId)
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
                List<Skill> skills = HRLogic.GetEmployeesAvailableSkills((int) EmployeeId);
                if (skills!=null)
                {
                    ViewBag.EmployeeId = EmployeeId;
                    return View(skills);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        public ActionResult CreateRoadMap(RoadMap roadMap)
        {
            if (!IsAuthorized())
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }

            int id = HRLogic.CreateRoadMap(roadMap);
            if (id!=0)
            {
                return RedirectToAction("RoadMap", "HR", new { EmployeeId = roadMap.EmpolyeeId });
            }
            else
            {
                return HttpNotFound();
            };
        }
    }    


        [HttpGet]
        public ActionResult EmployeeProfile(int? EmployeeId)
        {
            if (IsAuthorized() != true)
            {
                return HttpNotFound();
            }

            if (EmployeeId == null)
            {
                return HttpNotFound();
            }
            else
            {
                var user = HRLogic.GetEmployeesProfile((int)EmployeeId);
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

        public ActionResult DecreaseEmployee(int? employeeId)
        {
            if (employeeId != null)
            {
                if (HRLogic.DecreaseEmployee((int) employeeId))
                {
                    return RedirectToAction("EmployeeProfile", "HR", new {EmployeeId = employeeId});
                }

                return HttpNotFound();
            }

            return HttpNotFound();
        }
        public ActionResult IncreaseEmployee(int? employeeId)
        {
            if (employeeId != null)
            {
                if (HRLogic.IncreaseEmployee((int)employeeId))
                {
                    return RedirectToAction("EmployeeProfile", "HR", new { EmployeeId = employeeId });
                }

                return HttpNotFound();
            }
            return HttpNotFound();
        }
    }
}
