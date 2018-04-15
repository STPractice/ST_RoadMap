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
        IEnumerable<Skill> GetListOfSkills();
        bool? DeleteSkill(int? skillId);
    }
}
