using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EntityMentorCheckpointCommentRepository : IMentorCheckpointCommentRepository
    {
        private readonly Entities1 context;

        public EntityMentorCheckpointCommentRepository(Entities1 context)
        {
            this.context = context;
        }

        public int Create(MentorCheckpointComment entity)
        {
            return context.MentorCheckpointComments.Add(entity).MentorId;
        }

        public void Delete(MentorCheckpointComment entity)
        {
            context.MentorCheckpointComments.Remove(entity);
        }

        public MentorCheckpointComment Find(params object[] keyValues)
        {
            return context.MentorCheckpointComments.Find(keyValues);
        }

        public IEnumerable<MentorCheckpointComment> Get(Func<MentorCheckpointComment, bool> predicate)
        {
            return context.MentorCheckpointComments.Where(predicate);
        }

        public IEnumerable<MentorCheckpointComment> GetAll()
        {
            return context.MentorCheckpointComments.ToList();
        }

        public int Update(MentorCheckpointComment entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return entity.MentorId;
        }
    }
}
