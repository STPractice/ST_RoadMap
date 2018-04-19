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
        
        IEnumerable<Specialization> GetSpecializationList();
        bool DeleteSpecialization(int id);

        IEnumerable<Skill> GetSkillList();

        Skill GetSkill(int SkillId);

        bool CreateSkill(Skill skill);

        bool EditSkill(Skill skill);

        bool DeleteSkill(int id);
		
        Skill GetSkill(int skillId);
    }
}
