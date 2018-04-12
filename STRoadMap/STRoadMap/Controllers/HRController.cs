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
            
        }
        
    }
}