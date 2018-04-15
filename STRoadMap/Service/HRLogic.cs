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
        IUnitOfWork UoW;

        HRLogic(IUnitOfWork newUnitOfWork)
        {
            this.UoW = uoW;
        }

        public IEnumerable<Specialization> GetSpecializationList()
        {            
            return UoW.Specializations.GetAll();            
        }

        public bool DeleteSpecialization (int id)
        {
            if (UoW.Specializations.Find(id) != null)
            {
                UoW.Specializations.Delete(UoW.Specializations.Find(id));
                return UoW.Commit();
            }
            else
            {
                return false;
            }
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