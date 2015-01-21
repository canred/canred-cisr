using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IST.Attribute
{

    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class ISTTableView : System.Attribute
    {
        private string tableName = "";
        private bool isTable = true;
        public ISTTableView(string name,bool isTable)
        {
            this.tableName = name;
            this.isTable = isTable;
        }
        public string getName() {
            return tableName;
        }
        public bool getIsTable() {
            return isTable;
        }
    }
}
