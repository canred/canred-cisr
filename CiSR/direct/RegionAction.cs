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
[DirectService("RegionAction")]
public class RegionAction : BaseAction
{

    [DirectMethod("loadRegion", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadRegion(string keyword, string pageNo, string limitNo, string sort, string dir, Request request)
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
            var totalCount = model.getRegion_By_Keyword_Count(keyword);
            var data = model.getRegion_By_Keyword(keyword, orderLimit);
            
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


    [DirectMethod("infoRegion", DirectAction.Load, MethodVisibility.Visible)]
    public JObject infoRegion(string pUuid, Request request)
    {
        #region Declare

        CrModel model = new CrModel();
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
            var data = model.getRegion_By_Uuid(pUuid);

            if (data.AllRecord().Count == 1)
            {
                return ExtDirect.Direct.Helper.Form.OutputJObject(JsonHelper.RecordBaseJObject(data.AllRecord().First()));
            }
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(new Exception("Data Not Found!"));
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("submitRegion", DirectAction.FormSubmission, MethodVisibility.Visible)]
    public JObject submitRegion(String UUID,
String REGION_NAME,
String COMPNAY_UUID,
String CREATE_DATE,
String UPDATE_DATE,
String IS_ACTIVE,
String REGION_DESC,
HttpRequest request)
    {


        #region Declare
        var action = SubmitAction.None;
        CrModel model = new CrModel();
        Region_Record record = new Region_Record();
        #endregion
        try
        {  /*Cloud身份檢查*/
            checkUser(request);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            /*
             * 所有Form的動作最終是使用Submit的方式將資料傳出；
             * 必須有一個特徵來判斷使用者，執行的動作；
             */
            if (UUID.Trim().Length > 0)
            {
                action = SubmitAction.Edit;
                record = model.getRegion_By_Uuid(UUID).AllRecord().First();
            }
            else
            {
                action = SubmitAction.Create;
                record.UUID = IST.Util.UID.Instance.GetUniqueID();
                record.CREATE_DATE = DateTime.Now;
            }
            record.REGION_NAME = REGION_NAME;
            record.REGION_DESC = REGION_DESC;
            record.IS_ACTIVE = IS_ACTIVE;
            record.COMPNAY_UUID= this.getUser().COMPANY_UUID;
            record.UPDATE_DATE = System.DateTime.Now;

            if (action == SubmitAction.Edit)
            {
                record.gotoTable().Update_Empty2Null(record);
            }
            else if (action == SubmitAction.Create)
            {
                record.gotoTable().Insert(record);
                UUID = record.UUID;
            }

            System.Collections.Hashtable otherParam = new System.Collections.Hashtable();
            otherParam.Add("UUID", record.UUID);
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(otherParam);
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }



    


}

