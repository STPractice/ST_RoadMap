using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EntityAspNetUserRepository : IAspNetUserRepository
    {
        private readonly Entities1 context;

        public EntityAspNetUserRepository(Entities1 context)
        {
            this.context = context;
        }

        public int Create(AspNetUser entity)
        {
            context.AspNetUsers.Add(entity);
            return 0;
        }

        public void Delete(AspNetUser entity)
        {
            context.AspNetUsers.Remove(entity);
        }

        public AspNetUser Find(params object[] keyValues)
        {
            return context.AspNetUsers.Find(keyValues);
        }

        public IEnumerable<AspNetUser> Get(Func<AspNetUser, bool> predicate)
        {
            return context.AspNetUsers.Where(predicate);
        }

        public IEnumerable<AspNetUser> GetAll()
        {
            return context.AspNetUsers.ToList();
        }

        public int Update(AspNetUser entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return 0;
        }
    }
}
