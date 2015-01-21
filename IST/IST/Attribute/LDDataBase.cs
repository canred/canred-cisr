using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IST.Attribute
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class ISTDataBase : System.Attribute
    {
        private string database = "";
        public ISTDataBase(string name)
        {
            this.database = name;          
        }
        public string getDataBase() {
            return this.database;
        }
    }
}
