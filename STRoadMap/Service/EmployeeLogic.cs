using Extensibility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Domain;

namespace Service
{
    public class EmployeeLogic:IEmployeeLogic
    {
        private readonly IUnitOfWork UoW;

        public EmployeeLogic(IUnitOfWork uoW)
        {
            UoW = uoW;
        }
    }
}