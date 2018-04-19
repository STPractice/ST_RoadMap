﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface ISkillRepository : IRepository<Skill>
    {
        int Update(int id, string name);
    }
}
