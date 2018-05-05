using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EntityEmployeeRepository : IEmployeeRepository
    {
        private readonly Entities1 context;

        public EntityEmployeeRepository(Entities1 context)
        {
            this.context = context;
        }

        public int Create(Employee entity)
        {
            return context.Employees.Add(entity).EmpolyeeId;
        }

        public void Delete(Employee entity)
        {
            context.Employees.Remove(entity);
        }

        public Employee Find(params object[] keyValues)
        {
            return context.Employees.Find(keyValues);
        }

        public IEnumerable<Employee> Get(Func<Employee, bool> predicate)
        {
            return context.Employees.Where(predicate);
        }

        public IEnumerable<Employee> GetAll()
        {
            return context.Employees.ToList();
        }

        public int Update(Employee entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return entity.EmpolyeeId;
        }
        public Employee FindByUserId(string id)
        {
            foreach (Employee employee in context.Employees)
            {
                if(employee.UserId==id) return employee;
            }
            return null;
        }
    }
}
