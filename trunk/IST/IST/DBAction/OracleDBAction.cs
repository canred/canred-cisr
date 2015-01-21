using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IST.DB;
using log4net;
using System.Reflection;
namespace IST.DBAction
{
    public class OracleDBAction: IST.DB.IDBAction
    {
        public static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public TableBase Save(ref TableBase tbase,RecordBase record)
        {
            return tbase;
        }
        public TableBase Update(ref TableBase tbase, RecordBase record)
        {
            return tbase;
        }
        public TableBase Delete(ref TableBase tbase, RecordBase record)
        {
            return tbase;
        }
        public TableBase SaveAll(ref TableBase tbase)
        {
            return tbase;
        }
        public TableBase UpdateAll(ref TableBase tbase)
        {
            return tbase;
        }
        public TableBase DeleteAll(ref TableBase tbase)
        {
            return tbase;
        }
    }
}
