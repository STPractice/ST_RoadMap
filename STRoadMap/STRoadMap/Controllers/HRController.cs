using Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace STRoadMap.Controllers
{
    public class HRController : Controller
    {
        private readonly IHRLogic HRLogic;

        public HRController(IHRLogic HRLogic)
        {            
            this.HRLogic = HRLogic;
        }
        // GET: HR
        public string Index()
        {         
            return "It works!)";
        }

        [HttpGet]
        public ActionResult CreateSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSkill(Skill skill)
        {
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
            IEnumerable<Skill> skillList = HRLogic.GetSkillList();
            return View(skillList);
        }

        [HttpPost]
        public ActionResult SkillList(int? SkillId)
        {

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


        [HttpGet]
        public ActionResult SpecializationList()
        {
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
        public ActionResult Skill(int? skillId)
        {

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
        public ActionResult EditSpecialization(int? SpecializationId)
        {

            if (SpecializationId == null)
            {
                return HttpNotFound();
            }
            else
            {
                Specialization specialization = HRLogic.GetSpecialization((int)SpecializationId);
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
        public ActionResult EditSpecialization(Specialization specialization)
        {
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
    }
}
