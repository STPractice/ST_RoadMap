using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface ISkillLevelRepository : IRepository<SkillLevel>
    {
        int Update(
            int id,
            string name,
            string description,
            int skillId,
            int level
            );
    }
}
