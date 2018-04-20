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

        IEnumerable<Position> GetPositionList(int SpecializationId);

        bool DeletePosition(int id);

        Position GetPosition(int PositionId);

        bool EditPosition(Position position); 

        Specialization GetSpecialization(int SpecializationId);

        bool CreatePosition(Position position);

        bool CreateSpecialization(Specialization specialization);

        bool EditSpecialization(Specialization spec);

        Specialization GetSpecialization(int SpecializationId);
    }
}
