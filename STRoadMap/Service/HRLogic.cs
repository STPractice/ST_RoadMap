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
        private readonly IUnitOfWork UoW;

        public HRLogic(IUnitOfWork uoW)
        {
            UoW = uoW;
        }
    }
}