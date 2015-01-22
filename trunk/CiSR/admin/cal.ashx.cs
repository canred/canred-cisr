using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Collections;
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
using NCalc;
namespace CISR.admin
{
    /// <summary>
    /// Summary description for cal
    /// </summary>
    public class cal : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                var action = context.Request["action"];
                var arrFrame = context.Request["arrFrame"];
                var arrTimeId = context.Request["arrTimeId"];
                var kpiId = context.Request["kpiId"];
                action = "CAL";
                CrModel mod = new CrModel();
                var allTime = mod.getVCal_Distinct_TimeId_By_Wait();

                //List<string> pTime = new List<string>();
                //foreach(var tmp in arrTimeId.Split(';')){
                //    if (pTime.Contains(tmp) == false)
                //    {
                //        pTime.Add(tmp);
                //    }                    
                //}

                if (action == "CAL")
                {
                    foreach (var tmp in allTime)
                    {
                        var p = new List<string>();
                        p.Add(tmp.TIME_ID.ToString());
                        callMaster(null, p, null);
                    }
                    
                }
                context.Response.Write("OK");
            }
            catch (Exception ex) {
                context.Response.Write(ex.StackTrace);
            }
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
        }

        public void callMaster(List<string> frame,List<string> timeId,String KpiId) {
            CrModel mod = new CrModel();
            string calLog = "";
            try
            {
                /*所有要計算的計劃*/
                var drsCal = mod.getVCal_By_Wait();
                List<UploadJob_Record> calData = new List<UploadJob_Record>();
                System.Collections.Hashtable htTimeId = new System.Collections.Hashtable();
                foreach (var _cal in drsCal) {
                    calLog = "";
                    bool jump = false;
                    /*查一下預計算的時間點資料是否已經處理了*/
                    if (htTimeId.ContainsKey(_cal.TIME_ID) == false)
                    {
                        /*未處理*/
                        var _drs = mod.getUploadJob_By_TimeId_Finish(_cal.TIME_ID, 1);
                        foreach (var i in _drs)
                        {
                            calData.Add(i.Clone());
                        }
                    }

                 
                    /*按自已的組織資料開始往下抓所有的upload_job*/
                    /*將公式欄位解開，分成 上傳資料、kpi、系數等三個*/
                    List<string> needRawUuid = new List<string>();
                    List<string> needKpiUuid = new List<string>();
                    List<string> needParameterUuid = new List<string>();
                    
                    /*由Upload_Record中找出上傳元素*/
                    /*由cal_Record中找出KPI元素*/
                    /*有條件式的找出Parameter元素*/
                    var allElment = _cal.FORMULA.Split(new char[]{'!','(',')','{','}','+','-','*','/'});
                    for (var i = 0; i < allElment.Length; i++)
                    {
                        if (allElment[i] == "R")
                        {
                            if (needRawUuid.Contains(allElment[i + 1]) == false)
                            {
                                needRawUuid.Add(allElment[i + 1]);
                            }
                                i++;
                        }
                        else if (allElment[i] == "K")
                        {
                            if (needKpiUuid.Contains(allElment[i + 1]) == false)
                            {
                                needKpiUuid.Add(allElment[i + 1]);
                            }
                            i++;
                        }
                        else if (allElment[i] == "P")
                        {
                            if (needParameterUuid.Contains(allElment[i + 1]) == false)
                            {
                                needParameterUuid.Add(allElment[i + 1]);
                            }
                            i++;
                        }
                    }

                    if (_cal.HASCHILD == "N")
                    {
                        /*不需要重新整理公式*/
                        /*注意事項
                         *在該層只有資料完全準備好才計算
                         */
                        string formula = _cal.FORMULA;
                        if (formula.Trim() == "") {
                            var dr = _cal.Link_Cal_By_Uuid().First();
                            calLog = "發現此指標沒有設定公式";
                            dr.ERROR_MSG = calLog;
                            dr.CAL_LOG = "";
                            dr.STATUS = "E";                            
                            dr.gotoTable().Update_Empty2Null(dr);
                            dr.ERROR_MSG = calLog;
                            dr.STATUS = "E";                            
                            continue;
                        }
                        
                        Expression e = new Expression(formula);                        
                        jump = false;
                        System.Collections.Hashtable htRaw = new System.Collections.Hashtable();
                        System.Collections.Hashtable htPar = new Hashtable();
                        Hashtable htPi = new Hashtable();
                        foreach (var r in needRawUuid)
                        {
                            formula = formula.Replace("R!" + r, "[R" + r + "]");
                            //if (_cal.FRAME_HEAD_UUID == "14100622484301136" && r == "1007") {
                            //    string debug = "aaa";
                            //}
                            decimal? value = getUploadJobValue(_cal.FRAME_HEAD_UUID, r, _cal.TIME_ID);
                            if (value == null)
                            {
                                var drRawHead = mod.getRawHead_By_Uuid(r).AllRecord().First();
                                var dr = _cal.Link_Cal_By_Uuid().First();
                                calLog += System.Environment.NewLine + System.Environment.NewLine + "【計算元素不齊全】" + System.Environment.NewLine;
                                calLog += "組織:"+_cal.FULL_FRAME_NAME_LIST+System.Environment.NewLine;
                                calLog += "需要資料:(" + drRawHead.RAW_ID+")"+ drRawHead.C_DESC + System.Environment.NewLine;

                                dr.CAL_LOG = "";
                                dr.STATUS = "D";
                                dr.ERROR_MSG = calLog;
                                dr.gotoTable().Update_Empty2Null(dr);

                                dr.CAL_LOG = dr.CAL_LOG;
                                dr.STATUS = "D";

                                jump = true;
                            }
                            else
                            {
                                htRaw.Add("R" + r + "", value.Value);
                            }
                        }

                        if (jump == true)
                            continue;


                        foreach (var k in needKpiUuid)
                        {
                            formula = formula.Replace("K!" + k, "[K" + k + "]");
                            var _drFrame = mod.getFrameHead_By_Uuid(_cal.FRAME_HEAD_UUID).AllRecord().First();                            
                            var pValue = mod.getVCal_By_FrameHeadUuid_TimeId_KpiHeadUuid(k, _drFrame.UUID, _cal.TIME_ID);                            
                            htPi.Add("K" + k, pValue); 
                        }
                        foreach (var p in needParameterUuid)
                        {
                            formula = formula.Replace("P!" + p, "[P" + p + "]");                            
                            var _drFrame = mod.getFrameHead_By_Uuid(_cal.FRAME_HEAD_UUID).AllRecord().First();                            
                            var pValue = mod.getVParameterQuery_Region_TimeId(p, _drFrame.REGION_UUID, _cal.TIME_ID);
                            htPar.Add("P" + p, pValue);                            
                        }
                        e = new Expression(formula);
                        calLog += "【計算】組織:"+_cal.FULL_FRAME_NAME_LIST+System.Environment.NewLine;
                        calLog += " KPI ID:" + _cal.KPI_ID + System.Environment.NewLine;
                        calLog += " KPI 說明:" +  _cal.C_DESC +  System.Environment.NewLine;
                        calLog += "【公式】" + getFormula(_cal.FORMULA) + System.Environment.NewLine;
                        calLog += "【公式 for 程式】" + _cal.FORMULA +System.Environment.NewLine;
                        calLog += "【計算元素】" + System.Environment.NewLine;
                        foreach (DictionaryEntry entry in htRaw)
                        {
                            var drRawHead = mod.getRawHead_By_Uuid(entry.Key.ToString().Substring(1)).AllRecord().First();
                            e.Parameters[entry.Key.ToString()] = Convert.ToDouble(entry.Value);
                            calLog += "【"+drRawHead.UUID+"】"+drRawHead.RAW_ID + "(" + drRawHead.C_DESC + "):" + entry.Value.ToString()+System.Environment.NewLine; 
                        }

                        if (htPar.Count > 0)
                        {
                            calLog += System.Environment.NewLine+ "【系數資訊】" + System.Environment.NewLine;
                            foreach (DictionaryEntry entry in htPar)
                            {
                                var _drP = mod.getParameterHead_By_Uuid(entry.Key.ToString().Substring(1)).AllRecord().First();
                                e.Parameters[entry.Key.ToString()] = Convert.ToDouble(entry.Value);
                                calLog += "【" + _drP.UUID + "】" + _drP.NAME + ":" + entry.Value.ToString() + System.Environment.NewLine;
                            }
                        }

                        if (htPi.Count > 0)
                        {
                            calLog += "【指標資訊】" + System.Environment.NewLine;
                            var needJump = false;
                            foreach (DictionaryEntry entry in htPi)
                            {
                                var _drP = mod.getKpiHead_By_Uuid(entry.Key.ToString().Substring(1)).AllRecord().First();
                                e.Parameters[entry.Key.ToString()] = Convert.ToDouble(entry.Value);
                                if (entry.Value == null)
                                {
                                    calLog += "【缺少指標:" + _drP.UUID + "】" + _drP.C_DESC + System.Environment.NewLine;
                                    needJump = true;
                                }
                                else
                                {
                                    calLog += "【" + _drP.UUID + "】" + _drP.C_DESC + ":" + entry.Value.ToString() + System.Environment.NewLine;
                                }
                            }

                            if (needJump) {
                                calLog += "【計算結果】無法計算"+System.Environment.NewLine+System.Environment.NewLine;
                                var dr3 = _cal.Link_Cal_By_Uuid().First();
                                _cal.VALUE = null;
                                _cal.CAL_LOG = calLog;
                                _cal.STATUS = "D";

                                dr3.VALUE = _cal.VALUE;
                                dr3.STATUS = "D";
                                dr3.CAL_LOG = calLog;
                                dr3.gotoTable().Update_Empty2Null(dr3);
                                continue;
                            }
                                

                        }


                        var result = Convert.ToDecimal(e.Evaluate());
                        calLog += "【計算結果】" + result.ToString();
                        var dr2 = _cal.Link_Cal_By_Uuid().First();
                        _cal.VALUE = result;
                        _cal.CAL_LOG = calLog;
                        _cal.STATUS = "Y";

                        dr2.VALUE = _cal.VALUE;
                        dr2.STATUS = "Y";
                        dr2.CAL_LOG = calLog;
                        dr2.gotoTable().Update_Empty2Null(dr2);

                    }
                    else {



                        //continue;
                        /*需要重新整理公式*/
                        jump = false;
                        /*無設定公式時要跳出*/
                        string formula = _cal.FORMULA;
                        if (formula.Trim() == "")
                        {
                            var dr = _cal.Link_Cal_By_Uuid().First();
                            calLog = "發現此指標沒有設定公式";
                            dr.ERROR_MSG = calLog;
                            dr.CAL_LOG = "";
                            dr.STATUS = "E";
                            dr.gotoTable().Update_Empty2Null(dr);

                            dr.ERROR_MSG = calLog;
                            dr.STATUS = "E";

                            continue;
                        }

                        /*取得所有的下轄的組織結構*/
                        var drsAllFrame = mod.getFrameHead_By_EndLike_FullFrameHeadUuid(_cal.FULL_FRAME_UUID_LIST);
                        /*由目前的組織往下找是未結點的組織*/
                        //drsAllFrame = drsAllFrame.Where(c => c.HASCHILD.Equals("Y")).ToList();
                        /*組織重新排序，以大到小排*/
                        drsAllFrame = drsAllFrame.Where(c => c.FULL_FRAME_UUID_LIST != _cal.FULL_FRAME_UUID_LIST).ToList();
                        drsAllFrame = drsAllFrame.OrderByDescending(c => c.DLEVEL).ToList();



                        List<string> ignorFrame = new List<string>();
                        List<string> calFrame = new List<string>();
                        //if (_cal.UUID == "14102820144200797")
                        //{
                        //    string dubug3 = "";
                        //}

                        foreach(var org in drsAllFrame){
                            System.Collections.Hashtable htCheckRaw = new System.Collections.Hashtable();
                            int numCheckRaw = 0;
                            foreach (var r in needRawUuid)
                            {
                                formula = formula.Replace("R!" + r, "[R" + r + "]");
                                //if (org.UUID == "14100622484301136" && r == "1007")
                                //{
                                //    string debug = "aaa";
                                //}
                                if (ignorFrame.Contains(org.UUID)==false) {
                                    var drsUploadJobj = getVUploadJobValue_EndLikeFullFrameHeadUuid(org.FULL_FRAME_UUID_LIST, r, _cal.TIME_ID);
                                    numCheckRaw += drsUploadJobj.Count;
                                }
                                else
                                {
                                    break;
                                }
                                
                            }

                            if (numCheckRaw == needRawUuid.Count)
                            {
                                /*找到了要計算的組織*/
                                string debug1 = "";
                                var l = org.FULL_FRAME_UUID_LIST.Split(':');
                                foreach (string i in l) { 
                                    if(i!=org.UUID){
                                        if (ignorFrame.Contains(i) == false)
                                        {
                                            ignorFrame.Add(i);
                                        }                                        
                                    }
                                }
                                calFrame.Add(org.FULL_FRAME_UUID_LIST);
                            }
                            else { 
                                /*沒有找到計算的組織*/
                            }                          
                        }

                        if (calFrame.Count > 0) {
                            /*可以計算的啟頭點*/
                            calLog += System.Environment.NewLine+ "【計算】組織:" + _cal.FULL_FRAME_NAME_LIST + System.Environment.NewLine;
                            calLog += "   KPI ID:" + _cal.KPI_ID + System.Environment.NewLine;
                            calLog += "   KPI 說明:" + _cal.C_DESC + System.Environment.NewLine;
                            calLog += "【公式】" + getFormula( _cal.FORMULA) + System.Environment.NewLine;
                            calLog += "【公式 for 程式】" + _cal.FORMULA + System.Environment.NewLine;

                            bool onlyKPI = false;
                            
                            if( _cal.FORMULA.IndexOf("R!")==-1 && _cal.FORMULA.IndexOf("K!")>=0 ){
                                calLog += "【計算偵測】執行同層指標計算" + System.Environment.NewLine;
                                onlyKPI = true;
                            } 



                            calLog += "【符合資料的下轄組織】" + System.Environment.NewLine;

                            //if (_cal.FULL_FRAME_NAME_LIST == "14081800014800015:14081900103900017:14100621385500509:" && _cal.KPI_ID == "14102819485800119")
                            //{
                            //    var debug = true;
                            //}
                            foreach (var _frame in calFrame) {
                                var _drFrame = mod.getFrameHead_By_Uuid(_frame.Split(':')[_frame.Split(':').Length - 2]).AllRecord().First();
                                calLog += System.Environment.NewLine+ _drFrame.C_NAME + System.Environment.NewLine;
                            }

                            calLog += "【計算元素】" + System.Environment.NewLine;


                            if (calFrame.Count == 1)
                            {
                                #region 只有一個組織符合資料時的計算方式
                                Expression e = new Expression(formula);
                                calLog += "【公式】" + getFormula( _cal.FORMULA) + System.Environment.NewLine;
                                calLog += "【公式 for 程式】" + _cal.FORMULA + System.Environment.NewLine;
                                calLog += "【只有一個下轄組織符合資料】" + System.Environment.NewLine;
                                System.Collections.Hashtable htRaw = new Hashtable();
                                System.Collections.Hashtable htPar = new Hashtable();
                                Hashtable htPi = new Hashtable();
                                var oneFrameHeadUuid = calFrame[0].Split(':')[calFrame[0].Split(':').Length - 2];
                                foreach (var r in needRawUuid)
                                {
                                    formula = formula.Replace("R!" + r, "[R" + r + "]");
                                    //if (_cal.FRAME_HEAD_UUID == "14100622484301136" && r == "1007")
                                    //{
                                    //    string debug = "aaa";
                                    //}
                                    var _drFrame = mod.getFrameHead_By_Uuid(oneFrameHeadUuid).AllRecord().First();
                                    var _drsVUploadJob = mod.getVUploadJobValue_EndLikeFullFrameHeadUuid(_drFrame.FULL_FRAME_UUID_LIST, r, _cal.TIME_ID, 1);
                                    var _drVUploadJob = _drsVUploadJob.Where(c => c.FRAME_HEAD_UUID.Equals(oneFrameHeadUuid)).First();
                                    decimal? value = _drVUploadJob.VALUE;
                                    if (value == null)
                                    {
                                        var drRawHead = mod.getRawHead_By_Uuid(r).AllRecord().First();
                                        var dr = _cal.Link_Cal_By_Uuid().First();
                                        calLog += "【計算元素不齊全】" + System.Environment.NewLine;
                                        calLog += "組織:" + _cal.FULL_FRAME_NAME_LIST + System.Environment.NewLine;
                                        calLog += "需要資料Id:" + drRawHead.RAW_ID + System.Environment.NewLine;
                                        calLog += "需要資料:" + drRawHead.C_DESC + System.Environment.NewLine;

                                        dr.CAL_LOG = "";
                                        dr.STATUS = "D";
                                        dr.ERROR_MSG = calLog;
                                        dr.gotoTable().Update_Empty2Null(dr);

                                        dr.CAL_LOG = dr.CAL_LOG;
                                        dr.STATUS = "D";

                                        jump = true;
                                    }
                                    else
                                    {
                                        htRaw.Add("R" + r + "", value.Value);
                                    }
                                }

                                foreach (var k in needKpiUuid)
                                {
                                    formula = formula.Replace("K!" + k, "[K" + k + "]");
                                    if (onlyKPI == false)
                                    {
                                        var _drFrame = mod.getFrameHead_By_Uuid(oneFrameHeadUuid).AllRecord().First();
                                        var pValue = mod.getVCal_By_FrameHeadUuid_TimeId_KpiHeadUuid(k, _drFrame.UUID, _cal.TIME_ID);
                                        htPi.Add("K" + k, pValue);
                                    }
                                    else {
                                        var _drFrame = mod.getFrameHead_By_Uuid(oneFrameHeadUuid).AllRecord().First();
                                        var pValue = mod.getVCal_By_FrameHeadUuid_TimeId_KpiHeadUuid(k, _drFrame.UUID, _cal.TIME_ID);
                                        htPi.Add("K" + k, pValue);
                                    }
                                }
                                foreach (var p in needParameterUuid)
                                {
                                    if (onlyKPI == false)
                                    {
                                        var _drFrame = mod.getFrameHead_By_Uuid(oneFrameHeadUuid).AllRecord().First();
                                        formula = formula.Replace("P!" + p, "[P" + p + "]");
                                        var pValue = mod.getVParameterQuery_Region_TimeId(p, _drFrame.REGION_UUID, _cal.TIME_ID);
                                        htPar.Add("P" + p, pValue);
                                    }
                                    else {
                                        var _drFrame = mod.getFrameHead_By_Uuid(oneFrameHeadUuid).AllRecord().First();
                                        formula = formula.Replace("P!" + p, "[P" + p + "]");
                                        var pValue = mod.getVParameterQuery_Region_TimeId(p, _drFrame.REGION_UUID, _cal.TIME_ID);
                                        htPar.Add("P" + p, pValue);
                                    }
                                    
                                }
                                e = new Expression(formula);


                                foreach (DictionaryEntry entry in htRaw)
                                {
                                    var drRawHead = mod.getRawHead_By_Uuid(entry.Key.ToString().Substring(1)).AllRecord().First();
                                    e.Parameters[entry.Key.ToString()] = Convert.ToDouble(entry.Value);
                                    calLog += "【" + drRawHead.UUID + "】" + drRawHead.RAW_ID + "(" + drRawHead.C_DESC + "):" + entry.Value.ToString() + System.Environment.NewLine;
                                }

                                if (htPar.Count > 0)
                                {
                                    calLog += "【系數資訊】" + System.Environment.NewLine;
                                    foreach (DictionaryEntry entry in htPar)
                                    {
                                        var _drP = mod.getParameterHead_By_Uuid(entry.Key.ToString().Substring(1)).AllRecord().First();
                                        e.Parameters[entry.Key.ToString()] = Convert.ToDouble(entry.Value);
                                        calLog += "【" + _drP.UUID + "】" + _drP.NAME + ":" + entry.Value.ToString() + System.Environment.NewLine;
                                    }
                                }
                                if (htPi.Count > 0)
                                {
                                    calLog += "【指標資訊】" + System.Environment.NewLine;
                                    var needJump = false;
                                    foreach (DictionaryEntry entry in htPi)
                                    {
                                        var _drP = mod.getKpiHead_By_Uuid(entry.Key.ToString().Substring(1)).AllRecord().First();
                                        e.Parameters[entry.Key.ToString()] = Convert.ToDouble(entry.Value);
                                        if (entry.Value == null)
                                        {
                                            calLog += "【缺少指標:" + _drP.UUID + "】" + _drP.C_DESC + System.Environment.NewLine;
                                            needJump = true;
                                        }
                                        else
                                        {
                                            calLog += "【" + _drP.UUID + "】" + _drP.C_DESC + ":" + entry.Value.ToString() + System.Environment.NewLine;
                                        }
                                    }

                                    if (needJump)
                                    {
                                        calLog += "【計算結果】無法計算"+System.Environment.NewLine+System.Environment.NewLine;
                                        var dr3 = _cal.Link_Cal_By_Uuid().First();
                                        _cal.VALUE = null;
                                        _cal.CAL_LOG = calLog;
                                        _cal.STATUS = "D";

                                        dr3.VALUE = _cal.VALUE;
                                        dr3.STATUS = "D";
                                        dr3.CAL_LOG = calLog;
                                        dr3.gotoTable().Update_Empty2Null(dr3);
                                        continue;
                                    }
                                }
                                var result = Convert.ToDecimal(e.Evaluate());
                                calLog += "【計算結果】" + result.ToString();
                                var dr2 = _cal.Link_Cal_By_Uuid().First();
                                _cal.VALUE = result;
                                _cal.CAL_LOG = calLog;
                                _cal.STATUS = "Y";

                                dr2.VALUE = _cal.VALUE;
                                dr2.STATUS = "Y";
                                dr2.CAL_LOG = calLog;
                                dr2.gotoTable().Update_Empty2Null(dr2);
                                #endregion

                            }
                            else
                            {
                                //if (_cal.UUID == "14102820144200797") {
                                //    string dubug3 = "";
                                //}
                                    
                                #region 有多個組織符合資料時的計算方式
                                var totalFrameCount = calFrame.Count;
                                var calTotalFrameCount = totalFrameCount;
                                
                                List<string> ignorFrame2 = new List<string>();
                                decimal? totalValue = 0;
                                calLog = "";
                                calLog += "【公式】" + getFormula( _cal.FORMULA )+ System.Environment.NewLine;
                                calLog += "【公式 for 程式】" + _cal.FORMULA + System.Environment.NewLine;
                                foreach (var _frameHead in calFrame)
                                {
                                    
                                    //if (_frameHead == "14081800014800015:14081900103900017:14100621385500509:")
                                    //{
                                    //    string debug4 = "14081800014800015:14081900103900017:14100621385500509:";
                                    //}
                                    Expression e = new Expression(formula);
                                    
                                    
                                    System.Collections.Hashtable htRaw = new Hashtable();
                                    System.Collections.Hashtable htPar = new Hashtable();
                                    Hashtable htPi = new Hashtable();

                                    

                                    var oneFrameHeadUuid = _frameHead.Split(':')[_frameHead.Split(':').Length - 2];

                                    //var drFrameHead = mod.getFrameHead_By_Uuid(oneFrameHeadUuid).AllRecord().First();

                                    var _drFrame = mod.getFrameHead_By_Uuid(oneFrameHeadUuid).AllRecord().First();
                                    calLog += System.Environment.NewLine+"【下轄組織符合資料】" + _drFrame.C_NAME + System.Environment.NewLine;
                                    foreach (var r in needRawUuid)
                                    {
                                        formula = formula.Replace("R!" + r, "[R" + r + "]");
                                        //if (_cal.FRAME_HEAD_UUID == "14100622484301136" && r == "1007")
                                        //{
                                        //    string debug = "aaa";
                                        //}
                                       
                                        var _drsVUploadJob = mod.getVUploadJobValue_EndLikeFullFrameHeadUuid(_drFrame.FULL_FRAME_UUID_LIST, r, _cal.TIME_ID, 1);
                                        var _drVUploadJob = _drsVUploadJob.Where(c => c.FRAME_HEAD_UUID.Equals(oneFrameHeadUuid)).First();
                                        decimal? value = _drVUploadJob.VALUE;
                                        if (value == null)
                                        {
                                            var drRawHead = mod.getRawHead_By_Uuid(r).AllRecord().First();
                                            var dr = _cal.Link_Cal_By_Uuid().First();
                                            calLog += "【計算元素不齊全】" + System.Environment.NewLine;
                                            calLog += "組織:" + _cal.FULL_FRAME_NAME_LIST + System.Environment.NewLine;
                                            calLog += "需要資料ID:" + drRawHead.RAW_ID  + System.Environment.NewLine;
                                            calLog += "需要資料:" +  drRawHead.C_DESC + System.Environment.NewLine;

                                            dr.CAL_LOG = "";
                                            dr.STATUS = "D";
                                            dr.ERROR_MSG = calLog;
                                            dr.gotoTable().Update_Empty2Null(dr);

                                            dr.CAL_LOG = dr.CAL_LOG;
                                            dr.STATUS = "D";

                                            jump = true;
                                        }
                                        else
                                        {
                                            htRaw.Add("R" + r + "", value.Value);
                                        }
                                    }

                                    foreach (var k in needKpiUuid)
                                    {
                                        formula = formula.Replace("K!" + k, "[K" + k + "]");
                                        if (onlyKPI == false)
                                        {
                                            var pValue = mod.getVCal_By_FrameHeadUuid_TimeId_KpiHeadUuid(k, _drFrame.UUID, _cal.TIME_ID);
                                            htPi.Add("K" + k, pValue);
                                        }
                                        else {
                                            /*執行同層計算*/
                                            var pValue = mod.getVCal_By_FrameHeadUuid_TimeId_KpiHeadUuid(k, _cal.FRAME_HEAD_UUID, _cal.TIME_ID);
                                            htPi.Add("K" + k, pValue);
                                        }
                                        
                                    }
                                    foreach (var p in needParameterUuid)
                                    {
                                        formula = formula.Replace("P!" + p, "[P" + p + "]");
                                        if (onlyKPI == false)
                                        {
                                            var pValue = mod.getVParameterQuery_Region_TimeId(p, _drFrame.REGION_UUID, _cal.TIME_ID);
                                            htPar.Add("P" + p, pValue);
                                        }
                                        else {
                                            var pValue = mod.getVParameterQuery_Region_TimeId(p, _cal.FRAME_HEAD_UUID, _cal.TIME_ID);
                                            htPar.Add("P" + p, pValue);
                                        }
                                    }

                                    e = new Expression(formula);
                                    foreach (DictionaryEntry entry in htRaw)
                                    {
                                        var drRawHead = mod.getRawHead_By_Uuid(entry.Key.ToString().Substring(1)).AllRecord().First();
                                        e.Parameters[entry.Key.ToString()] = Convert.ToDouble(entry.Value);
                                        calLog += "【" + drRawHead.UUID + "】" + drRawHead.RAW_ID + "(" + drRawHead.C_DESC + "):" + entry.Value.ToString() + System.Environment.NewLine;
                                    }

                                    if (htPar.Count > 0)
                                    {
                                        calLog += "【系數資訊】" + System.Environment.NewLine;
                                        foreach (DictionaryEntry entry in htPar)
                                        {
                                            var _drP = mod.getParameterHead_By_Uuid(entry.Key.ToString().Substring(1)).AllRecord().First();
                                            e.Parameters[entry.Key.ToString()] = Convert.ToDouble(entry.Value);
                                            calLog += "【" + _drP.UUID + "】" + _drP.NAME +  ":" + entry.Value.ToString() + System.Environment.NewLine;
                                        }
                                    }

                                    if (htPi.Count > 0)
                                    {
                                        calLog += "【指標資訊】" + System.Environment.NewLine;
                                        var needJump = false;
                                        var needIgnore = false;
                                        bool dis = false;
                                        foreach (DictionaryEntry entry in htPi)
                                        {
                                            var _drP = mod.getKpiHead_By_Uuid(entry.Key.ToString().Substring(1)).AllRecord().First();
                                            e.Parameters[entry.Key.ToString()] = Convert.ToDouble(entry.Value);
                                            if (entry.Value == null)
                                            {
                                                calLog += "【缺少指標:" + _drP.UUID + "】" + _drP.C_DESC + System.Environment.NewLine;
                                                if (dis == false)
                                                {
                                                    /*為了避免重覆減值的問題*/
                                                    calTotalFrameCount--;
                                                    dis = true;
                                                }
                                                needJump = true;
                                                
                                            }
                                            else
                                            {
                                                calLog += "【" + _drP.UUID + "】" + _drP.C_DESC + ":" + entry.Value.ToString() + System.Environment.NewLine;

                                                if (ignorFrame2.Contains(_drFrame.UUID)) {

                                                    needIgnore = true;
                                                }
                                            }
                                        }

                                        if (needIgnore)
                                        {
                                            calTotalFrameCount--;
                                            continue;
                                        }

                                        if (needJump)
                                        {
                                            calLog += "【計算結果】無法計算" + System.Environment.NewLine + System.Environment.NewLine;
                                            var dr3 = _cal.Link_Cal_By_Uuid().First();
                                            _cal.VALUE = null;
                                            _cal.CAL_LOG = calLog;
                                            _cal.STATUS = "D";

                                            dr3.VALUE = _cal.VALUE;
                                            dr3.STATUS = "D";
                                            dr3.CAL_LOG = calLog;
                                            dr3.gotoTable().Update_Empty2Null(dr3);
                                            continue;
                                        }
                                        else {
                                            var expFrame = _drFrame.FULL_FRAME_UUID_LIST.Split(':');
                                            foreach (var _ef in expFrame) {
                                                if (_drFrame.UUID == _ef) {
                                                    continue;/*要跳過自已*/
                                                }
                                                if (ignorFrame2.Contains(_ef) == false)
                                                {
                                                    ignorFrame2.Add(_ef);                                                    
                                                }
                                               
                                            }
                                            
                                        }

                                    }

                                    var result = Convert.ToDecimal(e.Evaluate());
                                    calLog += "【計算結果】" + result.ToString() + System.Environment.NewLine;

                                    if (onlyKPI == false)
                                    {
                                        totalValue += result;
                                    }
                                    else {
                                        totalValue = result;
                                        break;
                                    }
                                    calLog +=  System.Environment.NewLine;
                                   
                                    
                                }

                                var dr2 = _cal.Link_Cal_By_Uuid().First();
                                var drKpiHead = mod.getKpiHead_By_Uuid(_cal.KPI_HEAD_UUID).AllRecord().First();

                                decimal? finishValue = 0;
                                if (onlyKPI == false)
                                {
                                    if (drKpiHead.NEED_SUMMARY == "Y")
                                    {
                                        /*求總合值*/
                                        calLog += "【總計 求 總合】" + System.Environment.NewLine;




                                        calLog += "      組織數目:" + totalFrameCount.ToString() + System.Environment.NewLine;

                                        calLog += "      組織數目(有效):" + calTotalFrameCount.ToString() + System.Environment.NewLine;

                                        calLog += "      數值合計:" + totalValue + System.Environment.NewLine;
                                        finishValue = totalValue;


                                    }
                                    else
                                    {
                                        /*求平均值*/
                                        calLog += "【總計 求 平均】" + System.Environment.NewLine;
                                        calLog += "      組織數目：" + totalFrameCount.ToString() + System.Environment.NewLine;
                                        calLog += "      組織數目(有效):" + calTotalFrameCount.ToString() + System.Environment.NewLine;
                                        calLog += "      數值合計：" + totalValue + System.Environment.NewLine;
                                        calLog += "          平均：" + totalValue.ToString() + "/" + calTotalFrameCount.ToString() + "=" + (totalValue / calTotalFrameCount).ToString() + System.Environment.NewLine;
                                        finishValue = (totalValue / calTotalFrameCount);
                                    }


                                }
                                else {
                                    finishValue = totalValue;
                                }


                                _cal.VALUE = finishValue;
                                _cal.CAL_LOG = calLog;
                                _cal.STATUS = "Y";

                                dr2.VALUE = finishValue;
                                dr2.STATUS = "Y";
                                dr2.CAL_LOG = calLog;
                                dr2.gotoTable().Update_Empty2Null(dr2);

                                #endregion
                            }





                        }
                        else
                        {
                            
                            calLog += "組織:" + _cal.FULL_FRAME_NAME_LIST + System.Environment.NewLine;
                            calLog += "【沒有找到可計算的組織】" + System.Environment.NewLine;
                            //calLog += "【需要的資料】" + System.Environment.NewLine;

                            //calLog += "需要資料:(" + drRawHead.RAW_ID + ")" + drRawHead.C_DESC + System.Environment.NewLine;

                           
                            


                            var dr = _cal.Link_Cal_By_Uuid().First();
                            dr.CAL_LOG = calLog;
                            dr.STATUS = "D";
                            dr.ERROR_MSG = calLog;
                            dr.gotoTable().Update_Empty2Null(dr);                            
                            dr.STATUS = "D";
                            dr.gotoTable().Update_Empty2Null(dr);
                        }
                        


                    }

                    


                   

                }
            }
            catch (Exception ex) {
                throw ex;
            }

        }

        public string getFormula(string algorith) {
            try
            {
                CrModel mod = new CrModel();
                var drs = mod.getKpiFormula_By_Algorithm(algorith);
                if (drs.Count == 0)
                {
                    return "【注意】公式內容於目前指票的公式不符合";
                }
                else {
                    return drs.First().ALGORITHM_MAN;
                }
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public decimal? getUploadJobValue(string frameHeadUuid, string rawHeadUuid, string timeId)
        {
            decimal? ret = null;
            try
            {
                CrModel mod = new CrModel();
                var drs = mod.getUploadJob_By_FrameHeadUuid_RawHeadUuid_TimeId(frameHeadUuid, rawHeadUuid, timeId, 1);
                if (drs.Count == 1)
                {
                    ret = drs.First().VALUE.Value;
                }
                else {
                    ret = null;
                }
                return ret;
            }
            catch (Exception ex) {
                throw ex;
            }

        }

        public IList<UploadJob_Record> getVUploadJobValue_EndLikeFullFrameHeadUuid(string pFullFrameHeadUuid, string rawHeadUuid, string timeId)
        {
            
            try
            {
                CrModel mod = new CrModel();
                var drs = mod.getVUploadJobValue_EndLikeFullFrameHeadUuid(pFullFrameHeadUuid, rawHeadUuid, timeId, 1);
               
                return drs;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}