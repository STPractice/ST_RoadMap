using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensibility
{
    public interface IEmployeeLogic
    {
        Specialization GetSpecialization(int SpecializationId);
        bool CreateSkillMatrix(SkillMatrix matrix, string userName);
        IEnumerable<Specialization> GetSpecializations();
    }
}
