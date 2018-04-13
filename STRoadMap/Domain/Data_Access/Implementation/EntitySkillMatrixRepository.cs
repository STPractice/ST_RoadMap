using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EntitySkillMatrixRepository : ISkillMatrixRepository
    {
        private readonly Entities1 context;

        public EntitySkillMatrixRepository(Entities1 context)
        {
            this.context = context;
        }

        public int Create(SkillMatrix entity)
        {
            return context.SkillMatrices.Add(entity).SkillMatrixId;
        }

        public void Delete(SkillMatrix entity)
        {
            context.SkillMatrices.Remove(entity);
        }

        public SkillMatrix Find(params object[] keyValues)
        {
            return context.SkillMatrices.Find(keyValues);
        }

        public IEnumerable<SkillMatrix> Get(Func<SkillMatrix, bool> predicate)
        {
            return context.SkillMatrices.Where(predicate);
        }

        public IEnumerable<SkillMatrix> GetAll()
        {
            return context.SkillMatrices.ToList();
        }

        public int Update(SkillMatrix entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return entity.SkillMatrixId;
        }
    }
}
