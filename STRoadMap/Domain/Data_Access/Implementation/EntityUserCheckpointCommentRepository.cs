using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EntityUserCheckpointCommentRepository : IUserCheckpointCommentRepository
    {
        private readonly Entities1 context;

        public EntityUserCheckpointCommentRepository(Entities1 context)
        {
            this.context = context;
        }

        public int Create(UserCheckpointComment entity)
        {
            return context.UserCheckpointComments.Add(entity).EmpolyeeId;
        }

        public void Delete(UserCheckpointComment entity)
        {
            context.UserCheckpointComments.Remove(entity);
        }

        public UserCheckpointComment Find(params object[] keyValues)
        {
            return context.UserCheckpointComments.Find(keyValues);
        }

        public IEnumerable<UserCheckpointComment> Get(Func<UserCheckpointComment, bool> predicate)
        {
            return context.UserCheckpointComments.Where(predicate);
        }

        public IEnumerable<UserCheckpointComment> GetAll()
        {
            return context.UserCheckpointComments.ToList();
        }

        public int Update(UserCheckpointComment entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return entity.EmpolyeeId;
        }
    }
}
