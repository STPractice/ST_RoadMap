using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Extensibility
{
    public interface IHRLogic
    {
        bool CreateSkill(Skill skill);
        IEnumerable<Specialization> GetSpecializationList();
        bool DeleteSpecialization(int id);

        IEnumerable<Skill> GetSkillList();
        bool DeleteSkill(int id);
    }
}
