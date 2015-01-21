#region USING
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using ExtDirect;
using ExtDirect.Direct;
using IST.DB.SQLCreater;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

using CISR.Controller.Model.Basic;
using CISR.Controller.Model.Basic.Table;
using CISR.Controller.Model.Basic.Table.Record;
using CISR;
using System.Text;
using IST.Util;
using System.Data;
using System.Diagnostics;
using CISR.Model.Cr;
using CISR.Model.Cr.Table;
using CISR.Model.Cr.Table.Record;

#endregion
[DirectService("TimeAction")]
public class TimeAction : BaseAction
{

    [DirectMethod("loadTime", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadTime(string pTimeType, string pageNo, string limitNo, string sort, string dir, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        CISR.Model.Cr.CrModel model = new CISR.Model.Cr.CrModel();
        AttendantV_Record table = new AttendantV_Record();
        OrderLimit orderLimit = null;
        #endregion
        try
        {  /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            /*是Store操作一下就可能含有分頁資訊。*/
            orderLimit = ExtDirect.Direct.Helper.Order.getOrderLimit(pageNo, limitNo, sort, dir);
            /*取得總資料數*/

            /*取得資料*/
            
            var data = model.getTime_By_TimeType(pTimeType,orderLimit);
            var totalCount = data.Count();
            if (data.Count > 0)
            {
                /*將List<RecordBase>變成JSON字符串*/
                jobject = JsonHelper.RecordBaseListJObject(data);
            }
            /*使用Store Std out 『Sotre物件標準輸出格式』*/
            return ExtDirect.Direct.Helper.Store.OutputJObject(jobject, totalCount);
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            /*將Exception轉成EXT Exception JSON格式*/
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }





    


}

