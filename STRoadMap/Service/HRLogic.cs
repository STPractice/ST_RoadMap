using Extensibility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Domain;

namespace Service
{
    public class HRLogic:IHRLogic
    {
        IUnitOfWork UoW;

        public HRLogic(IUnitOfWork uoW)
        {
            this.UoW = uoW;
        }

        public IEnumerable<Specialization> GetSpecializationList()
        {            
            return UoW.Specializations.GetAll();            
        }

        public bool DeleteSpecialization (int id)
        {
            if (UoW.Specializations.Find(id) != null)
            {
                UoW.Specializations.Delete(UoW.Specializations.Find(id));
                return UoW.Commit();
            }
            else
            {
                return false;
            }
        }
    }
}