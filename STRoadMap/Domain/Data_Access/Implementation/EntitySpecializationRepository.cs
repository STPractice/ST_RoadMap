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

        public int Update(Specialization spec)
        {
        
            List<Skill> innerSkills = new List<Skill>();
            foreach (Skill foreignSkill in spec.Skills)
            {
                Skill innerSkill = UoW.Skills.Find(foreignSkill.SkillId);
                if (innerSkill != null)
                {
                    innerSkills.Add(innerSkill);
                }
                else
                {
                    return 0;
                }
            }
            spec.Skills = innerSkills;

            Specialization currentSpec = Find(spec.SpecializationId);
            if (currentSpec == null) return 0;
            currentSpec.Name = spec.Name;            

            List<Skill> OldSkills = currentSpec.Skills.ToList<Skill>();
            List<Skill> NewSkills = spec.Skills.ToList<Skill>();
            
            foreach (Skill oldSkill in OldSkills)
            {
                bool exist = false;

                foreach (Skill newSkill in NewSkills)
                {
                    if (oldSkill.SkillId == newSkill.SkillId)
                    {                        
                        exist = true;
                    }
                }
                if (exist == false)
                {
                    currentSpec.Skills.Remove(oldSkill);
                }
            }
            foreach (Skill newSkill in NewSkills)
            {
                bool exist = false;
                foreach (Skill oldSkill in OldSkills)
                {
                    if (newSkill.SkillId == oldSkill.SkillId) exist = true;
                }
                if (exist == false)
                {
                    currentSpec.Skills.Add(newSkill);
                }
            }

            try
            {
                context.Entry(currentSpec).State = System.Data.Entity.EntityState.Modified;
                return currentSpec.SpecializationId;
            }

            catch (Exception)
            {
                return 0;
            }
        }
    }
}
