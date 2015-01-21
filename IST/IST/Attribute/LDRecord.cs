using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IST.Attribute
{

    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class ISTRecord : System.Attribute
    {
        public ISTRecord()
        {
        }
    }
}
