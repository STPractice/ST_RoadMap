using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EntityMentorRepository : IMentorRepository
    {
        private readonly Entities1 context;

        public EntityMentorRepository(Entities1 context)
        {
            this.context = context;
        }

        public int Create(Mentor entity)
        {
            return context.Mentors.Add(entity).MentorId;
        }

        public void Delete(Mentor entity)
        {
            context.Mentors.Remove(entity);
        }

        public Mentor Find(params object[] keyValues)
        {
            return context.Mentors.Find(keyValues);
        }

        public IEnumerable<Mentor> Get(Func<Mentor, bool> predicate)
        {
            return context.Mentors.Where(predicate);
        }

        public IEnumerable<Mentor> GetAll()
        {
            return context.Mentors.ToList();
        }

        public int Update(Mentor entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return entity.MentorId;
        }
    }
}
