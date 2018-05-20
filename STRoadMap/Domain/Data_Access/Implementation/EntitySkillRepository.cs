using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EntitySkillRepository : ISkillRepository
    {
        private readonly Entities1 context;

        public EntitySkillRepository(Entities1 context)
        {
            this.context = context;
        }

        public int Create(Skill entity)
        {
            return context.Skills.Add(entity).SkillId;
        }

        public void Delete(Skill entity)
        {
            context.Skills.Remove(entity);
        }

        public Skill Find(params object[] keyValues)
        {
            return context.Skills.Find(keyValues);
        }

        public IEnumerable<Skill> Get(Func<Skill, bool> predicate)
        {
            return context.Skills.Where(predicate);
        }

        public IEnumerable<Skill> GetAll()
        {
            return context.Skills.ToList();
        }

        public int Update(Skill entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return entity.SkillId;
        }

        public int Update(int id, string name)
        {
            Skill currentSkill = Find(id);
            currentSkill.SkillId = id;
            currentSkill.Name = name;
            context.Entry(currentSkill).State = System.Data.Entity.EntityState.Modified;
            return currentSkill.SkillId;
        }
    }
}
