using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STRoadMap
{

    public interface ITest
    {
        string ReturnString();
    }
    public class Test : ITest
    {
        public string ReturnString()
        {
            return "OH HELLO THERE!!!";
        }
    }

}