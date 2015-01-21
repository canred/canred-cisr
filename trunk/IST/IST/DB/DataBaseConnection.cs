using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IST.Config.DataBase;
using log4net;
using System.Reflection;
namespace IST.DB
{
    public class DataBaseConnection:IST.DB.ADataBaseConnection
    {
        public new static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public DataBaseConnection(IDataBaseConfigInfo batabaseConfigInfo)
            : base(batabaseConfigInfo)
        { 
        
        }
    }
}
