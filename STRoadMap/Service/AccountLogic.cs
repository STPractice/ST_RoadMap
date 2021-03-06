﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AccountLogic: Extensibility.IAccountLogic
    {
        IUnitOfWork UoW;

        public AccountLogic(IUnitOfWork uoW)
        {
            this.UoW = uoW;
        }
        public bool CreateEmployee(string Id, string userName)
        {
            this.UoW.Employees.Create(new Employee() { UserId=Id, Name=userName });
            return UoW.Commit();
        }
    }
}
