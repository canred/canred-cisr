#region USING
using System.Collections;
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
using CISR.Model.Cr.Table;
using CISR.Model.Cr.Table.Record;
using CISR.Model.Cr;
using NPOI;
using NPOI.SS;
using System.IO;
using NPOI;
using NPOI.POIFS;
using NPOI.Util;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
#endregion
[DirectService("UploadJobAction")]
public class UploadJobAction : BaseAction
{
    [DirectMethod("startJob", DirectAction.Load, MethodVisibility.Visible)]
    public JObject startJob(string pTimeType,string startTimeId,string endTimeId,string arrFrameHeadUuid, Request request)
    {
        #region Declare
        BasicModel model = new BasicModel();
        CrModel mod = new CrModel();
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

            System.IO.StreamWriter sw = new System.IO.StreamWriter(CISR.Parameter.Config.ParemterConfigs.GetConfig().TriggerFile, true);
            sw.WriteLine("startJob!" + arrFrameHeadUuid+"!"+pTimeType + "!" + startTimeId + "!" + endTimeId+"!"+getUser().COMPANY_UUID);
            sw.Close();
            

            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
            
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }


    [DirectMethod("loadVUploadJobCount", DirectAction.Load, MethodVisibility.Visible)]
    public JObject loadVUploadJobCount(Request request)
    {
        #region Declare
        CrModel mod = new CrModel();
        List<JObject> jobject = new List<JObject>();
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

            var monthCount = mod.getVUploadJob_By_Attendant_Finish_TimeType_Count(getUser().UUID, "month",0);
            var yearCount = mod.getVUploadJob_By_Attendant_Finish_TimeType_Count(getUser().UUID, "year", 0);


            Hashtable ht = new Hashtable();
            ht.Add("month", monthCount.ToString());
            ht.Add("year", yearCount.ToString());
            /*使用Store Std out 『Sotre物件標準輸出格式』*/
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(ht);


        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }


