using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EntitySpecializationRepository : ISpecializationRepository
    {
        private readonly Entities1 context;
        private readonly IUnitOfWork UoW;

        public EntitySpecializationRepository(Entities1 context, IUnitOfWork UoW)
        {
            this.context = context;
            this.UoW = UoW;
        }

        public int Create(Specialization entity)
        {
            List<Skill> innerSkills = new List<Skill>();
            foreach (Skill outSkill in entity.Skills)
            {
                Skill innerSkill = UoW.Skills.Find(outSkill.SkillId);
                if (innerSkill != null)
                {
                    innerSkills.Add(innerSkill);
                }
                else
                {
                    return 0;
                }
            }
            entity.Skills = innerSkills;

            return context.Specializations.Add(entity).SpecializationId;
        }

        public void Delete(Specialization entity)
        {
            context.Specializations.Remove(entity);
        }

        public Specialization Find(params object[] keyValues)
        {
            return context.Specializations.Find(keyValues);
        }

        public IEnumerable<Specialization> Get(Func<Specialization, bool> predicate)
        {
            return context.Specializations.Where(predicate);
        }

        public IEnumerable<Specialization> GetAll()
        {
            return context.Specializations.ToList();
        }

        public int Update(Specialization entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return entity.SpecializationId;
        }
    }
}
