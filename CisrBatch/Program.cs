using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CISR.Controller.Model.Basic;
using CISR.Controller.Model.Cloud;

using CISR.Model.Cr;
using CISR.Model.Cr.Table;
using CISR.Model.Cr.Table.Record;
using NCalc;
using System.Collections;
using IST.DB.SQLCreater;
namespace CisrBatch
{
    class Program
    {
        static void Main(string[] args)
        {

            //cal();
            Program p = new Program();
            args = new string[] { "CAL" };

            if (args.Length == 0)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(CISR.Parameter.Config.ParemterConfigs.GetConfig().TriggerFile);
                List<string> command = new List<string>();
                List<string> newLit = new List<string>();
                string line = "";
                string str = "";
                while ((line = sr.ReadLine()) != null)
                {
                    command.Add(line);
                }
                sr.Close();
                foreach (var tmp in command)
                {
                    string action = tmp.Split('!')[0];
                    if (action == "startJob")/*展開上傳工作*/
                    {
                        string arrFrameHeadUuid = tmp.Split('!')[1];
                        string pTimeType = tmp.Split('!')[2];
                        string startTimeId = tmp.Split('!')[3];
                        string endTimeId = tmp.Split('!')[4];
                        string companyUuid = tmp.Split('!')[5];
                        p.startJob(companyUuid, pTimeType, startTimeId, endTimeId, arrFrameHeadUuid);
                    }
                    else if (action == "expCal") /*展開每一個計算項目*/
                    {
                        string pArrFrameHeadUuid = tmp.Split('!')[1];
                        string pStartTimeId = tmp.Split('!')[2];
                        string pEndTimeId = tmp.Split('!')[3];
                        try
                        {
                            p.expCal(pArrFrameHeadUuid, pStartTimeId, pEndTimeId);
                        }
                        catch (Exception ex1) {
                            throw ex1;
                        }
                    }
                }

                sr = new System.IO.StreamReader(CISR.Parameter.Config.ParemterConfigs.GetConfig().TriggerFile);
                while ((str = sr.ReadLine()) != null)
                {

                    newLit.Add(str);

                }
                sr.Close();

                List<string> wrietLit = new List<string>();
                var sw = new System.IO.StreamWriter(CISR.Parameter.Config.ParemterConfigs.GetConfig().TriggerFile, false);

                foreach (var tmp in newLit)
                {
                    if (command.Contains(tmp) == false)
                    {
                        sw.WriteLine(tmp);
                    }
                }
                sw.Close();

            }
            else if (args[0] == "CAL") {
                p.cal();
            }
        }


