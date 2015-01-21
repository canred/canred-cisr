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
[DirectService("ParameterAction")]
public class ParameterAction : BaseAction
{

    [DirectMethod("loadVParameterQuery", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadVParameterQuery(string companyuuid,string keyword, string pageNo, string limitNo, string sort, string dir, Request request)
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
            var totalCount = model.getVParameterQuery_By_KeyWord_Count(companyuuid,keyword);
            var data = model.getVParameterQuery_By_KeyWord(companyuuid,keyword, orderLimit);
            
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



    [DirectMethod("loadVParameterQueryWithParameter", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadVParameterQueryWithParameter(string pParameterHeadUuid, string pageNo, string limitNo, string sort, string dir, Request request)
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
            var totalCount = model.getVParameterQuery_By_ParameterHeadUuid_RegionNameIsNotNull_Count(pParameterHeadUuid);
            var data = model.getVParameterQuery_By_ParameterHeadUuid_RegionNameIsNotNull(pParameterHeadUuid, orderLimit);
            
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
    [DirectMethod("infoParameterHead", DirectAction.Load, MethodVisibility.Visible)]
    public JObject infoParameterHead(string pUuid, Request request)
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
            var data = model.getParameterHead_By_Uuid(pUuid);

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

    [DirectMethod("infoParameterItem", DirectAction.Load, MethodVisibility.Visible)]
    public JObject infoParameterItem(string pUuid, Request request)
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
            var data = model.getParameterItem_By_Uuid(pUuid);

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

    [DirectMethod("infoParameterMonth", DirectAction.Load, MethodVisibility.Visible)]
    public JObject infoParameterMonth(string pUuid, Request request)
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
            var data = model.getParameterMonth_By_Uuid(pUuid);

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

    [DirectMethod("submitParameterHead", DirectAction.FormSubmission, MethodVisibility.Visible)]
    public JObject submitParameterHead(String UUID,
String CREATE_DATE,
String UPDATE_DATE,
String IS_ACTIVE,
String NAME,
String DESCRIPTION,
String VALUE,
String COMPANY_UUID,
String IS_PUBLIC,
 HttpRequest request)
    {


        #region Declare
        var action = SubmitAction.None;
        CrModel model = new CrModel();
        ParameterHead_Record record = new ParameterHead_Record();
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
                record = model.getParameterHead_By_Uuid(UUID).AllRecord().First();
            }
            else
            {
                action = SubmitAction.Create;
                record.UUID = IST.Util.UID.Instance.GetUniqueID();
                record.CREATE_DATE = DateTime.Now;
            }
            record.COMPANY_UUID = COMPANY_UUID;

            record.NAME = NAME;
            record.DESCRIPTION = DESCRIPTION;
            record.VALUE = System.Convert.ToDecimal(VALUE);
            record.IS_PUBLIC = IS_PUBLIC;
            record.IS_ACTIVE = IS_ACTIVE;

            record.UPDATE_DATE = DateTime.Now;

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


    [DirectMethod("submitParameterItem", DirectAction.FormSubmission, MethodVisibility.Visible)]
    public JObject submitParameterItem(String UUID,
String CREATE_DATE,
String UPDATE_DATE,
String IS_ACTIVE,
String PARAMETER_HEAD_UUID,
String REGION_UUID,
String DESCRIPTION,
String VALUE,
 HttpRequest request)
    {


        #region Declare
        var action = SubmitAction.None;
        CrModel model = new CrModel();
        ParameterItem_Record record = new ParameterItem_Record();
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
                record = model.getParameterItem_By_Uuid(UUID).AllRecord().First();
            }
            else
            {
                action = SubmitAction.Create;

                var drParameterItem = model.getParameterItem_By_ParameterHeadUuid_RegionUuid(PARAMETER_HEAD_UUID, REGION_UUID);
                if (drParameterItem.Count > 0) {
                    throw new Exception("此地區性系數已經存在!");
                }
                record.UUID = IST.Util.UID.Instance.GetUniqueID();
                record.CREATE_DATE = DateTime.Now;
            }

           

            record.PARAMETER_HEAD_UUID = PARAMETER_HEAD_UUID;
            record.REGION_UUID = REGION_UUID;
            record.DESCRIPTION = DESCRIPTION;
            record.VALUE = System.Convert.ToDecimal(VALUE);
            record.DESCRIPTION = DESCRIPTION;
            record.REGION_UUID = REGION_UUID;

            record.UPDATE_DATE = DateTime.Now;

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


    [DirectMethod("submitParameterMonth", DirectAction.FormSubmission, MethodVisibility.Visible)]
    public JObject submitParameterMonth(String UUID,
String CREATE_DATE,
String UPDATE_DATE,
String IS_ACTIVE,
String PARAMETER_ITEM_UUID,
String MONTH_ID,
String DESCRIPTION,
String VALUE,

 HttpRequest request)
    {


        #region Declare
        var action = SubmitAction.None;
        CrModel model = new CrModel();
        ParameterMonth_Record record = new ParameterMonth_Record();
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
                record = model.getParameterMonth_By_Uuid(UUID).AllRecord().First();
            }
            else
            {
                action = SubmitAction.Create;
                var drParameterMonth = model.getParameterMonth_By_ParameterItemUuid_MonthId(PARAMETER_ITEM_UUID, MONTH_ID);
                if (drParameterMonth.Count > 0) {
                    throw new Exception("此時間系數已經存在!");
                }
                record.UUID = IST.Util.UID.Instance.GetUniqueID();
                record.CREATE_DATE = DateTime.Now;
            }
            record.MONTH_ID = MONTH_ID;
            record.DESCRIPTION = DESCRIPTION;
            record.VALUE = System.Convert.ToDecimal(VALUE);
            record.PARAMETER_ITEM_UUID = PARAMETER_ITEM_UUID;
            record.IS_ACTIVE = IS_ACTIVE;

            record.UPDATE_DATE = DateTime.Now;

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

