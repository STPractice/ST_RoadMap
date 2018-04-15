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
        public ActionResult SkillList()
        {
            IEnumerable<Skill> skillList = HRLogic.GetListOfSkills();
            return View(skillList);
        }

        [HttpPost]
        public ActionResult SkillList(int? id)
        {

            if(id==null)
            {
                return HttpNotFound();
            }
            else
            {
                if(HRLogic.DeleteSkill(id)==true)
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
            IEnumerable<Specialization> spec= HRLogic.GetSpecializationList();
            if(spec== null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(spec);
            }
        }

        [HttpPost]
        public ActionResult SpecializationList(int? id)
        {            
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (HRLogic.DeleteSpecialization(int.Parse(id.ToString())))
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