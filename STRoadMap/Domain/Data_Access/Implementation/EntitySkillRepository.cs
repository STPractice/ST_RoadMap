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

        public EntitySkillRepository(EntityUnitOfWork uof)
        {
            context = uof.context;
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
            //skill in context
            Skill contextSkill = context.Skills.Find(entity.SkillId);
            contextSkill.Name = entity.Name;

            //this skills we need to remove in context skill
            List<SkillLevel> removeSkills = new List<SkillLevel>();
            foreach(SkillLevel sl in contextSkill.SkillLevels)
            {
                //if skill level exists in contextSkill
                //and not exist in entity, then
                //we remove it
                if (entity
                    .SkillLevels
                    .Where(s => s.SkillLevelId == sl.SkillLevelId)
                    .ToList()
                    .Count == 0)
                    removeSkills.Add(sl);
            }
            foreach (SkillLevel sl in removeSkills)
                contextSkill.SkillLevels.Remove(sl);

            foreach(SkillLevel sl in entity.SkillLevels)
            {
                //if level exists in entity and
                //doesn't exist in context then
                //we add it
                if (contextSkill
                    .SkillLevels
                    .Where(s => s.SkillLevelId == sl.SkillLevelId)
                    .ToList()
                    .Count == 0)
                    contextSkill.SkillLevels.Add(sl);
            }

            //this specs we need to remove in context skill
            List<Specialization> removeSpecs = new List<Specialization>();
            foreach (Specialization sp in contextSkill.Specializations)
            {
                //if skill level exists in contextSkill
                //and not exist in entity, then
                //we remove it
                if (entity
                    .Specializations
                    .Where(s => s.SpecializationId==sp.SpecializationId)
                    .ToList()
                    .Count == 0)
                    removeSpecs.Add(sp);
            }
            foreach (Specialization sp in removeSpecs)
                contextSkill.Specializations.Remove(sp);

            foreach (Specialization sp in entity.Specializations)
            {
                //if level exists in entity and
                //doesn't exist in context then
                //we add it
                if (contextSkill
                    .Specializations
                    .Where(s => s.SpecializationId == sp.SpecializationId)
                    .ToList()
                    .Count == 0)
                    contextSkill.Specializations.Add(sp);
            }
            return entity.SkillId;
        }
    }
}
