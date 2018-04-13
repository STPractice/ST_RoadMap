using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EntityAspNetUserClaimRepository : IAspNetUserClaimRepository
    {
        private readonly Entities1 context;

        public EntityAspNetUserClaimRepository(Entities1 context)
        {
            this.context = context;
        }

        public int Create(AspNetUserClaim entity)
        {
            return context.AspNetUserClaims.Add(entity).Id;
        }

        public void Delete(AspNetUserClaim entity)
        {
            context.AspNetUserClaims.Remove(entity);
        }

        public AspNetUserClaim Find(params object[] keyValues)
        {
            return context.AspNetUserClaims.Find(keyValues);
        }

        public IEnumerable<AspNetUserClaim> Get(Func<AspNetUserClaim, bool> predicate)
        {
            return context.AspNetUserClaims.Where(predicate);
        }

        public IEnumerable<AspNetUserClaim> GetAll()
        {
            return context.AspNetUserClaims.ToList();
        }

        public int Update(AspNetUserClaim entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return entity.Id;
        }
    }
}
