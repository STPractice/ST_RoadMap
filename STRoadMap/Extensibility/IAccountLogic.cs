using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensibility
{
    public interface IAccountLogic
    {
        bool CreateEmployee(string Id, string Name);
    }
}
