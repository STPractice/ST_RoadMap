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
        public ActionResult CreatePosition(int? SpecializationId)
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

            //Specialization spec = HRLogic.GetSpecialization((int)SpecializationId);
            //Skill skill = new Skill();
            //skill.Name = "English";
            //SkillLevel sl1 = new SkillLevel();
            //sl1.Name = "first";
            //SkillLevel sl2 = new SkillLevel();
            //sl2.Name = "second";
            //skill.SkillLevels.Add(sl1);
            //skill.SkillLevels.Add(sl2);
            //spec.Skills.Add(skill);

            //Skill skill2 = new Skill();
            //skill2.Name = ".Net";
            //SkillLevel sl21 = new SkillLevel();
            //sl21.Name = "first1";
            //SkillLevel sl22 = new SkillLevel();
            //sl22.Name = "second2";
            //skill2.SkillLevels.Add(sl21);
            //skill2.SkillLevels.Add(sl22);
            //spec.Skills.Add(skill2);
            //int i = (spec.Positions == null || spec.Positions.Count == 0) ? 0 : spec.Positions.Last().PositionLevel + 1;
            //return View(spec);
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
    }
}