        public void startJob(string companyUuid,string pTimeType, string startTimeId, string endTimeId, string arrFrameHeadUuid)
        {
            #region Declare
            BasicModel model = new BasicModel();
            CrModel mod = new CrModel();
            #endregion
            try
            {  
                var _arrFrameHeadUuid = arrFrameHeadUuid.Split(';');
                foreach (var frameHeadUuid in _arrFrameHeadUuid)
                {
                    if (frameHeadUuid.Trim().Length > 0)
                    {
                        var drsVFrameItem = mod.getVFrameItem_By_FrameHeadUuid_TimeType(frameHeadUuid, pTimeType, new IST.DB.SQLCreater.OrderLimit());
                        foreach (var itemVFrameItem in drsVFrameItem)
                        {
                            for (int s = Convert.ToInt32(startTimeId); s <= Convert.ToInt32(endTimeId); s++)
                            {
                                if (itemVFrameItem.SKIP == "N")
                                {
                                    /*檢查資料是否已經存在*/

                                    //var drsCheck = mod.getUploadJob_By_FrameHeadUuid_RawHeadUuid_TimeId(frameHeadUuid, itemVFrameItem.RAW_HEAD_UUID, s.ToString());
                                    //if (drsCheck.Count > 0) {
                                    //    continue;
                                    //}

                                    var checkHasData = mod.getUploadJob_By_FrameHeadUuid_RawHeadUuid_TimeId(itemVFrameItem.FRAME_HEAD_UUID, itemVFrameItem.RAW_HEAD_UUID, s.ToString());
                                    if (checkHasData.Count > 0)
                                    {
                                        continue;
                                    }

                                    UploadJob_Record drUploadJob = new UploadJob_Record();
                                    drUploadJob.UUID = IST.Util.UID.Instance.GetUniqueID();
                                    drUploadJob.COMPANY_UUID = companyUuid;
                                    drUploadJob.FRAME_HEAD_UUID = itemVFrameItem.FRAME_HEAD_UUID;
                                    drUploadJob.RAW_HEAD_UUID = itemVFrameItem.RAW_HEAD_UUID;
                                    drUploadJob.SKIP = "N";
                                    drUploadJob.STATUS = 1;
                                    drUploadJob.TIME_ID = s.ToString();
                                    drUploadJob.UPDATE_DATE = DateTime.Now;
                                    drUploadJob.VALUE = null;



                                    for (var flowNo = 1; flowNo <= itemVFrameItem.LAST_FLOW; flowNo++)
                                    {
                                        Dwg_Record dwg = new Dwg_Record();
                                        dwg.DWG_GID = IST.Util.UID.Instance.GetUniqueID();
                                        if (flowNo == 1)
                                        {
                                            var drsFlowMember = mod.getPwg_By_Uuid(itemVFrameItem.PWG1_GID);
                                            string fullAttendantUuid = "";
                                            foreach (var member in drsFlowMember)
                                            {
                                                if (member.ATTENDANT_UUID != "")
                                                {
                                                    dwg.ATTENDANT_UUID = member.ATTENDANT_UUID;
                                                    fullAttendantUuid += dwg.ATTENDANT_UUID + ":";
                                                    dwg.gotoTable().Insert_Empty2Null(dwg);
                                                }

                                            }
                                            drUploadJob.DWG1_GID = dwg.DWG_GID;
                                            drUploadJob.DWG1_SHOW = itemVFrameItem.PWG1_SHOW;
                                            drUploadJob.FULL_ATTENDANT_UUID = fullAttendantUuid;
                                            drUploadJob.NOW_ATTENDANT_UUID = fullAttendantUuid;

                                        }
                                        else if (flowNo == 2)
                                        {
                                            var drsFlowMember = mod.getPwg_By_Uuid(itemVFrameItem.PWG2_GID);
                                            string fullAttendantUuid = "";
                                            foreach (var member in drsFlowMember)
                                            {
                                                if (member.ATTENDANT_UUID != "")
                                                {
                                                    dwg.ATTENDANT_UUID = member.ATTENDANT_UUID;
                                                    dwg.gotoTable().Insert_Empty2Null(dwg);
                                                    fullAttendantUuid += dwg.ATTENDANT_UUID + ":";
                                                }
                                            }
                                            drUploadJob.DWG2_GID = dwg.DWG_GID;
                                            drUploadJob.DWG2_SHOW = itemVFrameItem.PWG2_SHOW;
                                            drUploadJob.FULL_ATTENDANT_UUID += fullAttendantUuid;
                                        }
                                        else if (flowNo == 3)
                                        {
                                            var drsFlowMember = mod.getPwg_By_Uuid(itemVFrameItem.PWG3_GID);
                                            string fullAttendantUuid = "";
                                            foreach (var member in drsFlowMember)
                                            {
                                                if (member.ATTENDANT_UUID != "")
                                                {
                                                    dwg.ATTENDANT_UUID = member.ATTENDANT_UUID;
                                                    dwg.gotoTable().Insert_Empty2Null(dwg);
                                                    fullAttendantUuid += dwg.ATTENDANT_UUID + ":";
                                                }
                                            }
                                            drUploadJob.DWG3_GID = dwg.DWG_GID;
                                            drUploadJob.DWG3_SHOW = itemVFrameItem.PWG3_SHOW;
                                            drUploadJob.FULL_ATTENDANT_UUID += fullAttendantUuid;
                                        }
                                        else if (flowNo == 4)
                                        {
                                            var drsFlowMember = mod.getPwg_By_Uuid(itemVFrameItem.PWG4_GID);
                                            string fullAttendantUuid = "";
                                            foreach (var member in drsFlowMember)
                                            {
                                                if (member.ATTENDANT_UUID != "")
                                                {
                                                    dwg.ATTENDANT_UUID = member.ATTENDANT_UUID;
                                                    dwg.gotoTable().Insert_Empty2Null(dwg);
                                                    fullAttendantUuid += dwg.ATTENDANT_UUID + ":";
                                                }
                                            }
                                            drUploadJob.DWG4_GID = dwg.DWG_GID;
                                            drUploadJob.DWG4_SHOW = itemVFrameItem.PWG4_SHOW;
                                            drUploadJob.FULL_ATTENDANT_UUID += fullAttendantUuid;
                                        }
                                        else if (flowNo == 5)
                                        {
                                            var drsFlowMember = mod.getPwg_By_Uuid(itemVFrameItem.PWG5_GID);
                                            string fullAttendantUuid = "";
                                            foreach (var member in drsFlowMember)
                                            {
                                                if (member.ATTENDANT_UUID != "")
                                                {
                                                    dwg.ATTENDANT_UUID = member.ATTENDANT_UUID;
                                                    dwg.gotoTable().Insert_Empty2Null(dwg);
                                                    fullAttendantUuid += dwg.ATTENDANT_UUID + ":";
                                                }
                                            }
                                            drUploadJob.DWG5_GID = dwg.DWG_GID;
                                            drUploadJob.DWG5_SHOW = itemVFrameItem.PWG5_SHOW;
                                            drUploadJob.FULL_ATTENDANT_UUID += fullAttendantUuid;
                                        }
                                    }


                                    drUploadJob.gotoTable().Insert_Empty2Null(drUploadJob);

                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void expCal(string pArrFrameHeadUuid, string startTimeId, string endTimeId)
        {
            #region Declare            
            CrModel mod = new CrModel();
            string pTimeId = "";
            #endregion
            try
            {
                if (startTimeId.Trim().Length < 4 && endTimeId.Trim().Length < 4)
                {
                    throw new Exception("時間屬性未設定");
                }

                string[] arrFrameHeadUuid = pArrFrameHeadUuid.Split(';');
                List<String> calFrameHeadUuid = new List<string>();
                foreach (string fuuid in arrFrameHeadUuid)
                {
                    if (fuuid.Trim().Length > 0)
                    {
                        var currFrameHeadAll = mod.getFrameHead_By_Uuid(fuuid).AllRecord();
                        if (currFrameHeadAll.Count == 0)
                            continue;
                        var currFrameHead = currFrameHeadAll.First();
                        if (currFrameHead.FULL_FRAME_UUID_LIST.Split(':').Length >= 4)
                        {
                            if (calFrameHeadUuid.Exists(c => c.Equals(currFrameHead.FULL_FRAME_UUID_LIST.Split(':')[2])))
                            {
                                /*存在不做事*/
                            }
                            else
                            {
                                /*預要計算的組織*/
                                calFrameHeadUuid.Add(currFrameHead.FULL_FRAME_UUID_LIST.Split(':')[2]);
                            }
                        }
                    }
                }

                foreach (var frameHeadUuid in calFrameHeadUuid)
                {
                    
                    var drFrameHeadUuid = mod.getFrameHead_By_Uuid(frameHeadUuid).AllRecord().First();
                    Console.WriteLine("正在展開計算:" + drFrameHeadUuid.C_NAME);
                    var drsFrameHeadUuid = mod.getFrameHead_By_EndLike_FullFrameHeadUuid(drFrameHeadUuid.FULL_FRAME_UUID_LIST);
                    
                    /*由dlevel由大到小先排序好*/
                    var drsOrdFrameHeadUuid = drsFrameHeadUuid.ToList().OrderByDescending(c => c.DLEVEL).ToList();
                    /*預要計算的時間點找出來*/
                    List<int> calTime = new List<int>();
                    /*把要計算的KPI Item 展開到 cal 的資料表中*/
                    if (startTimeId.Length == 4 && endTimeId.Length == 4)
                    {
                        /*要計算年的資料*/
                        for (var i = Convert.ToInt32(startTimeId); i <= Convert.ToInt32(endTimeId); i++)
                        {
                            calTime.Add(i);

                            pTimeId += i + ";";

                        }
                    }
                    else if (startTimeId.Length == 6 && endTimeId.Length == 6)
                    {
                        /*要計算月的資料*/
                        for (var i = Convert.ToInt32(startTimeId); i <= Convert.ToInt32(endTimeId); i++)
                        {
                            calTime.Add(i);
                            pTimeId += i + ";";
                        }
                    }

                    foreach (var iTimeId in calTime)
                    {
                        Console.WriteLine("正在展開計算時間點為:" + iTimeId);

                        foreach (var dFrameHeadUuid in drsOrdFrameHeadUuid)
                        {
                            /*找出所有要計算的KPI Item*/
                            try
                            {
                                var drsKpiPackageItem = dFrameHeadUuid.Link_KpiPackage_By_Uuid().First().Link_KpiPackageItem_By_KpiPackageUuid();
                                Cal_Record drCal = new Cal_Record();
                                foreach (var kpipackageitem in drsKpiPackageItem)
                                {
                                    var drsCal = mod.getCal_By_FrameHeadUuid_TimeID_KpiHeadUuid(dFrameHeadUuid.UUID, iTimeId.ToString(), kpipackageitem.KPI_HEAD_UUID);
                                    if (drsCal.Count() == 0)
                                    {
                                        Cal_Record newCal = new Cal_Record();
                                        newCal.UUID = IST.Util.UID.Instance.GetUniqueID();
                                        newCal.CAL_LOG = "";
                                        newCal.ERROR_MSG = "";
                                        newCal.FORMULA = "";
                                        newCal.FRAME_HEAD_UUID = dFrameHeadUuid.UUID;
                                        newCal.FRAME_LEVEL = dFrameHeadUuid.DLEVEL;
                                        newCal.KPI_HEAD_UUID = kpipackageitem.KPI_HEAD_UUID;
                                        newCal.ORD = null;
                                        newCal.STATUS = "W";
                                        newCal.TIME_ID = iTimeId.ToString();
                                        newCal.VALUE = null;
                                        newCal.gotoTable().Insert_Empty2Null(newCal);
                                    }
                                    else
                                    {
                                        /*因為有資料所以要重新初始化資料的參數*/
                                        foreach (var item in drsCal)
                                        {
                                            if (item.STATUS == "W")
                                            {
                                                continue;
                                            }
                                            item.STATUS = "W";
                                            item.ERROR_MSG = "";
                                            item.FORMULA = "";
                                            item.ORD = null;
                                            item.FORMULA = "";
                                            item.CAL_LOG = "";
                                            item.gotoTable().Update_Empty2Null(item);
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                if (ex.Message == "序列未包含項目")
                                {
                                    continue;
                                }
                            }



                        }
                    }

                    /*開始要展開計算的公式*/
                    foreach (var iTimeId in calTime)
                    {
                        /*填入合適的公式到cal的formula的欄位中*/
                        foreach (var dFrameHeadUuid in drsOrdFrameHeadUuid)
                        {
                            var drsCal = mod.getCal_By_FrameHeadUuid_TimeID(dFrameHeadUuid.UUID, iTimeId.ToString());
                            foreach (var cal in drsCal)
                            {
                                //cal.KPI_HEAD_UUID
                                var drsVKpiItem = mod.getVKpiItem(cal.KPI_HEAD_UUID, new OrderLimit("TIME_ID", OrderLimit.OrderMethod.ASC));
                                foreach (var vkpiitem in drsVKpiItem)
                                {
                                    if (Convert.ToInt32(vkpiitem.TIME_ID) <= iTimeId)
                                    {
                                        cal.FORMULA = vkpiitem.ALGORITHM;
                                        cal.gotoTable().Update_Empty2Null(cal);
                                    }
                                }
                            }
                       
                        }

                        /*開始調整公式計算的順序,先找出只有 +，-，*的計算項目，並使於ord = 1 */
                        Cal calTable = new Cal();
                        foreach (var dFrameHeadUuid in drsOrdFrameHeadUuid)
                        {
                            var drsCal = mod.getCal_By_FrameHeadUuid_TimeID(dFrameHeadUuid.UUID, iTimeId.ToString());

                            foreach (var cal in drsCal)
                            {
                                if (cal.FORMULA.IndexOf("K!") == -1)
                                {
                                    cal.ORD = 1;
                                }
                                else
                                {
                                    cal.ORD = null;
                                }
                                calTable.AllRecord().Add(cal.Clone());
                            }

                        }
                        calTable.UpdateAllRecord();

                        /*要進行第二次的排序*/
                        foreach (var dFrameHeadUuid in drsOrdFrameHeadUuid)
                        {
                            var drsCal = mod.getCal_By_FrameHeadUuid_TimeID(dFrameHeadUuid.UUID, iTimeId.ToString());
                            if (drsCal.Count > 0)
                            {
                                string debug1 = "";
                            }
                            while (drsCal.Count(c => c.ORD.ToString().Equals("")) > 0)
                            {
                                setOrd(ref drsCal);
                            }

                            foreach (var item in drsCal)
                            {
                                item.gotoTable().Update_Empty2Null(item);
                            }
                        }
                    }
                    /*開始提出計算的請求*/
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int? setOrd(ref IList<Cal_Record> cal)
        {
            int? retValue = null;
            try
            {
                var drsCal = cal.Where(c => c.ORD.ToString().Equals("")).ToList();
                foreach (var dr in drsCal)
                {

                    var arrTmp = dr.FORMULA.Split(new char[] { '(', ')', '+', '-', '*', '/', '\\' });
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
                                if (Convert.ToInt16(_drCal.ORD) > max)
                                {
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void cal() {
            try
            {
                Console.WriteLine("執行計算...");
                CrModel mod = new CrModel();
                var allTime = mod.getVCal_Distinct_TimeId_By_Wait();
                Console.WriteLine("===計算範圍===");
                foreach (var tmp in allTime)
                {
                    Console.WriteLine(tmp.TIME_ID.ToString());
                }
                Console.WriteLine("===計算範圍===");
                foreach (var tmp in allTime)
                {                    
                    var p = new List<string>();
                    Console.WriteLine("計間時間屬性為:" + tmp.TIME_ID.ToString());
                    p.Add(tmp.TIME_ID.ToString());
                    callMaster(null, p, null);
                }             
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.Message);
                Console.Write(ex.InnerException.Source);
                Console.Write(ex.InnerException.StackTrace);

                Console.Write(ex.Message);
                Console.Write(ex.Source);
                Console.Write(ex.StackTrace);
               // Console.ReadLine();
            }
        }


        public void callMaster(List<string> frame, List<string> timeId, String KpiId)
        {
            CrModel mod = new CrModel();
            string calLog = "";
            try
            {
                /*所有要計算的計劃*/
                var drsCal = mod.getVCal_By_Wait();
                Console.WriteLine("計算KPI數量為:"+drsCal.Count().ToString());

                List<UploadJob_Record> calData = new List<UploadJob_Record>();
                System.Collections.Hashtable htTimeId = new System.Collections.Hashtable();
                foreach (var _cal in drsCal)
                {
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
                    /*將公式欄位解開，分成 上傳資料、kpi、係數等三個*/
                    List<string> needRawUuid = new List<string>();
                    List<string> needKpiUuid = new List<string>();
                    List<string> needParameterUuid = new List<string>();

                    /*由Upload_Record中找出上傳元素*/
                    /*由cal_Record中找出KPI元素*/
                    /*有條件式的找出Parameter元素*/
                    var allElment = _cal.FORMULA.Split(new char[] { '!', '(', ')', '{', '}', '+', '-', '*', '/' });
                    Console.WriteLine("正在分析KPI:" + _cal.KPI_ID + "," + _cal.C_NAME);
                    for (var i = 0; i < allElment.Length; i++)
                    {
                        if (allElment[i] == "R")
                        {
                            Console.WriteLine("    發現R");
                            if (needRawUuid.Contains(allElment[i + 1]) == false)
                            {
                                needRawUuid.Add(allElment[i + 1]);
                            }
                            i++;
                        }
                        else if (allElment[i] == "K")
                        {
                            Console.WriteLine("    發現K");
                            if (needKpiUuid.Contains(allElment[i + 1]) == false)
                            {
                                needKpiUuid.Add(allElment[i + 1]);
                            }
                            i++;
                        }
                        else if (allElment[i] == "P")
                        {
                            Console.WriteLine("    發現P");
                            if (needParameterUuid.Contains(allElment[i + 1]) == false)
                            {
                                needParameterUuid.Add(allElment[i + 1]);
                            }
                            i++;
                        }
                    }

                    if (_cal.HASCHILD == "N")
                    {
                        Console.WriteLine(_cal.FULL_FRAME_NAME_LIST + "是未節點!");
                        /*不需要重新整理公式*/
                        /*注意事項
                         *在該層只有資料完全準備好才計算
                         */
                        string formula = _cal.FORMULA;
                        Console.WriteLine("公式:"+formula);
                        if (formula.Trim() == "")
                        {
                            var dr = _cal.Link_Cal_By_Uuid().First();
                            calLog = "發現此指標沒有設定公式";
                            Console.WriteLine(calLog);
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
                        Console.WriteLine("===搜尋相關上傳/KPI/Parameter資料===");
                        foreach (var r in needRawUuid)
                        {
                            Console.WriteLine("發現R");
                            formula = formula.Replace("R!" + r, "[R" + r + "]");
                            //if (_cal.FRAME_HEAD_UUID == "14100622484301136" && r == "1007") {
                            //    string debug = "aaa";
                            //}
                            decimal? value = getUploadJobValue(_cal.FRAME_HEAD_UUID, r, _cal.TIME_ID);
                            if (value == null)
                            {
                                var drRawHead = new RawHead_Record();
                                if (mod.getRawHead_By_Uuid(r).AllRecord().Count > 0)
                                {
                                    drRawHead = mod.getRawHead_By_Uuid(r).AllRecord().First();
                                    var dr = _cal.Link_Cal_By_Uuid().First();

                                    calLog += System.Environment.NewLine + System.Environment.NewLine + "【計算元素不齊全】" + System.Environment.NewLine;
                                    calLog += "組織:" + _cal.FULL_FRAME_NAME_LIST + System.Environment.NewLine;
                                    Console.WriteLine("組織:" + _cal.FULL_FRAME_NAME_LIST);
                                    calLog += "需要資料:(" + drRawHead.RAW_ID + ")" + drRawHead.C_DESC + System.Environment.NewLine;
                                    Console.WriteLine("需要資料:(" + drRawHead.RAW_ID + ")" + drRawHead.C_DESC);
                                    dr.CAL_LOG = "";
                                    dr.STATUS = "D";
                                    dr.ERROR_MSG = calLog;
                                    dr.gotoTable().Update_Empty2Null(dr);

                                    dr.CAL_LOG = dr.CAL_LOG;
                                    dr.STATUS = "D";
                                }
                                else
                                {
                                    calLog += System.Environment.NewLine + System.Environment.NewLine + "【計算元素找不到請先檢查公式是否有誤】" + System.Environment.NewLine;
                                    calLog += "【RAW_HEAD_UUID】:" +r+ System.Environment.NewLine;
                                    calLog += "組織:" + _cal.FULL_FRAME_NAME_LIST + System.Environment.NewLine;

                                    Console.WriteLine("【計算元素找不到請先檢查公式是否有誤】");
                                    Console.WriteLine("【RAW_HEAD_UUID】:" + r);
                                    Console.WriteLine("組織:" + _cal.FULL_FRAME_NAME_LIST);

                                    var dr = _cal.Link_Cal_By_Uuid().First();

                                    dr.CAL_LOG = "";
                                    dr.STATUS = "D";
                                    dr.ERROR_MSG = calLog;
                                    dr.gotoTable().Update_Empty2Null(dr);

                                    dr.CAL_LOG = dr.CAL_LOG;
                                    dr.STATUS = "D";
                                }
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
                            Console.WriteLine("發現K");
                            formula = formula.Replace("K!" + k, "[K" + k + "]");
                            Console.WriteLine(formula);
                            var _drFrame = mod.getFrameHead_By_Uuid(_cal.FRAME_HEAD_UUID).AllRecord().First();
                            var pValue = mod.getVCal_By_FrameHeadUuid_TimeId_KpiHeadUuid(k, _drFrame.UUID, _cal.TIME_ID);
                            Console.WriteLine(k+":"+pValue.Value.ToString());
                            htPi.Add("K" + k, pValue);
                        }

                        foreach (var p in needParameterUuid)
                        {
                            Console.WriteLine("發現P");
                            formula = formula.Replace("P!" + p, "[P" + p + "]");
                            var _drFrame = mod.getFrameHead_By_Uuid(_cal.FRAME_HEAD_UUID).AllRecord().First();
                            var pValue = mod.getVParameterQuery_Region_TimeId(p, _drFrame.REGION_UUID, _cal.TIME_ID);
                            Console.WriteLine(p + ":" + pValue.Value.ToString());
                            htPar.Add("P" + p, pValue);
                        }
                        e = new Expression(formula);
                        calLog += "【計算】組織:" + _cal.FULL_FRAME_NAME_LIST + System.Environment.NewLine;
                        calLog += " KPI ID:" + _cal.KPI_ID + System.Environment.NewLine;
                        calLog += " KPI 說明:" + _cal.C_DESC + System.Environment.NewLine;
                        calLog += "【公式】" + getFormula(_cal.FORMULA) + System.Environment.NewLine;
                        calLog += "【公式 for 程式】" + _cal.FORMULA + System.Environment.NewLine;
                        calLog += "【計算元素】" + System.Environment.NewLine;

                        Console.WriteLine("【計算】組織:" + _cal.FULL_FRAME_NAME_LIST);
                        Console.WriteLine(" KPI ID:" + _cal.KPI_ID);
                        Console.WriteLine(" KPI 說明:" + _cal.C_DESC);
                        Console.WriteLine("【公式】" + getFormula(_cal.FORMULA));
                        Console.WriteLine("【公式 for 程式】" + _cal.FORMULA);
                        Console.WriteLine("【計算元素】");
                        

                        foreach (DictionaryEntry entry in htRaw)
                        {
                            var drRawHead = mod.getRawHead_By_Uuid(entry.Key.ToString().Substring(1)).AllRecord().First();
                            e.Parameters[entry.Key.ToString()] = Convert.ToDouble(entry.Value);
                            calLog += "【" + drRawHead.UUID + "】" + drRawHead.RAW_ID + "(" + drRawHead.C_DESC + "):" + entry.Value.ToString() + System.Environment.NewLine;

                            Console.WriteLine("【" + drRawHead.UUID + "】" + drRawHead.RAW_ID + "(" + drRawHead.C_DESC + "):" + entry.Value.ToString());

                        }

                        if (htPar.Count > 0)
                        {
                            calLog += System.Environment.NewLine + "【系數資訊】" + System.Environment.NewLine;
                            Console.WriteLine("【系數資訊】");
                            foreach (DictionaryEntry entry in htPar)
                            {
                                var _drP = mod.getParameterHead_By_Uuid(entry.Key.ToString().Substring(1)).AllRecord().First();
                                e.Parameters[entry.Key.ToString()] = Convert.ToDouble(entry.Value);
                                calLog += "【" + _drP.UUID + "】" + _drP.NAME + ":" + entry.Value.ToString() + System.Environment.NewLine;
                                Console.WriteLine("【" + _drP.UUID + "】" + _drP.NAME + ":" + entry.Value.ToString());
                            }
                        }

                        if (htPi.Count > 0)
                        {
                            calLog += "【指標資訊】" + System.Environment.NewLine;
                            Console.WriteLine("【指標資訊】");
                            var needJump = false;
                            foreach (DictionaryEntry entry in htPi)
                            {
                                var _drP = mod.getKpiHead_By_Uuid(entry.Key.ToString().Substring(1)).AllRecord().First();
                                e.Parameters[entry.Key.ToString()] = Convert.ToDouble(entry.Value);
                                if (entry.Value == null)
                                {
                                    calLog += "【缺少指標:" + _drP.UUID + "】" + _drP.C_DESC + System.Environment.NewLine;
                                    Console.WriteLine("【缺少指標:" + _drP.UUID + "】" + _drP.C_DESC);
                                    needJump = true;
                                }
                                else
                                {
                                    calLog += "【" + _drP.UUID + "】" + _drP.C_DESC + ":" + entry.Value.ToString() + System.Environment.NewLine;
                                    Console.WriteLine("【" + _drP.UUID + "】" + _drP.C_DESC + ":" + entry.Value.ToString());
                                }
                            }

                            if (needJump)
                            {
                                calLog += "【計算結果】無法計算" + System.Environment.NewLine + System.Environment.NewLine;
                                Console.WriteLine("【計算結果】無法計算" + System.Environment.NewLine + System.Environment.NewLine);
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
                        var result= new  decimal();
                        try
                        {
                            result = Convert.ToDecimal(e.Evaluate());
                        }
                        catch (Exception ex) {
                            calLog += "ERROR:" + ex.Message;
                            _cal.CAL_LOG = calLog;
                            _cal.STATUS = "E";
                            var dr22 = _cal.Link_Cal_By_Uuid().First();
                            dr22.VALUE = _cal.VALUE;
                            dr22.STATUS = "E";
                            dr22.CAL_LOG = calLog;
                            dr22.gotoTable().Update_Empty2Null(dr22);
                            continue;
                        }
                        calLog += "【計算結果】" + result.ToString();
                        Console.WriteLine("【計算結果】" + result.ToString());
                        var dr2 = _cal.Link_Cal_By_Uuid().First();
                        _cal.VALUE = result;
                        _cal.CAL_LOG = calLog;
                        _cal.STATUS = "Y";

                        dr2.VALUE = _cal.VALUE;
                        dr2.STATUS = "Y";
                        dr2.CAL_LOG = calLog;
                        dr2.gotoTable().Update_Empty2Null(dr2);

                    }
                    else
                    {



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

                        foreach (var org in drsAllFrame)
                        {
                            System.Collections.Hashtable htCheckRaw = new System.Collections.Hashtable();
                            int numCheckRaw = 0;
                            foreach (var r in needRawUuid)
                            {
                                formula = formula.Replace("R!" + r, "[R" + r + "]");
                                //if (org.UUID == "14100622484301136" && r == "1007")
                                //{
                                //    string debug = "aaa";
                                //}
                                if (ignorFrame.Contains(org.UUID) == false)
                                {
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
                                foreach (string i in l)
                                {
                                    if (i != org.UUID)
                                    {
                                        if (ignorFrame.Contains(i) == false)
                                        {
                                            ignorFrame.Add(i);
                                        }
                                    }
                                }
                                calFrame.Add(org.FULL_FRAME_UUID_LIST);
                            }
                            else
                            {
                                /*沒有找到計算的組織*/
                            }
                        }

                        if (calFrame.Count > 0)
                        {
                            /*可以計算的啟頭點*/
                            calLog += System.Environment.NewLine + "【計算】組織:" + _cal.FULL_FRAME_NAME_LIST + System.Environment.NewLine;
                            calLog += "   KPI ID:" + _cal.KPI_ID + System.Environment.NewLine;
                            calLog += "   KPI 說明:" + _cal.C_DESC + System.Environment.NewLine;
                            calLog += "【公式】" + getFormula(_cal.FORMULA) + System.Environment.NewLine;
                            calLog += "【公式 for 程式】" + _cal.FORMULA + System.Environment.NewLine;

                            bool onlyKPI = false;

                            if (_cal.FORMULA.IndexOf("R!") == -1 && _cal.FORMULA.IndexOf("K!") >= 0)
                            {
                                calLog += "【計算偵測】執行同層指標計算" + System.Environment.NewLine;
                                onlyKPI = true;
                            }



                            calLog += "【符合資料的下轄組織】" + System.Environment.NewLine;

                            //if (_cal.FULL_FRAME_NAME_LIST == "14081800014800015:14081900103900017:14100621385500509:" && _cal.KPI_ID == "14102819485800119")
                            //{
                            //    var debug = true;
                            //}
                            foreach (var _frame in calFrame)
                            {
                                var _drFrame = mod.getFrameHead_By_Uuid(_frame.Split(':')[_frame.Split(':').Length - 2]).AllRecord().First();
                                calLog += System.Environment.NewLine + _drFrame.C_NAME + System.Environment.NewLine;
                            }

                            calLog += "【計算元素】" + System.Environment.NewLine;


                            if (calFrame.Count == 1)
                            {
                                #region 只有一個組織符合資料時的計算方式
                                Expression e = new Expression(formula);
                                calLog += "【公式】" + getFormula(_cal.FORMULA) + System.Environment.NewLine;
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
                                    else
                                    {
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
                                    else
                                    {
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
                                }
                                var result = new decimal();
                                try
                                {
                                    result = Convert.ToDecimal(e.Evaluate());
                                }
                                catch (Exception ex) {

                                    calLog += "ERROR:" + ex.Message;
                                    _cal.CAL_LOG = calLog;
                                    _cal.STATUS = "E";
                                    var dr22 = _cal.Link_Cal_By_Uuid().First();
                                    dr22.VALUE = _cal.VALUE;
                                    dr22.STATUS = "E";
                                    dr22.CAL_LOG = calLog;
                                    dr22.gotoTable().Update_Empty2Null(dr22);
                                    continue;
                                    //throw ex;
                                }
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
                                calLog += "【公式】" + getFormula(_cal.FORMULA) + System.Environment.NewLine;
                                calLog += "【公式 for 程式】" + _cal.FORMULA + System.Environment.NewLine;
                                if (_cal.FORMULA.IndexOf("R!") == -1 && _cal.FORMULA.IndexOf("K!") >= 0)
                                {
                                    calLog += "【計算偵測】執行同層指標計算" + System.Environment.NewLine;
                                    onlyKPI = true;
                                }
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
                                    calLog += System.Environment.NewLine + "【下轄組織符合資料】" + _drFrame.C_NAME + System.Environment.NewLine;
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
                                            calLog += "需要資料ID:" + drRawHead.RAW_ID + System.Environment.NewLine;
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
                                            var pValue = mod.getVCal_By_FrameHeadUuid_TimeId_KpiHeadUuid(k, _drFrame.UUID, _cal.TIME_ID);
                                            htPi.Add("K" + k, pValue);
                                        }
                                        else
                                        {
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
                                        else
                                        {
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
                                            calLog += "【" + _drP.UUID + "】" + _drP.NAME + ":" + entry.Value.ToString() + System.Environment.NewLine;
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

                                                if (ignorFrame2.Contains(_drFrame.UUID))
                                                {

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
                                        else
                                        {
                                            var expFrame = _drFrame.FULL_FRAME_UUID_LIST.Split(':');
                                            foreach (var _ef in expFrame)
                                            {
                                                if (_drFrame.UUID == _ef)
                                                {
                                                    continue;/*要跳過自已*/
                                                }
                                                if (ignorFrame2.Contains(_ef) == false)
                                                {
                                                    ignorFrame2.Add(_ef);
                                                }

                                            }

                                        }

                                    }
                                    var result = new decimal();
                                    try
                                    {
                                        result = Convert.ToDecimal(e.Evaluate());
                                    }
                                    catch (Exception ex) {
                                        calLog += "ERROR:" + ex.Message;
                                        _cal.CAL_LOG = calLog;
                                        _cal.STATUS = "E";
                                        var dr22 = _cal.Link_Cal_By_Uuid().First();
                                        dr22.VALUE = _cal.VALUE;
                                        dr22.STATUS = "E";
                                        dr22.CAL_LOG = calLog;
                                        dr22.gotoTable().Update_Empty2Null(dr22);
                                        continue;
                                    }
                                    calLog += "【計算結果】" + result.ToString() + System.Environment.NewLine;

                                    if (onlyKPI == false)
                                    {
                                        totalValue += result;
                                        calLog += System.Environment.NewLine;
                                    }
                                    else
                                    {
                                        totalValue = result;
                                        calLog += System.Environment.NewLine;
                                        break;
                                    }
                                    


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
                                else
                                {
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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
                //throw ex;
            }

        }

        public string getFormula(string algorith)
        {
            try
            {
                CrModel mod = new CrModel();
                var drs = mod.getKpiFormula_By_Algorithm(algorith);
                if (drs.Count == 0)
                {
                    return "【注意】公式內容於目前指票的公式不符合";
                }
                else
                {
                    return drs.First().ALGORITHM_MAN;
                }
            }
            catch (Exception ex)
            {
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
                    if (drs.First().VALUE == null)
                    {
                        return ret;
                    }
                    else
                    {

                        ret = drs.First().VALUE.Value;
                    }
                }
                else
                {
                    ret = null;
                }
                return ret;
            }
            catch (Exception ex)
            {
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
    }
}
