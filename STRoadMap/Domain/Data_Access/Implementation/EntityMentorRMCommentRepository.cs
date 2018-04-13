using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EntityMentorRMCommentRepository : IMentorRMCommentRepository
    {
        private readonly Entities1 context;

        public EntityMentorRMCommentRepository(Entities1 context)
        {
            this.context = context;
        }

        public int Create(MentorRMComment entity)
        {
            return context.MentorRMComments.Add(entity).MentorId;
        }

        public void Delete(MentorRMComment entity)
        {
            context.MentorRMComments.Remove(entity);
        }

        public MentorRMComment Find(params object[] keyValues)
        {
            return context.MentorRMComments.Find(keyValues);
        }

        public IEnumerable<MentorRMComment> Get(Func<MentorRMComment, bool> predicate)
        {
            return context.MentorRMComments.Where(predicate);
        }

        public IEnumerable<MentorRMComment> GetAll()
        {
            return context.MentorRMComments.ToList();
        }

        public int Update(MentorRMComment entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return entity.MentorId;
        }
    }
}
