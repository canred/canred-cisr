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
[DirectService("KpiAction")]
public class KpiAction : BaseAction
{

    
    [DirectMethod("loadVKpi", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadVKpi(string companyUuid,string keyword,string timeType, string pageNo, string limitNo, string sort, string dir, Request request)
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
            var data = model.getVKpi(companyUuid,keyword, timeType, orderLimit);
            var totalCount = model.getVKpi_Count(companyUuid, keyword, timeType);
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

    [DirectMethod("loadVKpiItem", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadVKpiItem(string pKpiHeadUuid,  string pageNo, string limitNo, string sort, string dir, Request request)
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
            var data = model.getVKpiItem(pKpiHeadUuid, orderLimit);
            var totalCount = model.getVKpiItem_Count(pKpiHeadUuid);
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
    [DirectMethod("infoKpiHead", DirectAction.Load, MethodVisibility.Visible)]
    public JObject infoKpiHead(string pUuid, Request request)
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
            var data = model.getKpiHead_By_Uuid(pUuid);

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

    [DirectMethod("submitKpiHead", DirectAction.FormSubmission, MethodVisibility.Visible)]
    public JObject submitKpiHead(string ZH_DESC,
string E_NOTICE,
string UUID,
string CREATE_DATE,
string UPDATE_DATE,
string IS_ACTIVE,
string COMPANY_UUID,
string KPI_ID,
string C_DESC,
string E_DESC,
string UNIT,
string DEGREE,
string C_NOTICE,
string SIGNAL,
string TIME_TYPE,
string C_DESC_GROUP,
string E_DESC_GROUP,
string INCLUDE_KPI,
string CALCULTE_ORD,
string NEED_SUMMARY,
string NEED_SECURITY,
        string ZH_NOTICE,
        string ALIASES,
 HttpRequest request)
    {


        #region Declare
        var action = SubmitAction.None;
        CrModel model = new CrModel();
        KpiHead_Record record = new KpiHead_Record();
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
                record = model.getKpiHead_By_Uuid(UUID).AllRecord().First();
            }
            else
            {
                action = SubmitAction.Create;
                record.UUID = IST.Util.UID.Instance.GetUniqueID();
                record.CREATE_DATE = DateTime.Now;
            }
            record.COMPANY_UUID = COMPANY_UUID;
            //record.CREATE_DATE = null;
            record.C_DESC = C_DESC;
            record.C_DESC_GROUP = C_DESC_GROUP;
            record.C_NOTICE = C_NOTICE;
            if (CALCULTE_ORD!=null && CALCULTE_ORD.Trim().Length > 0)
                record.CALCULTE_ORD =  Convert.ToInt16(CALCULTE_ORD);

            record.COMPANY_UUID = COMPANY_UUID;

            if (DEGREE != null && DEGREE.Trim().Length > 0)
                record.DEGREE = Convert.ToInt16(DEGREE);
            record.E_DESC = E_DESC;
            record.E_DESC_GROUP = E_DESC_GROUP;
            record.E_NOTICE = E_NOTICE;
            if (INCLUDE_KPI != null && INCLUDE_KPI.Trim().Length>0)
                record.INCLUDE_KPI = INCLUDE_KPI;
            else
                record.INCLUDE_KPI = "N";
            record.IS_ACTIVE = IS_ACTIVE;
            record.KPI_ID = KPI_ID;
            record.NEED_SECURITY = NEED_SECURITY;
            record.NEED_SUMMARY = NEED_SUMMARY;


            record.SIGNAL = Convert.ToInt16(SIGNAL);
            record.TIME_TYPE = TIME_TYPE;
            record.UNIT = UNIT;            
            record.ZH_DESC = ZH_DESC;
            record.ZH_NOTICE = ZH_NOTICE;
            record.ALIASES = ALIASES; 


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



    [DirectMethod("loadKpiFormula", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadKpiFormula(string pKpiHeadUuid, string pageNo, string limitNo, string sort, string dir, Request request)
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
            var data = model.getKpiFormula_By_KpiHeadUuid(pKpiHeadUuid, orderLimit);
            var totalCount = model.getKpiFormula_By_KpiHeadUuid_Count(pKpiHeadUuid);
           
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

    [DirectMethod("infoKpiFormula", DirectAction.Load, MethodVisibility.Visible)]
    public JObject infoKpiFormula(string pUuid, Request request)
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
            var data = model.getKpiFormula_By_Uuid(pUuid);

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


    [DirectMethod("infoKpiPackage", DirectAction.Load, MethodVisibility.Visible)]
    public JObject infoKpiPackage(string pUuid, Request request)
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
            var data = model.getKpiPackage_By_Uuid(pUuid);

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
    [DirectMethod("submitKpiFormula", DirectAction.FormSubmission, MethodVisibility.Visible)]
    public JObject submitKpiFormula(string ALGORITHM_MAN,
string UUID,
string CREATE_DATE,
string UPDATE_DATE,
string KPI_HEAD_UUID,
string TIME_ID,
string ALGORITHM,
string DESCRIPTION,
        string JSS,
 HttpRequest request)
    {


        #region Declare
        var action = SubmitAction.None;
        CrModel model = new CrModel();
        KpiFormula_Record record = new KpiFormula_Record();
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
                record = model.getKpiFormula_By_Uuid(UUID).AllRecord().First();
            }
            else
            {
                action = SubmitAction.Create;
                record.UUID = IST.Util.UID.Instance.GetUniqueID();
                record.CREATE_DATE = DateTime.Now;

                #region check data
                var checkOne = model.getKpiFormula_By_KpiHeadUuid_TimeId(KPI_HEAD_UUID, TIME_ID, null);
                if (checkOne.Count > 0)
                {
                    throw new Exception("此時間性指標("+TIME_ID+")已經存在!");
                }
                #endregion
            }
            record.ALGORITHM = ALGORITHM;
            //record.CREATE_DATE = null;
            record.ALGORITHM_MAN = ALGORITHM_MAN;
            record.DESCRIPTION = DESCRIPTION;
            record.KPI_HEAD_UUID = KPI_HEAD_UUID;
            record.TIME_ID = TIME_ID;
            record.JSS = JSS;
          
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


    [DirectMethod("destoryKpiFormula", DirectAction.Load, MethodVisibility.Visible)]
    public JObject destoryKpiFormula(string UUID, Request request)
    {


        #region Declare        
        CrModel model = new CrModel();
        KpiFormula_Record record = new KpiFormula_Record();
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
            /*
             * 所有Form的動作最終是使用Submit的方式將資料傳出；
             * 必須有一個特徵來判斷使用者，執行的動作；
             */
            if (UUID.Trim().Length > 0)
            {                
                record = model.getKpiFormula_By_Uuid(UUID).AllRecord().First();
                record.gotoTable().Delete(record);
            }
           
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }


    [DirectMethod("loadVKpiNotIncludePackageUuid", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadVKpiNotIncludePackageUuid(string companyUuid,string packageUuid, string keyword, string timeType, string pageNo, string limitNo, string sort, string dir, Request request)
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
            var data = model.getVKpi(companyUuid, keyword, timeType, orderLimit);
            var drsSelect = model.getKpiPackageItem_By_PackageHeadUuid(packageUuid, null);
            var drsUnselect = new List<VKpi_Record>();
            foreach (var item in data)
            {
                var isExist = drsSelect.Count(c => c.KPI_HEAD_UUID.Equals(item.KPI_HEAD_UUID)) > 0 ? true : false;
                if (isExist==false)
                {
                    drsUnselect.Add(item.Clone());
                }
            }
            var totalCount = drsUnselect.Count();

            if (drsUnselect.Count > 0)
            {
                /*將List<RecordBase>變成JSON字符串*/
                jobject = JsonHelper.RecordBaseListJObject(drsUnselect);
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


    [DirectMethod("loadVKpiIncludePackageUuid", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadVKpiIncludePackageUuid(string companyUuid, string packageUuid, string keyword, string timeType, string pageNo, string limitNo, string sort, string dir, Request request)
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
            var data = model.getVKpi(companyUuid, keyword, timeType, orderLimit);
            var drsSelect = model.getKpiPackageItem_By_PackageHeadUuid(packageUuid, null);
            var drKpiPackage = model.getKpiPackage_By_Uuid(packageUuid).AllRecord().First();
            var drsUnselect = new List<VKpi_Record>();
            foreach (var item in data)
            {
                var isExist = drsSelect.Count(c => c.KPI_HEAD_UUID.Equals(item.KPI_HEAD_UUID)) > 0 ? true : false;
                if (isExist == true)
                {
                    if (drKpiPackage.SCOPE_MONTH_ID.Trim().Length > 0)
                    {
                        //if (item.TIME_ID.Trim().Length > 0 && Convert.ToInt32(item.TIME_ID) <= Convert.ToInt32(drKpiPackage.SCOPE_MONTH_ID))
                        //{
                        if (item.TIME_ID.Trim().Length > 0)
                        {
                            drsUnselect.Add(item.Clone());
                        }
                        //}
                    }
                }
            }
            var totalCount = drsUnselect.Count();

            if (drsUnselect.Count > 0)
            {
                /*將List<RecordBase>變成JSON字符串*/
                jobject = JsonHelper.RecordBaseListJObject(drsUnselect);
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


    [DirectMethod("KpiPackageAddKpiHead", DirectAction.Store, MethodVisibility.Visible)]
    public JObject KpiPackageAddKpiHead(string kpi_package_uuid,string pKpi_head_uuid, Request request)
    {
        #region Declare        
        CrModel model = new CrModel();
        KpiPackageItem_Record record = new KpiPackageItem_Record();
        var arrKpi_head_uuid = pKpi_head_uuid.Split(';');
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


            
            /*
             * 所有Form的動作最終是使用Submit的方式將資料傳出；
             * 必須有一個特徵來判斷使用者，執行的動作；
             */
            var drKpiPackage = model.getKpiPackage_By_Uuid(kpi_package_uuid).AllRecord().First();
            if (drKpiPackage.SCOPE_MONTH_ID == "") {
                throw new Exception("必需先設定指定時間屬性!");
            }
            foreach (var _kpiHeadUuid in arrKpi_head_uuid)
            {
                if (_kpiHeadUuid.Trim().Length > 0)
                {
                    record.UUID = IST.Util.UID.Instance.GetUniqueID();
                    record.KPI_HEAD_UUID = _kpiHeadUuid;
                    record.KPI_PACKAGE_UUID = kpi_package_uuid;
                    record.gotoTable().Insert_Empty2Null(record);

                    adjustOneKpiPackageItem(kpi_package_uuid, record.UUID);
                }
            }

            
            //adjustAllKpiPackageItem(kpi_package_uuid);
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("KpiPackageRemoveKpiHead", DirectAction.Store, MethodVisibility.Visible)]
    public JObject KpiPackageRemoveKpiHead(string kpi_package_uuid,
string pKpi_head_uuid,
 Request request)
    {


        #region Declare
        
        CrModel model = new CrModel();
        KpiPackageItem_Record record = new KpiPackageItem_Record();
        var arrKpiHeadUuid = pKpi_head_uuid.Split(';');
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
            /*
             * 所有Form的動作最終是使用Submit的方式將資料傳出；
             * 必須有一個特徵來判斷使用者，執行的動作；
             */

            foreach (var _kpiHeadUuid in arrKpiHeadUuid)
            {
                if (_kpiHeadUuid.Trim().Length > 0)
                {
                    var drs = model.getKpiPackageItem_By_PackageHeadUuid_KpiHeadUuid(kpi_package_uuid, _kpiHeadUuid);
                    foreach (var item in drs)
                    {
                       
                        var drsKpiPackageExpend = model.getKpiPackageExpend_By_KpiPackageItemUuid(item.UUID);
                        foreach(var item2 in drsKpiPackageExpend){
                            item2.gotoTable().Delete(item2); 
                        }

                        item.gotoTable().Delete(item);
                    }
                }
            }

            
            //adjustAllKpiPackageItem(kpi_package_uuid);
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    //public void adjustAllKpiPackageItem(string pKpiPackageUuid)
    //{
    //    CrModel model = new CrModel();
    //    try
    //    {
    //        var drKpiPackage = model.getKpiPackage_By_Uuid(pKpiPackageUuid).AllRecord().First();
    //        if (drKpiPackage.SCOPE_MONTH_ID == "")
    //        {
    //            throw new Exception("指定時間屬性必須先設定!");
    //        }
    //        //先刪除原來的所有資料
    //        var drsDelete = model.getKpiPackageExpend_By_KpiPackageUuid(pKpiPackageUuid);
    //        foreach (var item in drsDelete)
    //        {
    //            item.gotoTable().Delete(item);
    //        }


    //        //開始設定新的資料
    //        var drsKpiPackageItem = drKpiPackage.Link_KpiPackageItem_By_KpiPackageUuid();
    //        var _drsVKpi = new List<VKpi_Record>();
    //        foreach (var item in drsKpiPackageItem)
    //        {
    //            var drsVKpi = model.getVKpi_by_KpiHeadUuid(item.KPI_HEAD_UUID, null);

    //            foreach (var kitem in drsVKpi)
    //            {
    //                if (kitem.TIME_ID.Trim().Length > 0 && Convert.ToInt32(kitem.TIME_ID) <= Convert.ToInt32(drKpiPackage.SCOPE_MONTH_ID))
    //                {
    //                    //所有要處理的v_kpi的項目
    //                    _drsVKpi.Add(kitem.Clone());
    //                }
    //            }
    //        }

    //        var arrRawHeadUuid = new List<string>();
    //        foreach (var item in _drsVKpi)
    //        {
    //            var array = item.ALGORITHM.Split(new char[] {
    //                '(',')','{','}' ,'[' ,']' ,'+' ,'-' ,'*' ,'/','!'
    //            });

    //            for (var i = 0; i < array.Length; i++)
    //            {
    //                if (array[i] == "R")
    //                {
    //                    if ((i + 1) <= (array.Length - 1))
    //                    {
    //                        if (arrRawHeadUuid.Contains(array[i + 1]) == false)
    //                        {
    //                            arrRawHeadUuid.Add(array[i + 1]);
    //                        }
    //                    }
    //                }
    //            }
    //        }

    //        for (var i = arrRawHeadUuid.Count - 1; i >= 0; i--)
    //        {
    //            if (model.getRawHead_By_Uuid(arrRawHeadUuid[i]).AllRecord().Count() > 0)
    //            {
    //                /*有效的Raw Head*/
    //            }
    //            else
    //            {
    //                arrRawHeadUuid.Remove(arrRawHeadUuid[i]);
    //            }
    //        }

    //        foreach (var rawHead in arrRawHeadUuid)
    //        {
    //            KpiPackageExpend_Record n = new KpiPackageExpend_Record();
    //            n.UUID = IST.Util.UID.Instance.GetUniqueID();
    //            n.KPI_PACKAGE_UUID = drKpiPackage.UUID;
    //            n.RAW_HEAD_UUID = rawHead;
    //            n.gotoTable().Insert_Empty2Null(n);
    //        }



    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

    public void adjustOneKpiPackageItem(string pKpiPackageUuid,string pKpiPackageItemUuid)
    {
        CrModel model = new CrModel();
        try
        {
            var drKpiPackage = model.getKpiPackage_By_Uuid(pKpiPackageUuid).AllRecord().First();
            if (drKpiPackage.SCOPE_MONTH_ID == "")
            {
                throw new Exception("指定時間屬性必須先設定!");
            }
            //先刪除原來的所有資料

            var drsDelete = model.getKpiPackageExpend_By_KpiPackageUuid(pKpiPackageItemUuid);
            foreach (var item in drsDelete)
            {
                item.gotoTable().Delete(item);
            }


            //開始設定新的資料
            //var drKpiPackageItem = drKpiPackage.Link_KpiPackageItem_By_KpiPackageUuid();
            var drKpiPackageItem = model.getKpiPackageItem_By_Uuid(pKpiPackageItemUuid).AllRecord().First();
            var _drsVKpi = new List<VKpi_Record>();
            

            var drsVKpi = model.getVKpi_by_KpiHeadUuid(drKpiPackageItem.KPI_HEAD_UUID, null);

            foreach (var kitem in drsVKpi)
            {
                var tmpTimeId = "";
                if (kitem.TIME_TYPE == "year")
                {
                    if (drKpiPackage.SCOPE_MONTH_ID.Trim().Length > 4) {
                        tmpTimeId = drKpiPackage.SCOPE_MONTH_ID.Substring(0, 4);
                    }
                    else if (drKpiPackage.SCOPE_MONTH_ID.Trim().Length == 4)
                    {
                        tmpTimeId = drKpiPackage.SCOPE_MONTH_ID;
                    }
                    else
                    {
                        throw new Exception("ERROR 20141109-1");
                    }

                }
                else if(kitem.TIME_TYPE == "month")
                {
                    if (drKpiPackage.SCOPE_MONTH_ID.Trim().Length == 4)
                    {
                        tmpTimeId = drKpiPackage.SCOPE_MONTH_ID + "01";
                    }
                    else if(drKpiPackage.SCOPE_MONTH_ID.Trim().Length==6){
                        tmpTimeId = drKpiPackage.SCOPE_MONTH_ID;
                    }
                    else
                    {
                        throw new Exception("ERROR 20141109-2");
                    }
                }
                else
                {
                    throw new Exception("ERROR 20141109-3");
                }

                //if (kitem.TIME_ID.Trim().Length > 0 && Convert.ToInt32(kitem.TIME_ID) <= Convert.ToInt32(drKpiPackage.SCOPE_MONTH_ID))
                if (kitem.TIME_ID.Trim().Length > 0 && Convert.ToInt32(kitem.TIME_ID) <= Convert.ToInt32(tmpTimeId))
                {
                    //所有要處理的v_kpi的項目
                    _drsVKpi.Add(kitem.Clone());
                }
            }
            

            var arrRawHeadUuid = new List<string>();
            foreach (var item in _drsVKpi)
            {
                var array = item.ALGORITHM.Split(new char[] {
                    '(',')','{','}' ,'[' ,']' ,'+' ,'-' ,'*' ,'/','!'
                });

                for (var i = 0; i < array.Length; i++)
                {
                    if (array[i] == "R")
                    {
                        if ((i + 1) <= (array.Length - 1))
                        {
                            if (arrRawHeadUuid.Contains(array[i + 1]) == false)
                            {
                                arrRawHeadUuid.Add(array[i + 1]);
                            }
                        }
                    }
                }
            }

            for (var i = arrRawHeadUuid.Count - 1; i >= 0; i--)
            {
                if (model.getRawHead_By_Uuid(arrRawHeadUuid[i]).AllRecord().Count() > 0)
                {
                    /*有效的Raw Head*/
                }
                else
                {
                    arrRawHeadUuid.Remove(arrRawHeadUuid[i]);
                }
            }

            foreach (var rawHead in arrRawHeadUuid)
            {
                KpiPackageExpend_Record n = new KpiPackageExpend_Record();
                n.UUID = IST.Util.UID.Instance.GetUniqueID();
                n.KPI_PACKAGE_UUID = drKpiPackage.UUID;
                n.RAW_HEAD_UUID = rawHead;
                n.KPI_HEAD_UUID = drKpiPackageItem.KPI_HEAD_UUID;
                n.KPI_PACKAGE_ITEM_UUID = drKpiPackageItem.UUID;
                n.gotoTable().Insert_Empty2Null(n);
            }



        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //public void adjustAllKpiPackageItem(string pKpiPackageUuid) {
    //    CrModel model = new CrModel();
    //    try {
    //        var drKpiPackage = model.getKpiPackage_By_Uuid(pKpiPackageUuid).AllRecord().First();
    //        if (drKpiPackage.SCOPE_MONTH_ID == "") {
    //            throw new Exception("指定時間屬性必須先設定!");
    //        }
    //        //先刪除原來的所有資料
    //        var drsDelete = model.getKpiPackageExpend_By_KpiPackageUuid(pKpiPackageUuid);
    //        foreach (var item in drsDelete) {
    //            item.gotoTable().Delete(item);
    //        }


    //        //開始設定新的資料
    //        var drsKpiPackageItem = drKpiPackage.Link_KpiPackageItem_By_KpiPackageUuid();
    //        var _drsVKpi = new List<VKpi_Record>();
    //        foreach (var item in drsKpiPackageItem) {
    //            var drsVKpi = model.getVKpi_by_KpiHeadUuid(item.KPI_HEAD_UUID,null);

    //            foreach (var kitem in drsVKpi) {
    //                if (kitem.TIME_ID.Trim().Length >0 && Convert.ToInt32(kitem.TIME_ID) <= Convert.ToInt32(drKpiPackage.SCOPE_MONTH_ID))
    //                {
    //                    //所有要處理的v_kpi的項目
    //                    _drsVKpi.Add(kitem.Clone());
    //                }  
    //            }
    //        }

    //        var arrRawHeadUuid = new List<string>();
    //        foreach (var item in _drsVKpi) {
    //            var array = item.ALGORITHM.Split(new char[] {
    //                '(',')','{','}' ,'[' ,']' ,'+' ,'-' ,'*' ,'/','!'
    //            });

    //            for (var i = 0; i < array.Length; i++) {
    //                if (array[i] == "R") {
    //                    if ((i + 1) <= (array.Length - 1))
    //                    {
    //                        if (arrRawHeadUuid.Contains(array[i + 1]) == false)
    //                        {
    //                            arrRawHeadUuid.Add(array[i + 1]);
    //                        }                            
    //                    }                        
    //                }
    //            }
    //        }

    //        for (var i = arrRawHeadUuid.Count-1; i >=0; i--) {
    //            if (model.getRawHead_By_Uuid(arrRawHeadUuid[i]).AllRecord().Count() > 0)
    //            {
    //                /*有效的Raw Head*/
    //            }
    //            else {
    //                arrRawHeadUuid.Remove(arrRawHeadUuid[i]);
    //            }
    //        }

    //        foreach (var rawHead in arrRawHeadUuid) {
    //            KpiPackageExpend_Record n = new KpiPackageExpend_Record();
    //            n.UUID = IST.Util.UID.Instance.GetUniqueID();
    //            n.KPI_PACKAGE_UUID = drKpiPackage.UUID;
    //            n.RAW_HEAD_UUID = rawHead;
    //            n.gotoTable().Insert_Empty2Null(n);
    //        }



    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}


    [DirectMethod("loadVKpiExtNotIncludeFrame", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadVKpiExtNotIncludeFrame(string pPackageUuid, string pFrameHeadUuid, string keyword, string pageNo, string limitNo, string sort, string dir, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        CISR.Model.Cr.CrModel model = new CISR.Model.Cr.CrModel();
       // AttendantV_Record table = new AttendantV_Record();
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
            var data = model.getVKpi_By_KpiPackageUuid_KeyWord(pPackageUuid, keyword, orderLimit);
            var drsSelect = model.getFrameItem_By_FrameHeadUuid(pFrameHeadUuid, new OrderLimit());
            var drsUnselect = new List<VKpiExp_Record>();
            System.Collections.Hashtable htAddRawId = new System.Collections.Hashtable();
            foreach (var item in data)
            {
                var isExist = drsSelect.Count(c => c.RAW_HEAD_UUID.Equals(item.RAW_HEAD_UUID)) > 0 ? true : false;
                if (isExist == false)
                {
                    if (htAddRawId.ContainsKey(item.RAW_ID) == false) {
                        drsUnselect.Add(item.Clone());
                        htAddRawId.Add(item.RAW_ID, item.RAW_ID);
                    }
                    
                }
            }
            var totalCount = drsUnselect.Count();

            //drsUnselect.Distinct()
            if (drsUnselect.Count > 0)
            {
                /*將List<RecordBase>變成JSON字符串*/
                jobject = JsonHelper.RecordBaseListJObject(drsUnselect);
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

    [DirectMethod("loadKpiPackage", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadKpiPackage(string pageNo, string limitNo, string sort, string dir, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        CISR.Model.Cr.CrModel model = new CISR.Model.Cr.CrModel();        
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
            var data = model.getKpiPackage_All();
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

   

}

