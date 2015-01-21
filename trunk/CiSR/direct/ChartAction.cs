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
using CISR.Model.Cr.Table;
using CISR.Model.Cr.Table.Record;
using CISR.Model.Cr;
using System.Data;
#endregion
[DirectService("ChartAction")]
public class ChartAction : BaseAction
{

    [DirectMethod("loadPieChartA", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadPieChartA(string display ,string arrX, string arrY,string pTimeId, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        CrModel mod = new CrModel();
        OrderLimit orderLimit = null;
        Appmenu tblAppmenu = new Appmenu();
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
            DataTable dt = new DataTable();
            dt.Columns.Add("ItemCategory");
            dt.Columns.Add("ItemValue");
            dt.Columns.Add("ChartGroup");
            dt.AcceptChanges();
            List<string> x = new List<string>();
            List<string> y = new List<string>();
            List<string> t = new List<string>();

            if (pTimeId.IndexOf(";") == -1 && pTimeId.Trim().Length>0) { 
                /*時間只有一個*/
            }
            else
            {
                throw new Exception("時間只可以有一個");
            }

            var cX = arrX.Split(';').Count(c => c.Length > 0);
            var cY = arrY.Split(';').Count(c => c.Length > 0);
            if (cX > 1 && cY > 1)
            {
                throw new Exception("只支援單軸圖表");
            }
            var hasChangeXy = false;
            if (cY > cX)
            {
                /*表示x,y軸交換*/
                x = arrY.Split(';').ToList();
                y = arrX.Split(';').ToList();
                hasChangeXy = true;
            }
            else {
                x = arrX.Split(';').ToList();
                y = arrY.Split(';').ToList();
            }

            if (hasChangeXy == false)
            {
                /*x 是多個指標,y是組織*/
               

                List<object> arrKpi = new List<object>();
                foreach (var tmp in x)
                {
                    if (tmp.Length > 0)
                    {
                        arrKpi.Add(tmp);
                    }
                }
                var drsVcal = mod.getVCal_By_FrameHeadUuid_TimeId_KpiHeadUuid(y.First(), pTimeId, arrKpi);
                foreach (var item in drsVcal)
                {
                    var newRow = dt.NewRow();
                    if (display == "CODE")
                    {
                        newRow["ItemCategory"] = item.KPI_ID;
                    }
                    else
                    {
                        var drKpiHead = mod.getKpiHead_By_Uuid(item.KPI_HEAD_UUID).AllRecord().First();
                        newRow["ItemCategory"] = drKpiHead.C_DESC;
                    }
                    
                    newRow["ItemValue"] = item.VALUE;
                    
                    dt.Rows.Add(newRow);
                }
            }
            else {
                /*x 是多個組織,y是指標*/
                List<object> arrFrame = new List<object>();
                foreach (var tmp in x)
                {
                    if (tmp.Length > 0)
                    {
                        arrFrame.Add(tmp);
                    }
                }
                var drsVcal = mod.getVCal_By_FrameHeadUuid_TimeId_KpiHeadUuid(arrFrame, pTimeId, y.First());
                foreach (var item in drsVcal)
                {
                    var newRow = dt.NewRow();                    
                    newRow["ItemCategory"] = item.C_NAME;
                    newRow["ItemValue"] = item.VALUE;
                    dt.Rows.Add(newRow);
                }
            }

            
            //var data =
            
                /*將List<RecordBase>變成JSON字符串*/
            //    jobject = JsonHelper.RecordBaseListJObject(data);

            //JsonHelper.DataTable2JObject(dt, 0, dt.Rows.Count);
            
            
            //JsonHelper.DataTable2JObject(dt,0,dt.Rows.Count)

            /*使用Store Std out 『Sotre物件標準輸出格式』*/
            return ExtDirect.Direct.Helper.Store.OutputJObject(dt, 0, dt.Rows.Count);
            //return ExtDirect.Direct.Helper.Store.OutputJObject(jobject, dt.Rows.Count);
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            /*將Exception轉成EXT Exception JSON格式*/
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }
    [DirectMethod("loadColumnClusterCharts", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadColumnClusterCharts(string arrX, string arrY, string pArrTimeId, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        CrModel mod = new CrModel();
        OrderLimit orderLimit = null;
        Appmenu tblAppmenu = new Appmenu();
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
            DataTable dt = new DataTable();
            dt.Columns.Add("ItemCategory");
            foreach (var item in pArrTimeId.Split(';'))
            {
                if(item.Trim().Length>0)
                    dt.Columns.Add(item);
            }
            //dt.Columns.Add("ItemValue");
            dt.AcceptChanges();
            List<string> x = new List<string>();
            List<string> y = new List<string>();
            List<string> t = new List<string>();

           

            var cX = arrX.Split(';').Count(c => c.Length > 0);
            var cY = arrY.Split(';').Count(c => c.Length > 0);
            if (cX > 1 && cY > 1)
            {
                throw new Exception("只支援單軸圖表");
            }
            var hasChangeXy = false;
            if (cY > cX)
            {
                /*表示x,y軸交換*/
                x = arrY.Split(';').ToList();
                y = arrX.Split(';').ToList();
                hasChangeXy = true;
            }
            else
            {
                x = arrX.Split(';').ToList();
                y = arrY.Split(';').ToList();
            }

            if (hasChangeXy == false)
            {
                /*x 是多個指標,y是組織*/


                List<string> arrKpi = new List<string>();
                foreach (var tmp in x)
                {
                    if (tmp.Length > 0)
                    {
                        arrKpi.Add(tmp);
                    }
                }

                foreach (var kpiHeadUuid in arrKpi) {
                    var newRow = dt.NewRow();
                    var drKpiHead = mod.getKpiHead_By_Uuid(kpiHeadUuid).AllRecord().First();
                    newRow["ItemCategory"] = drKpiHead.C_DESC;
                    foreach (var timeId in pArrTimeId.Split(';')) {
                        if (timeId.Trim().Length > 0)
                        {
                            if (mod.getVCal_By_FrameHeadUuid_TimeId_KpiHeadUuid(kpiHeadUuid, y.First(), timeId).Value != null)
                            {
                                newRow[timeId] = mod.getVCal_By_FrameHeadUuid_TimeId_KpiHeadUuid(kpiHeadUuid, y.First(), timeId).Value;
                            }
                            else {
                                newRow[timeId] = "";
                            }
                        }
                    }
                    dt.Rows.Add(newRow);
                }               
            }
            else
            {
                /*x 是多個組織,y是指標*/
                dt = new DataTable();
                dt.Columns.Add("ItemCategory");
               

                List<string> arrFrame = new List<string>();
                var col = "1";
                foreach (var tmp in x)
                {
                    if (tmp.Length > 0)
                    {
                        arrFrame.Add(tmp);

                        var drFrameHead = mod.getFrameHead_By_Uuid(tmp).AllRecord().First();
                        dt.Columns.Add("D" + col, typeof(decimal));

                        col = (Convert.ToInt16(col) + 1).ToString();
                        

                    }
                }

               
                foreach (var timeId in pArrTimeId.Split(';'))
                {
                    var newRow = dt.NewRow();
                    if (timeId.Trim().Length > 0)
                    {
                        col = "1";
                        
                            
                            foreach (var cf in arrFrame) {
                                try
                                {
                                    if (mod.getVCal_By_FrameHeadUuid_TimeId_KpiHeadUuid(y.First(), cf, timeId).Value != null)
                                    {
                                        newRow["D" + col] = mod.getVCal_By_FrameHeadUuid_TimeId_KpiHeadUuid(y.First(), cf, timeId).Value;
                                    }
                                    else
                                    {
                                        newRow["D" + col] = "0";
                                    }
                                    col = (Convert.ToInt16(col) + 1).ToString();
                                }
                                catch (Exception ex2)
                                {
                                    newRow["D" + col] = "0";
                                    col = (Convert.ToInt16(col) + 1).ToString();
                                }
                            }


                            newRow["ItemCategory"] = timeId;
                            dt.Rows.Add(newRow);
                    }
                    
                }
                
                                   
            }

            return ExtDirect.Direct.Helper.Store.OutputJObject(dt, 0, dt.Rows.Count);
            //return ExtDirect.Direct.Helper.Store.OutputJObject(jobject, dt.Rows.Count);
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            /*將Exception轉成EXT Exception JSON格式*/
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }
        
    [DirectMethod("saveChartList", DirectAction.Store, MethodVisibility.Visible)]
    public JObject saveChartList(string uuid, string chart_name,string pChartGroup, string chart_desc, string chart_title, string chart_type, string chart_x, string chart_y, string chart_time, string display, string jobject, Request request)
    {
        #region Declare
        var action = SubmitAction.None;
        CrModel mod = new CrModel();
        ChartList_Record drChartList = new ChartList_Record();
        
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
            if (uuid.Trim().Length > 0)
            {

                drChartList = mod.getChartList_By_Uuid(uuid).AllRecord().First();
                action = SubmitAction.Edit;
            }
            else
            {
                action = SubmitAction.Create;
                drChartList.UUID = IST.Util.UID.Instance.GetUniqueID();
            }
            /*固定要更新的欄位*/
            drChartList.CHART_DESC = chart_desc;
            drChartList.ATTENDANT_UUID =getUser().UUID;
            drChartList.COMPANY_UUID = getUser().COMPANY_UUID;
            drChartList.CHART_NAME = chart_name;
            drChartList.CHART_TIME = chart_time;
            drChartList.CHART_TITLE = chart_title;
            drChartList.CHART_TYPE = chart_type;
            drChartList.CHART_X = chart_x;
            drChartList.CHART_Y = chart_y;
            drChartList.DISPLAY = display;
            drChartList.JOBJECT = jobject;
            drChartList.CHART_GROUP = pChartGroup;
            


            if (action == SubmitAction.Edit)
            {
                drChartList.gotoTable().Update_Empty2Null(drChartList);
            }
            else if (action == SubmitAction.Create)
            {
                drChartList.gotoTable().Insert_Empty2Null(drChartList);
            }

            System.Collections.Hashtable ht = new System.Collections.Hashtable();

            ht.Add("uuid", drChartList.UUID);

            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(ht);

        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("loadMyChart", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadMyChart(string pageNo, string limitNo, string sort, string dir, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        CrModel mod = new CrModel();
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
            //var totalCount = modBasic.getFrameHead_By_CompanyUuid_Count(pCompanyUuid);
            /*取得資料*/
            var data = mod.getChartList_By_Attendant(getUser().UUID,orderLimit);
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

    [DirectMethod("removeMyChart", DirectAction.Load, MethodVisibility.Visible)]
    public JObject removeMyChart(string pChartListUuid, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
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
            /*是Store操作一下就可能含有分頁資訊。*/            
            /*取得總資料數*/            
            /*取得資料*/
            var drsChartList = mod.getChartList_By_Uuid(pChartListUuid);
            if (drsChartList.AllRecord().Count > 0)
            {
                if (drsChartList.AllRecord().First().ATTENDANT_UUID == getUser().UUID) {
                    var delChartList = drsChartList.AllRecord().First();
                    delChartList.gotoTable().Delete(delChartList);
                }
            }
            
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            /*將Exception轉成EXT Exception JSON格式*/
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

}

