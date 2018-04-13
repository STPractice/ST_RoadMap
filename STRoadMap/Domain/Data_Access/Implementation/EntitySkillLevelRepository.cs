using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EntitySkillLevelRepository:ISkillLevelRepository
    {
        private readonly Entities1 context;

        public EntitySkillLevelRepository(Entities1 context)
        {
            this.context = context;
        }

        public int Create(SkillLevel entity)
        {
            return context.SkillLevels.Add(entity).SkillId;
        }

        public void Delete(SkillLevel entity)
        {
            context.SkillLevels.Remove(entity);
        }

        public SkillLevel Find(params object[] keyValues)
        {
            return context.SkillLevels.Find(keyValues);
        }

        public IEnumerable<SkillLevel> Get(Func<SkillLevel, bool> predicate)
        {
            return context.SkillLevels.Where(predicate);
        }

        public IEnumerable<SkillLevel> GetAll()
        {
            return context.SkillLevels.ToList();
        }

        public int Update(SkillLevel entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return entity.SkillLevelId;
        }
    }
}
