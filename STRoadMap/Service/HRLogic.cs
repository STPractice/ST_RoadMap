using Extensibility;

using System.Collections.Generic;
using Domain;
using System.IO;
using System.Linq;
using System.Text;
using Domain;

namespace Service
{
    public class HRLogic : IHRLogic
    {
        private readonly IUnitOfWork unitOfWork;

        HRLogic(IUnitOfWork newUnitOfWork)
        {
            unitOfWork = newUnitOfWork;
        }

        public IEnumerable<Skill> GetListOfSkills()
        {
            return unitOfWork.Skills.GetAll();

        }

        public bool? DeleteSkill(int? skillId)
        {
            unitOfWork.Skills.Delete(unitOfWork.Skills.Find(skillId));
            var isOk = unitOfWork.Commit();
            if (isOk)
            {
                return true;
            }
            else
            {
                return null;
            }
        }
    }
}