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
using System.IO;
#endregion
[DirectService("CalAction")]
public class CalAction : BaseAction
{
    [DirectMethod("startCal", DirectAction.TreeStore, MethodVisibility.Visible)]
    public JObject startCal(string pArrFrameHeadUuid,string startTimeId,string endTimeId, Request request)
    {
        
        List<JObject> jobject = new List<JObject>();
        
        string pTimeId = "";

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
            if (startTimeId.Trim().Length < 4 && endTimeId.Trim().Length < 4)
            {
                throw new Exception("時間屬性未設定");
            }
            System.IO.StreamWriter sw = new System.IO.StreamWriter(CISR.Parameter.Config.ParemterConfigs.GetConfig().TriggerFile, true);
            sw.WriteLine("expCal!" + pArrFrameHeadUuid + "!" + startTimeId + "!" + endTimeId);
            sw.Close();            
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            /*將Exception轉成EXT Exception JSON格式*/
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    private int? setOrd(ref IList<Cal_Record> cal) {
        int? retValue = null;
        try
        {
            var drsCal = cal.Where(c => c.ORD.ToString().Equals("")).ToList();
            foreach (var dr in drsCal)
            {
                
                var arrTmp  = dr.FORMULA.Split(new char[] { '(',')','+','-','*','/','\\' });
                int? max = 0;
                foreach (var tmp in arrTmp)
                {                    
                    if (tmp.IndexOf("K!") != -1)
                    {
                        string kpiUuid = tmp.Split('!')[1];
                        var _drCal = cal.Where(c => c.KPI_HEAD_UUID.Equals(kpiUuid)).First();
                        if (_drCal.ORD.ToString() != "")
                        {
                            /*有ord的值*/
                            if (Convert.ToInt16(_drCal.ORD) > max) {
                                max = Convert.ToInt16(_drCal.ORD);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }                   
                }
                if (max != null)
                {
                    dr.ORD = max + 1;
                    return max + 1;
                }
            }
            return retValue;
        }
        catch (Exception ex) {
            throw ex;
        }
    }

    [DirectMethod("loadVCal", DirectAction.Load, MethodVisibility.Visible)]
    public JObject loadVCal(string pTimeId,string pTimeId2, string pKeyword, string pFullFrameHeadUuid,string pStatus,string pKpiType, string pageNo, string limitNo, string sort, string dir, Request request)
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
            //mod.getVCal_By_TimeId_Keyword_FrameHeadUuid

            var data = mod.getVCal_By_TimeId_Keyword_FrameHeadUuid(pTimeId,pTimeId2, pKeyword, pFullFrameHeadUuid,pStatus,pKpiType, orderLimit);
            var totalCount = mod.getVCal_By_TimeId_Keyword_FrameHeadUuid_Count(pTimeId,pTimeId2, pKeyword, pFullFrameHeadUuid, pStatus, pKpiType);

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

