using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EntityCheckpointsSkillRepository : ICheckpointsSkillRepository
    {
        private readonly Entities1 context;

        public EntityCheckpointsSkillRepository(Entities1 context)
        {
            this.context = context;
        }

        public int Create(CheckpointsSkill entity)
        {
            return context.CheckpointsSkills.Add(entity).RMCheckpointId;
        }

        public void Delete(CheckpointsSkill entity)
        {
            context.CheckpointsSkills.Remove(entity);
        }

        public CheckpointsSkill Find(params object[] keyValues)
        {
            return context.CheckpointsSkills.Find(keyValues);
        }

        public IEnumerable<CheckpointsSkill> Get(Func<CheckpointsSkill, bool> predicate)
        {
            return context.CheckpointsSkills.Where(predicate);
        }

        public IEnumerable<CheckpointsSkill> GetAll()
        {
            return context.CheckpointsSkills.ToList();
        }

        public int Update(CheckpointsSkill entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return entity.RMCheckpointId;
        }
    }
}
