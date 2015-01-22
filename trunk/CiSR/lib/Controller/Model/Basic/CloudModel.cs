using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IST.Attribute;
using IST.DB;
using log4net;
using System.Reflection;
using IST.DB.SQLCreater;
using CISR.Controller.Model.Cloud.Table;
namespace CISR.Controller.Model.Cloud
{
    [ModelName("Cloud")]
    [ISTDataBase("BASIC")]
    public partial class CloudModel
    {
        public new static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private IST.Config.DataBase.IDataBaseConfigInfo dbc = null;
        public CloudModel() { }
        /*Templete Model A001*/
        public CISR.Controller.Model.Basic.Table.ActiveConnection getActiveConnection_By_Uuid(string pUUID)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Controller.Model.Basic.Table.ActiveConnection activeconnection = new CISR.Controller.Model.Basic.Table.ActiveConnection(dbc);
                activeconnection.Fill_By_PK(pUUID);
                return activeconnection;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

    }
}
