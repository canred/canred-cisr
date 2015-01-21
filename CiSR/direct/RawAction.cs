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
[DirectService("RawAction")]
public class RawAction : BaseAction
{

    [DirectMethod("loadVRawHead", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadVRawHead(string companyUuid,string timeType,string keyword, string pageNo, string limitNo, string sort, string dir, Request request)
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
            var totalCount = model.getVRawHead_By_CompanyUuid_Keyword_Count(companyUuid, timeType, keyword);
            var data = model.getVRawHead_By_CompanyUuid_Keyword(companyUuid, timeType, keyword, orderLimit);
            
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

    [DirectMethod("loadRawHeadCategory", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadRawHeadCategory(string companyUuid, string pageNo, string limitNo, string sort, string dir, Request request)
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
            
            var data = model.getRawHeadCategory(companyUuid,orderLimit);
            var totalCount = data.Count;
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


    [DirectMethod("infoRawHead", DirectAction.Load, MethodVisibility.Visible)]
    public JObject infoRawHead(string pUuid, Request request)
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
            var data = model.getRawHead_By_Uuid(pUuid);

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

    [DirectMethod("submitRawHead", DirectAction.FormSubmission, MethodVisibility.Visible)]
    public JObject submitRawHead(string uuid,
string create_date,
string update_date,
string is_active,
string company_uuid,
string raw_id,
string raw_category_uuid,
string c_desc,
string e_desc,
string c_define,
string e_define,
string unit,
string can_null,
string time_type,
string need_desc,
string need_file,
string valuedisplay,
 HttpRequest request)
    {


        #region Declare
        var action = SubmitAction.None;
        CrModel model = new CrModel();
        RawHead_Record record = new RawHead_Record();
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
            if (uuid.Trim().Length > 0)
            {
                action = SubmitAction.Edit;
                record = model.getRawHead_By_Uuid(uuid).AllRecord().First();
            }
            else
            {
                action = SubmitAction.Create;
                record.UUID = IST.Util.UID.Instance.GetUniqueID();
                record.CREATE_DATE = DateTime.Now;
            }
            record.COMPANY_UUID = this.getUser().COMPANY_UUID;
            //record.CREATE_DATE = null;
            record.C_DEFINE = c_define;
            record.C_DESC = c_desc;
            record.CAN_NULL = can_null;
            record.RAW_CATEGORY_UUID = raw_category_uuid;
            record.COMPANY_UUID = company_uuid;
            //record.CREATE_DATE = c_define;
            record.E_DEFINE = e_define;
            record.E_DESC = e_desc;
            record.IS_ACTIVE = is_active;
            record.NEED_DESC = need_desc;           
            record.NEED_FILE = need_file;
            record.RAW_ID = raw_id;
            record.TIME_TYPE = time_type;
            record.UNIT = unit;
            record.VALUEDISPLAY = valuedisplay;
           


            record.UPDATE_DATE = DateTime.Now;

            if (action == SubmitAction.Edit)
            {
                record.gotoTable().Update_Empty2Null(record);
            }
            else if (action == SubmitAction.Create)
            {

                record.gotoTable().Insert(record);
                uuid = record.UUID;
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

    [DirectMethod("submitRawHeadCategory", DirectAction.FormSubmission, MethodVisibility.Visible)]
    public JObject submitRawHeadCategory(string uuid,
string name,
string description,
string lan_no,
string company_uuid,
 HttpRequest request)
    {


        #region Declare
        var action = SubmitAction.None;
        CrModel model = new CrModel();
        RawHeadCategory_Record record = new RawHeadCategory_Record();
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
            if (uuid.Trim().Length > 0)
            {
                action = SubmitAction.Edit;
                record = model.getRawHeadCategory_By_Uuid(uuid).AllRecord().First();
            }
            else
            {
                action = SubmitAction.Create;
                record.UUID = IST.Util.UID.Instance.GetUniqueID();
                //record.CREATE_DATE = DateTime.Now;
            }        
            record.COMPANY_UUID = company_uuid;
            record.DESCRIPTION = description;
            record.LAN_NO = System.Convert.ToInt16(lan_no);
            record.NAME = name;
            
            //record.UPDATE_DATE = DateTime.Now;
            if (action == SubmitAction.Edit)
            {
                record.gotoTable().Update_Empty2Null(record);
            }
            else if (action == SubmitAction.Create)
            {

                record.gotoTable().Insert(record);
                uuid = record.UUID;
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

