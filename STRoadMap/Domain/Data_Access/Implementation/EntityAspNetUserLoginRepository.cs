using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EntityAspNetUserLoginRepository : IAspNetUserLoginRepository
    {
        private readonly Entities1 context;

        public EntityAspNetUserLoginRepository(Entities1 context)
        {
            this.context = context;
        }

        public int Create(AspNetUserLogin entity)
        {
            context.AspNetUserLogins.Add(entity);
            return 0;
        }

        public void Delete(AspNetUserLogin entity)
        {
            context.AspNetUserLogins.Remove(entity);
        }

        public AspNetUserLogin Find(params object[] keyValues)
        {
            return context.AspNetUserLogins.Find(keyValues);
        }

        public IEnumerable<AspNetUserLogin> Get(Func<AspNetUserLogin, bool> predicate)
        {
            return context.AspNetUserLogins.Where(predicate);
        }

        public IEnumerable<AspNetUserLogin> GetAll()
        {
            return context.AspNetUserLogins.ToList();
        }

        public int Update(AspNetUserLogin entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return 0;
        }
    }
}