    [DirectMethod("loadVUploadJobHistoryCount", DirectAction.Load, MethodVisibility.Visible)]
    public JObject loadVUploadJobHistoryCount(Request request)
    {
        #region Declare
        CrModel mod = new CrModel();
        List<JObject> jobject = new List<JObject>();
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

            var monthCount = mod.getVUploadJob_By_FullAttendant_Finish_TimeType_Count(getUser().UUID, "month", 1);
            var yearCount = mod.getVUploadJob_By_FullAttendant_Finish_TimeType_Count(getUser().UUID, "year", 1);


            Hashtable ht = new Hashtable();
            ht.Add("month", monthCount.ToString());
            ht.Add("year", yearCount.ToString());
            /*使用Store Std out 『Sotre物件標準輸出格式』*/
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(ht);


        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }
    [DirectMethod("loadVUploadJob", DirectAction.Load, MethodVisibility.Visible)]
    public JObject loadVUploadJob(string pTimeType, string pTimeId, string pAttendantUuid, string pKeyword , string pFrameHeadUuid,string pageNo,string limitNo,string sort,string dir, Request request)
    {
        #region Declare
        CrModel mod = new CrModel();
        List<JObject> jobject = new List<JObject>();
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

            var orderLimit = ExtDirect.Direct.Helper.Order.getOrderLimit(pageNo, limitNo, sort, dir);
            var data = mod.getVUploadJob_TimeType_TimeId_AttendnatnUuid_Keyword_FrameHeadUuid(pTimeType, pTimeId, pAttendantUuid, pKeyword, pFrameHeadUuid, orderLimit);
            var totalCount  = mod.getVUploadJob_TimeType_TimeId_AttendnatnUuid_Keyword_FrameHeadUuid_Count(pTimeType, pTimeId, pAttendantUuid, pKeyword, pFrameHeadUuid);
            
            if (totalCount > 0)
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
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("loadMyNowVUploadJob", DirectAction.Load, MethodVisibility.Visible)]
    public JObject loadMyNowVUploadJob(string pTimeType, string pTimeId, string pKeyword, string pFrameHeadUuid, string pageNo, string limitNo, string sort, string dir, Request request)
    {
        #region Declare
        CrModel mod = new CrModel();
        List<JObject> jobject = new List<JObject>();
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

            var orderLimit = ExtDirect.Direct.Helper.Order.getOrderLimit(pageNo, limitNo, sort, dir);
            var orderLimit2 = ExtDirect.Direct.Helper.Order.getOrderLimit(pageNo, limitNo, "RAW_ID", "ASC");
            var data = mod.getMyUploadJob_TimeType_TimeId_AttendnatnUuid_Keyword_FrameHeadUuid(pTimeType, pTimeId, getUser().UUID, pKeyword, pFrameHeadUuid, orderLimit2);
            var totalCount = mod.getMyUploadJob_TimeType_TimeId_AttendnatnUuid_Keyword_FrameHeadUuid_Count(pTimeType, pTimeId, getUser().UUID, pKeyword, pFrameHeadUuid);
            if (sort == "TIME_ID" || sort =="RAW_ID") {
                if (dir == "ASC")
                {
                    data = data.OrderBy(c => c.RAW_ID).OrderBy(c => c.TIME_ID).ToList();
                }
                else {
                    data = data.OrderBy(c => c.RAW_ID).OrderByDescending(c => c.TIME_ID).ToList();
                }
            }
            else if (sort == "FULL_FRAME_NAME_LIST" )
            {
                if (dir == "ASC")
                {
                    data = data.OrderBy(c => c.RAW_ID).OrderBy(c => c.FULL_FRAME_NAME_LIST).ToList();
                }
                else
                {
                    data = data.OrderBy(c => c.RAW_ID).OrderByDescending(c => c.FULL_FRAME_NAME_LIST).ToList();
                }
            }
            else if (sort == "RAW_C_DESC")
            {
                if (dir == "ASC")
                {
                    data = data.OrderBy(c => c.RAW_ID).OrderBy(c => c.RAW_C_DESC).ToList();
                }
                else
                {
                    data = data.OrderBy(c => c.RAW_ID).OrderByDescending(c => c.RAW_C_DESC).ToList();
                }
            }
            else if (sort == "VALUE")
            {
                if (dir == "ASC")
                {
                    data = data.OrderBy(c => c.RAW_ID).OrderBy(c => c.VALUE).ToList();
                }
                else
                {
                    data = data.OrderBy(c => c.RAW_ID).OrderByDescending(c => c.VALUE).ToList();
                }
            }
            else if (sort == "FILES_COUNT")
            {
                if (dir == "ASC")
                {
                    data = data.OrderBy(c => c.RAW_ID).OrderBy(c => c.FILES_COUNT).ToList();
                }
                else
                {
                    data = data.OrderBy(c => c.RAW_ID).OrderByDescending(c => c.FILES_COUNT).ToList();
                }
            }
            else if (sort == "EXPLAIN")
            {
                if (dir == "ASC")
                {
                    data = data.OrderBy(c => c.RAW_ID).OrderBy(c => c.EXPLAIN).ToList();
                }
                else
                {
                    data = data.OrderBy(c => c.RAW_ID).OrderByDescending(c => c.EXPLAIN).ToList();
                }
            }

            //

            if (totalCount > 0)
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
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("loadMyHistoryVUploadJob", DirectAction.Load, MethodVisibility.Visible)]
    public JObject loadMyHistoryVUploadJob(string pTimeType, string pTimeId, string pKeyword, string pFrameHeadUuid, string pageNo, string limitNo, string sort, string dir, Request request)
    {
        #region Declare
        CrModel mod = new CrModel();
        List<JObject> jobject = new List<JObject>();
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

            var orderLimit = ExtDirect.Direct.Helper.Order.getOrderLimit(pageNo, limitNo, sort, dir);
            var data = mod.getMyUploadJobHistory_TimeType_TimeId_AttendnatnUuid_Keyword_FrameHeadUuid(pTimeType, pTimeId, getUser().UUID, pKeyword, pFrameHeadUuid, orderLimit);
            var totalCount = mod.getMyUploadJobHistory_TimeType_TimeId_AttendnatnUuid_Keyword_FrameHeadUuid_Count(pTimeType, pTimeId, getUser().UUID, pKeyword, pFrameHeadUuid);

            if (totalCount > 0)
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
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    private void addLog(string pUploadJobUuid,string msg) {
        CrModel mod = new CrModel();
        try
        {
            UploadJobLog_Record newRecord = new UploadJobLog_Record();
            newRecord.UUID = IST.Util.UID.Instance.GetUniqueID();
            newRecord.UPLOAD_JOB_UUID = pUploadJobUuid;
            newRecord.SEQ = 1;
            newRecord.CREATE_DATE = DateTime.Now;
            newRecord.ATTENDANT_UUID = this.getUser().UUID;
            newRecord.MSG = msg;

            var drsUploadJobLog = mod.getUploadJobLog_By_UploadJobUuid(pUploadJobUuid);
            if (drsUploadJobLog.Count > 0)
            {
                newRecord.SEQ = drsUploadJobLog.Max(c => c.SEQ) + 1;
            }
            newRecord.gotoTable().Insert_Empty2Null(newRecord);
        }
        catch (Exception ex) { 
        
        }
    }


    [DirectMethod("next", DirectAction.Load, MethodVisibility.Visible)]
    public JObject next(string pUuid,string msg, Request request)
    {
        #region Declare
        CrModel mod = new CrModel();
        List<JObject> jobject = new List<JObject>();
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

            var drUploadJob = mod.getUploadJob_By_Uuid(pUuid).AllRecord().First();
            if (drUploadJob != null)
            {
                if (drUploadJob.STATUS < 5)
                {
                    var lastStep = 0;
                    if (drUploadJob.DWG5_GID != "")
                    {
                        lastStep = 5;
                    }
                    else if (drUploadJob.DWG4_GID != "")
                    {
                        lastStep = 4;
                    }
                    else if (drUploadJob.DWG3_GID != "")
                    {
                        lastStep = 3;
                    }
                    else if (drUploadJob.DWG2_GID != "")
                    {
                        lastStep = 2;
                    }
                    else if (drUploadJob.DWG1_GID == "")
                    {
                        lastStep = 1;
                    }

                    if (drUploadJob.STATUS < lastStep && drUploadJob.STATUS < 5)
                    {
                        string nextAttendantUuidString = "";
                        string lastAttendantUuidString = "";
                        if (drUploadJob.STATUS == 4) {
                            nextAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG5_GID);
                            lastAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG4_GID);
                        }
                        else if (drUploadJob.STATUS == 3)
                        {
                            nextAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG4_GID);
                            lastAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG3_GID);
                        }
                        else if (drUploadJob.STATUS == 2)
                        {
                            nextAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG3_GID);
                            lastAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG2_GID);
                        }
                        else if (drUploadJob.STATUS == 1)
                        {
                            nextAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG2_GID);
                            lastAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG1_GID);
                        }
                        drUploadJob.STATUS++;
                        drUploadJob.NOW_ATTENDANT_UUID = nextAttendantUuidString;
                        drUploadJob.LAST_ATTENDANT_UUID = lastAttendantUuidString;
                    }
                    else {
                        drUploadJob.FINISH = 1;
                    }     
                    
                    drUploadJob.gotoTable().Update_Empty2Null(drUploadJob);
                    msg = "管理者"+getUser().C_NAME+"執行無條件進關行為";
                    addLog(drUploadJob.UUID, msg);
                }                
            }
            else {
                throw new Exception("無法取得資料");
            }

            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();


        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("nextBatch", DirectAction.Load, MethodVisibility.Visible)]
    public JObject nextBatch(string pArrUuid,Request request)
    {
        #region Declare
        CrModel mod = new CrModel();
        BasicModel bmod = new BasicModel();
        List<JObject> jobject = new List<JObject>();
        Hashtable htMsg = new Hashtable();
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

            

            var allUuid = pArrUuid.Split(';');

            /*先檢查資料是否正確*/
            var dataValide = "";
            foreach (var item in allUuid)
            {
                if (item.Trim().Length == 0)
                    continue;
                var drUploadJob = mod.getUploadJob_By_Uuid(item).AllRecord().First();
                var drRawHead = new RawHead_Record();
                drRawHead = mod.getRawHead_By_Uuid(drUploadJob.RAW_HEAD_UUID).AllRecord().First();

                if (drUploadJob.NOW_ATTENDANT_UUID.IndexOf(getUser().UUID) == -1) {
                    dataValide += "時間：" + drUploadJob.TIME_ID + ",資料項目(" + drRawHead.RAW_ID + ")  目前處理人員為 ";

                     
                            foreach (var nowMan in drUploadJob.NOW_ATTENDANT_UUID.Split(':'))
                            {
                                if (nowMan.Trim().Length > 0)
                                {
                                    var drAttendant = bmod.getAttendant_By_Uuid(nowMan).AllRecord().First();
                                    dataValide += drAttendant.C_NAME+",";
                                }
                            }

                            dataValide += "|";


                }

                if (drRawHead.NEED_FILE == "Y")
                {
                    if (drUploadJob.FILES_COUNT > 0)
                    {

                    }
                    else
                    {
                        dataValide += "時間：" +drUploadJob.TIME_ID+ ",資料項目(" + drRawHead.RAW_ID + ")  上傳檔案不可為空"+"|";
                    }
                }

                if (drRawHead.NEED_DESC == "Y")
                {
                    if (drUploadJob.EXPLAIN.Trim().Length > 0)
                    {

                    }
                    else
                    {
                        dataValide += "時間：" + drUploadJob.TIME_ID + ",資料項目(" + drRawHead.RAW_ID + ")說明不可為空" + "|";
                    }
                }

                if (drRawHead.CAN_NULL == "N")
                {
                    if (drUploadJob.VALUE.ToString().Length > 0)
                    {

                    }
                    else
                    {
                        dataValide += "時間：" + drUploadJob.TIME_ID + ",資料項目(" + drRawHead.RAW_ID + ")數值不可以為空" + "|";
                    }
                }
            }

            if (dataValide.Trim().Length > 0)
            {
                htMsg.Add("dataValide", dataValide);
                return ExtDirect.Direct.Helper.Message.Success.OutputJObject(htMsg);
            }

            List<string> planCal = new List<string>();
            foreach (var item in allUuid) {
                if (item.Trim().Length == 0)
                    continue;

                var drUploadJob = mod.getUploadJob_By_Uuid(item).AllRecord().First();
                var drVUploadJob = mod.getVUploadJob_By_Uuid(item).First();

                var drRawHead = new RawHead_Record();
                if (drUploadJob != null)
                {
                    
                    drRawHead = mod.getRawHead_By_Uuid(drUploadJob.RAW_HEAD_UUID).AllRecord().First();
                    if (drUploadJob.STATUS < 5)
                    {
                        var lastStep = 0;
                        if (drUploadJob.DWG5_GID != "")
                        {
                            lastStep = 5;
                        }
                        else if (drUploadJob.DWG4_GID != "")
                        {
                            lastStep = 4;
                        }
                        else if (drUploadJob.DWG3_GID != "")
                        {
                            lastStep = 3;
                        }
                        else if (drUploadJob.DWG2_GID != "")
                        {
                            lastStep = 2;
                        }
                        else if (drUploadJob.DWG1_GID == "")
                        {
                            lastStep = 1;
                        }


                        string nextAttendantUuidString = "";
                        string lastAttendantUuidString = "";
                        if (drUploadJob.STATUS < lastStep && drUploadJob.STATUS < 5)
                        {
                        
                            if (drUploadJob.STATUS == 4)
                            {
                                nextAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG5_GID);
                                lastAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG4_GID);
                            }
                            else if (drUploadJob.STATUS == 3)
                            {
                                nextAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG4_GID);
                                lastAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG3_GID);
                            }
                            else if (drUploadJob.STATUS == 2)
                            {
                                nextAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG3_GID);
                                lastAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG2_GID);
                            }
                            else if (drUploadJob.STATUS == 1)
                            {
                                nextAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG2_GID);
                                lastAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG1_GID);
                            }
                            drUploadJob.STATUS++;
                            drUploadJob.NOW_ATTENDANT_UUID = nextAttendantUuidString;
                            drUploadJob.LAST_ATTENDANT_UUID = lastAttendantUuidString;
                        }
                        else
                        {
                            drUploadJob.FINISH = 1;
                            var _panelKey = drVUploadJob.TIME_ID + "," + drVUploadJob.FULL_FRAME_UUID_LIST.Split(':')[2];
                            if (planCal.Contains(_panelKey) == false) {
                                planCal.Add(_panelKey);
                            }
                        }

                        drUploadJob.gotoTable().Update_Empty2Null(drUploadJob);
                        
                        var msg = getUser().C_NAME + "於" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "將於資料 " + drRawHead.RAW_ID + "送出";
                        if (nextAttendantUuidString.Trim().Length > 0)
                        {
                            msg += ",下一關處理人員資料為：";
                            foreach (var nextMan in nextAttendantUuidString.Split(':'))
                            {
                                if (nextMan.Trim().Length > 0)
                                {
                                    var drAttendant = bmod.getAttendant_By_Uuid(nextMan).AllRecord().First();
                                    msg += drAttendant.C_NAME+",";
                                }
                            }
                            while (msg.EndsWith(":") || msg.EndsWith(","))
                            {
                                msg = msg.Substring(0, msg.Length - 1);
                            }
                        }
                        addLog(drUploadJob.UUID, msg);
                    }
                }
                else
                {
                    throw new Exception("無法取得資料");
                }
            }

            //WS.CalAction.startCal(arrFrameHead, startTimeId, endTimeId, function(obj, jsonObj) {});
            if (planCal.Count > 0) {
                CalAction ca = new CalAction();
                foreach (var item in planCal) {
                    if (item.Trim().Length > 0) {
                        if (item.Split(',').Length == 2) {
                            var arrFramHead = item.Split(',')[1];
                            var startTimeId = item.Split(',')[0];
                            var endTimeId = item.Split(',')[0];
                            ca.startCal(arrFramHead, startTimeId, endTimeId, request);
                        }
                    }
                }
                //ca.startCal()
            }
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();


        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("submitExcel", DirectAction.FormSubmission, MethodVisibility.Visible)]
    public JObject submitExcel(HttpRequest request)
    {
        #region Declare        
        CrModel model = new CrModel();        
        double count;
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
            System.Collections.Hashtable otherParam = new System.Collections.Hashtable();
            #region 附件處理
            if (request.Files.Count > 0)
            {
                if (request.Files[0].FileName != "")
                {
                    HttpServerUtility server = System.Web.HttpContext.Current.Server;
                    var uploadFolder = server.MapPath("~/tmp/");
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(uploadFolder);
                    if (di.Exists == false)
                    {
                        di.Create();
                    }

                    //公司用的目錄
                    uploadFolder = uploadFolder + getUser().COMPANY_ID + "//";

                    di = new System.IO.DirectoryInfo(uploadFolder);
                    if (di.Exists == false)
                    {
                        di.Create();
                    }

                    //頭像的folder
                    uploadFolder = uploadFolder + "UploadJobs//";

                    di = new System.IO.DirectoryInfo(uploadFolder);
                    if (di.Exists == false)
                    {
                        di.Create();
                    }

                    string extName = "";
                    if (request.Files[0].FileName.Split('.').Length > 1)
                    {
                        extName = request.Files[0].FileName.Split('.').Last();
                    }
                    bool isBlack = false;
                    if (extName.ToUpper() == "XLS" || extName.ToUpper() == "XLSX")
                    {
                        isBlack = false;
                    }
                    else
                    {
                        isBlack = true;
                    }

                    if (isBlack)
                    {
                        return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(new Exception("檔案必須是XLS,XLSX格式"));
                    }

                    var fileUuid = IST.Util.UID.Instance.GetUniqueID();
                    string saveFilePath = "";
                    if (extName.Trim().Length > 0)
                    {
                        saveFilePath = uploadFolder + fileUuid + "." + extName;
                    }
                    else
                    {
                        saveFilePath = uploadFolder + fileUuid;
                    }
                    request.Files[0].SaveAs(saveFilePath);
                    var fileName = request.Files[0].FileName;
                    var excelLog = "";
                    var systemUrl = "~/tmp/" + this.getUser().COMPANY_ID + "/UploadJobs/" + fileUuid + "." + extName;

                    try
                    {
                        excelLog = importExcel(saveFilePath);
                    }
                    catch (Exception ex2) {
                        excelLog += ex2.Message;
                    }

                    otherParam.Add("fileName", fileName);
                    otherParam.Add("systemUrl", systemUrl);
                    otherParam.Add("excelLog", excelLog);

                }
            }
            #endregion



            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(otherParam);
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    private enum ExcelType { 
        Month,Year
    }

    private string importExcel(string fileUrl) {
        string excelLog = "";
        CrModel mod = new CrModel();
        System.IO.FileStream fsFile = new FileStream(fileUrl, FileMode.Open, FileAccess.Read);
        try
        {

            var wbxls = new HSSFWorkbook(fsFile);
            var sheetSetting = wbxls.GetSheet("Setting");
            Hashtable htFrame = new Hashtable();
            for (var r = 0; r < 100; r++)
            {
                try
                {
                    var _frameFullName = sheetSetting.GetRow(r).GetCell(0).StringCellValue;
                    var _frameUuid = sheetSetting.GetRow(r).GetCell(1).StringCellValue;
                    if (htFrame.ContainsKey(_frameFullName) == false)
                    {
                        htFrame.Add(_frameFullName, _frameUuid);
                    }
                }
                catch (Exception e)
                {

                }
            }

            foreach (DictionaryEntry hti in htFrame)
            {
                var sheetName = hti.Key.ToString().Split(':')[hti.Key.ToString().Split(':').Length - 2];
                var frameHeadUuid = hti.Value.ToString();

                var curSheet = wbxls.GetSheet(sheetName);

                var _timeId = curSheet.GetRow(0).GetCell(3).StringCellValue;

                ExcelType excelType = ExcelType.Month;
                if (_timeId.Trim().Length == 4)
                {
                    excelType = ExcelType.Year;
                }

                //curSheet.LastRowNum

                int timeColumnCount = 1;

                for (var i = 3; i < 100; i++)
                {
                    try
                    {
                        var test = curSheet.GetRow(0).GetCell(i).StringCellValue;
                        if (test.Trim().Length > 0)
                        {
                            timeColumnCount = i;
                        }
                    }
                    catch (Exception e) { 
                    
                    }
                }

                for (var r = 1; r <= curSheet.LastRowNum; r++)
                {

                    var rawHeadId = curSheet.GetRow(r).GetCell(0).StringCellValue;
                    var drRawHead = mod.getRawHead_By_RawId(rawHeadId, getUser().COMPANY_UUID);
                    var rawHeadUuid = "";
                    if (drRawHead != null)
                    {
                        rawHeadUuid = drRawHead.UUID;
                    }
                    else
                    {
                        excelLog += "Sheet:" + sheetName + ",上傳資料id為" + rawHeadId + "是無效的。" + "|";
                        continue;
                    }
                    for (var c = 3; c <= timeColumnCount; c++)
                    {
                        var timeId = curSheet.GetRow(0).GetCell(c).StringCellValue;
                        var _cellValue = "";
                        try
                        {
                            _cellValue = curSheet.GetRow(r).GetCell(c).StringCellValue;
                        }
                        catch (Exception e) {
                            try
                            {
                                _cellValue = curSheet.GetRow(r).GetCell(c).NumericCellValue.ToString();
                            }
                            catch (Exception e2) {
                                continue;
                            }
                        }
                        
                        decimal? cellValue = null;
                        decimal tmpvalue = 0;
                        bool valueIsNull = false;
                        try
                        {
                            if (_cellValue.ToUpper() == "X")
                            {
                                continue;
                            }
                            else if (_cellValue.Trim().Length == 0)
                            {
                                valueIsNull = true;
                            }
                            else
                            {

                                if (decimal.TryParse((string)_cellValue, out tmpvalue))
                                {
                                    cellValue = tmpvalue;
                                }
                                else
                                {
                                    excelLog += "Sheet:" + sheetName + ",第" + r + "行 " + "第" + c + "欄(" + rawHeadId + ")的資料無法轉入" + "|";
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            excelLog += e.Message + "|";
                        }



                        var drsUploadJob = mod.getUploadJob_By_FrameHeadUuid_RawHeadUuid_TimeId(frameHeadUuid, rawHeadUuid, timeId);
                        if (drsUploadJob.Count == 0)
                        {
                            excelLog += "Sheet:" + sheetName + ",第" + r + "行 " + "第" + c + "欄(" + rawHeadId + ")的資料不存在於你的上傳工作中" + "|";
                        }
                        else if (drsUploadJob.Count == 1)
                        {
                            var drUploadJob = drsUploadJob.First();
                            if (drUploadJob.FINISH == 1)
                            {
                                excelLog += "Sheet:" + sheetName + ",第" + r + "行 " + "第" + c + "欄(" + rawHeadId + ")的資料已完成簽核，無法再次修正" + "|";
                            }
                            else
                            {
                                if (drUploadJob.NOW_ATTENDANT_UUID.IndexOf(getUser().UUID) >= 0)
                                {
                                    if (valueIsNull == true)
                                    {
                                        drUploadJob.VALUE = null;
                                    }
                                    else
                                    {
                                        drUploadJob.VALUE = cellValue;
                                    }
                                    drUploadJob.gotoTable().Update_Empty2Null(drUploadJob);
                                    excelLog += "【成功】Sheet:" + sheetName + ",第" + r + "行 " + "第" + c + "欄(" + rawHeadId + ") |";
                                }
                                else
                                {
                                    excelLog += "Sheet:" + sheetName + ",第" + r + "行 " + "第" + c + "欄(" + rawHeadId + ")的資料目前的處理人員已經不是你" + "|";
                                }
                            }
                        }
                        else
                        {
                            excelLog += "Sheet:" + sheetName + ",第" + r + "行 " + "第" + c + "欄(" + rawHeadId + ")的資料異常錯誤" + "|";
                        }


                    }
                }




            }

            return excelLog;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally {
            fsFile.Close();
            fsFile.Dispose();
        }
    }
    private string getDwgAttendantUuidStr(string pDwgId){
        string ret="";
        try{
            CrModel mod = new CrModel();
            var drsDwg = mod.getDwg_By_DwgGid(pDwgId);
       
        foreach (var member in drsDwg)
                        {
                            if (member.ATTENDANT_UUID != "")
                            {

                                ret += member.ATTENDANT_UUID + ":";
                            }
                        }
        return ret;
        }
        catch(Exception ex){
            throw ex;
        }
    }
    [DirectMethod("previous", DirectAction.Load, MethodVisibility.Visible)]
    public JObject previous(string pUuid,string msg, Request request)
    {
        #region Declare
        CrModel mod = new CrModel();
        List<JObject> jobject = new List<JObject>();
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

            var drUploadJob = mod.getUploadJob_By_Uuid(pUuid).AllRecord().First();
            if (drUploadJob != null)
            {
                if (drUploadJob.STATUS < 5 && drUploadJob.STATUS >= 1)
                {
                    var lastStep = 0;
                    if (drUploadJob.DWG5_GID != "")
                    {
                        lastStep = 5;
                    }
                    else if (drUploadJob.DWG4_GID != "")
                    {
                        lastStep = 4;
                    }
                    else if (drUploadJob.DWG3_GID != "")
                    {
                        lastStep = 3;
                    }
                    else if (drUploadJob.DWG2_GID != "")
                    {
                        lastStep = 2;
                    }
                    else if (drUploadJob.DWG1_GID == "")
                    {
                        lastStep = 1;
                    }

                    if (drUploadJob.STATUS == 1) { 

                    }
                    else if (drUploadJob.STATUS <= lastStep && drUploadJob.STATUS >1)
                    {
                        string nextAttendantUuidString = "";
                        string lastAttendantUuidString = "";
                        if (drUploadJob.STATUS == 5)
                        {
                            nextAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG4_GID);
                            lastAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG3_GID);
                        }
                        else if (drUploadJob.STATUS == 4)
                        {
                            nextAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG3_GID);
                            lastAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG2_GID);
                        }
                        else if (drUploadJob.STATUS == 3)
                        {
                            nextAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG2_GID);
                            lastAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG1_GID);
                        }
                        else if (drUploadJob.STATUS == 2)
                        {
                            nextAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG1_GID);
                            lastAttendantUuidString = "";
                        }
                        
                        drUploadJob.NOW_ATTENDANT_UUID = nextAttendantUuidString;
                        drUploadJob.LAST_ATTENDANT_UUID = lastAttendantUuidString;


                        drUploadJob.STATUS--;
                        
                    }
                    drUploadJob.FINISH = 0;
                    msg = "管理者" + getUser().C_NAME + "執行無條件退關行為";
                    drUploadJob.gotoTable().Update_Empty2Null(drUploadJob);
                    addLog(drUploadJob.UUID, msg);
                }
            }
            else
            {
                throw new Exception("無法取得資料");
            }

            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();


        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("first", DirectAction.Load, MethodVisibility.Visible)]
    public JObject first(string pUuid,string msg, Request request)
    {
        #region Declare
        CrModel mod = new CrModel();
        List<JObject> jobject = new List<JObject>();
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

            var drUploadJob = mod.getUploadJob_By_Uuid(pUuid).AllRecord().First();
            if (drUploadJob != null)
            {
                if (drUploadJob.STATUS < 5)
                {
                    string nextAttendantUuidString = "";
                    
                    
                    nextAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG1_GID);
                    
                  
                    drUploadJob.NOW_ATTENDANT_UUID = nextAttendantUuidString;
                    drUploadJob.LAST_ATTENDANT_UUID = "";

                    drUploadJob.STATUS = 1;
                    drUploadJob.FINISH = 0;
                    drUploadJob.gotoTable().Update_Empty2Null(drUploadJob);
                    msg = "管理者" + getUser().C_NAME + "執行無條件回到第一關行為";
                    addLog(drUploadJob.UUID, msg);
                }
            }
            else
            {
                throw new Exception("無法取得資料");
            }

            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();


        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("last", DirectAction.Load, MethodVisibility.Visible)]
    public JObject last(string pUuid,string msg, Request request)
    {
        #region Declare
        CrModel mod = new CrModel();
        List<JObject> jobject = new List<JObject>();
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

            var drUploadJob = mod.getUploadJob_By_Uuid(pUuid).AllRecord().First();
            if (drUploadJob != null)
            {

                var lastStep = 0;
                if (drUploadJob.DWG5_GID != "")
                {
                    lastStep = 5;
                }
                else if (drUploadJob.DWG4_GID != "")
                {
                    lastStep = 4;
                }
                else if (drUploadJob.DWG3_GID != "")
                {
                    lastStep = 3;
                }
                else if (drUploadJob.DWG2_GID != "")
                {
                    lastStep = 2;
                }
                else if (drUploadJob.DWG1_GID == "")
                {
                    lastStep = 1;
                }

                string nextAttendantUuidString = "";
                string lastAttendantUuidString = "";
                if (lastStep == 5)
                {
                    nextAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG5_GID);
                    lastAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG4_GID);
                }
                else if (lastStep == 4)
                {
                    nextAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG4_GID);
                    lastAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG3_GID);
                }
                else if (lastStep == 3)
                {
                    nextAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG3_GID);
                    lastAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG2_GID);
                }
                else if (lastStep ==2)
                {
                    nextAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG2_GID);
                    lastAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG1_GID);
                }
                else if (lastStep == 1)
                {
                    nextAttendantUuidString = getDwgAttendantUuidStr(drUploadJob.DWG1_GID);
                    lastAttendantUuidString = "";
                }
                
                drUploadJob.NOW_ATTENDANT_UUID = nextAttendantUuidString;
                drUploadJob.LAST_ATTENDANT_UUID = lastAttendantUuidString;
                drUploadJob.STATUS = lastStep;
                drUploadJob.FINISH = 1;
                drUploadJob.gotoTable().Update_Empty2Null(drUploadJob);
                msg = "管理者" + getUser().C_NAME + "執行無條件結束關卡行為";
                addLog(drUploadJob.UUID, msg);
                
            }
            else
            {
                throw new Exception("無法取得資料");
            }

            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();


        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("setUdJobValue", DirectAction.Load, MethodVisibility.Visible)]
    public JObject setUploadJobValue(string pUuid, string pValue, string pExplain, Request request)
    {
        CrModel mod = new CrModel();
        try
        {
            var drsUpload = mod.getUploadJob_By_Uuid(pUuid);
            if (drsUpload.AllRecord().Count > 0)
            {
                var drUpload = drsUpload.AllRecord().First();
                if (pValue.Trim().Length > 0)
                {
                    try
                    {
                        drUpload.VALUE = Convert.ToDecimal(pValue);
                    }
                    catch
                    {
                        drUpload.VALUE = null;
                    }
                }
                else {
                    drUpload.VALUE = null;
                }
                
                drUpload.EXPLAIN = pExplain;
                drUpload.gotoTable().Update_Empty2Null(drUpload);
            }
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();

        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("setUploadJobValueOnly", DirectAction.Load, MethodVisibility.Visible)]
    public JObject setUploadJobValueOnly(string pUuid, string pValue, Request request)
    {
        CrModel mod = new CrModel();
        try
        {
            var drsUpload = mod.getUploadJob_By_Uuid(pUuid);
            if (drsUpload.AllRecord().Count > 0)
            {
                var drUpload = drsUpload.AllRecord().First();
                if (pValue.Trim().Length > 0)
                {
                    try
                    {
                        drUpload.VALUE = Convert.ToDecimal(pValue);
                    }
                    catch
                    {
                        drUpload.VALUE = null;
                    }
                }
                else
                {
                    drUpload.VALUE = null;
                }

                
                drUpload.gotoTable().Update_Empty2Null(drUpload);
            }
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();

        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("setUploadJobExplainOnly", DirectAction.Load, MethodVisibility.Visible)]
    public JObject setUploadJobExplainOnly(string pUuid, string pExplain, Request request)
    {
        CrModel mod = new CrModel();
        try
        {
            var drsUpload = mod.getUploadJob_By_Uuid(pUuid);
            if (drsUpload.AllRecord().Count > 0)
            {
                var drUpload = drsUpload.AllRecord().First();
                drUpload.EXPLAIN = pExplain;


                drUpload.gotoTable().Update_Empty2Null(drUpload);
            }
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();

        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("loadUploadJobLog", DirectAction.Load, MethodVisibility.Visible)]
    public JObject loadUploadJobLog(string pUploadJobUuid, string pageNo, string limitNo, string sort, string dir, Request request)
    {
        #region Declare
        CrModel mod = new CrModel();
        List<JObject> jobject = new List<JObject>();
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

            var orderLimit = ExtDirect.Direct.Helper.Order.getOrderLimit(pageNo, limitNo, sort, dir);
            var totalCount = mod.getUploadJobLog_By_UploadJobUuid_Count(pUploadJobUuid);
            var data = mod.getUploadJobLog_By_UploadJobUuid(pUploadJobUuid,orderLimit);
            

            if (totalCount > 0)
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
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

}

