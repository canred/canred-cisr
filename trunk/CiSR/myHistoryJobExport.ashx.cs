using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPOI;
using NPOI.POIFS;
using NPOI.Util;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using System.IO;
using CISR;
using CISR.Model.Cr.Table;
using CISR.Model.Cr;
using CISR.Model.Cr.Table.Record;
using NPOI;
using NPOI.SS;
using System.Collections;


namespace CISR
{
    /// <summary>
    /// Summary description for myJobExport
    /// </summary>
    public class myHistoryJobExport : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            BasePage basepage = new BasePage();
            context.Response.ContentType = "text/plain";            
            string timeType = context.Request.QueryString["timeType"];
            string attendantUuid = basepage.getUser().UUID;

            string url = genExcel(timeType, attendantUuid);


            context.Response.Write(url);
            
        }

        public string genExcel(string pTimeType,string pAttendantUuid) {
            string dldir = AppDomain.CurrentDomain.BaseDirectory + "Download\\excel\\";
            string uldir = AppDomain.CurrentDomain.BaseDirectory + "Upload\\default_export_file\\";
            string filename = DateTime.Now.ToString("yyyy-M-d") + "_" + IST.Util.UID.Instance.GetUniqueID()+".xls";

            MemoryStream ms = new MemoryStream();    //创建内存流用于写入文件       
            var workbook = new HSSFWorkbook();   //创建Excel工作部   
            System.Collections.Hashtable htSetting = new System.Collections.Hashtable();
            //var sheetHidden = workbook.CreateSheet("Setting");
            
            CrModel mod = new CrModel();
          
            try {               
                var orderLimit = ExtDirect.Direct.Helper.Order.getOrderLimit("1", "99999", "RAW_ID", "ASC");
                var data = mod.getMyUploadJobHistory_TimeType_TimeId_AttendnatnUuid_Keyword_FrameHeadUuid(pTimeType, "", pAttendantUuid, "", "", orderLimit);
                
                var g = from item in data
                        group item by new {item.FULL_FRAME_NAME_LIST,item.FRAME_HEAD_UUID} 
                        into grp
                                           select new
                                           {
                                               grp.Key.FULL_FRAME_NAME_LIST,
                                               grp.Key.FRAME_HEAD_UUID
                                           };

                foreach (var item in g)
                {
                    
                    string _fName = item.FULL_FRAME_NAME_LIST.ToString().Split(':')[item.FULL_FRAME_NAME_LIST.ToString().Split(':').Length - 2];
                    
                    var sheetSub = workbook.CreateSheet(_fName);                   
                    if(htSetting.ContainsKey(item.FULL_FRAME_NAME_LIST)==false){
                        htSetting.Add(item.FULL_FRAME_NAME_LIST, item.FRAME_HEAD_UUID);
                    }                    
                    Int32 r = 1;
                    var row1 = sheetSub.CreateRow(sheetSub.LastRowNum);//在工作表中添加一行
                    var style1 = workbook.CreateCellStyle();
                    style1.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Yellow.Index2;
                    style1.FillPattern = NPOI.SS.UserModel.FillPattern.SolidForeground;

                    var styleDisabled = workbook.CreateCellStyle();
                    styleDisabled.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Black.Index;
                    styleDisabled.FillPattern = NPOI.SS.UserModel.FillPattern.SolidForeground;
                    

                    var cell1_1 = row1.CreateCell(0);//创建单元格
                    cell1_1.SetCellValue("指標編號");//赋值
                    cell1_1.CellStyle = style1;

                    var cell1_2 = row1.CreateCell(1);//创建单元格
                    cell1_2.SetCellValue("GRI指標");//赋值
                    cell1_2.CellStyle = style1;

                    var cell1_3 = row1.CreateCell(2);//创建单元格
                    cell1_3.SetCellValue("單位");//赋值
                    cell1_3.CellStyle = style1;

                    var dataAllRawId = (from pTime in data
                                       group pTime by new { pTime.RAW_ID }
                                           into grp
                                           select new
                                           {
                                               grp.Key.RAW_ID
                                           }).ToList().OrderBy(c => c.RAW_ID).ToList();
                    System.Collections.Hashtable htRawId = new System.Collections.Hashtable();
                    foreach (var dItem in data)
                    {
                        if (dItem.FULL_FRAME_NAME_LIST == item.FULL_FRAME_NAME_LIST)
                        {
                            /*建立Sheet*/
                            var row = sheetSub.CreateRow(r);//在工作表中添加一行                            
                            var cell = row.CreateCell(0);//创建单元格
                            if (htRawId.ContainsKey(dItem.RAW_ID) == false)
                            {
                                htRawId.Add(dItem.RAW_ID, dItem.RAW_ID);
                            }
                            else
                            {
                                continue;
                            }

                            cell.SetCellValue(dItem.RAW_ID);//赋值
                            var cell2 = row.CreateCell(1);//创建单元格
                            cell2.SetCellValue(dItem.RAW_C_DESC);//赋值
                            var cell3 = row.CreateCell(2);//创建单元格
                            cell3.SetCellValue(dItem.RAW_UNIT);//赋值

                            var dataAllTime = (from pTime in data
                                               group pTime by new { pTime.FULL_FRAME_NAME_LIST, pTime.TIME_ID }
                                                   into grp
                                                   select new
                                                   {
                                                       grp.Key.TIME_ID
                                                   }).ToList().OrderBy(c => c.TIME_ID).ToList();


                            if (pTimeType == "month")
                            {
                                #region 月的資料
                                var c = 3;
                                foreach (var time in dataAllTime)
                                {
                                    /*1~12 maybe*/
                                    var vs = from _v in data
                                             where _v.FULL_FRAME_NAME_LIST.Equals(item.FULL_FRAME_NAME_LIST) && _v.TIME_ID.Equals(time.TIME_ID)
                                             select new
                                             {
                                                 _v.VALUE,
                                                 _v.EXPLAIN
                                             };
                                    var v = vs.First();
                                    sheetSub.CreateRow(r).CreateCell(c).SetCellValue(time.TIME_ID);
                                    if (v.VALUE != null)
                                        sheetSub.CreateRow(r + 1).CreateCell(c).SetCellValue(v.VALUE.ToString());
                                    c++;
                                }
                                #endregion

                            }
                            else if(pTimeType=="year")
                            {
                                #region 年的資料
                                var c = 3;
                                foreach (var time in dataAllTime)
                                {
                                    /*1~12 maybe*/
                                    var vs = from _v in data
                                             where _v.FULL_FRAME_NAME_LIST.Equals(item.FULL_FRAME_NAME_LIST) && _v.TIME_ID.Equals(time.TIME_ID) && _v.RAW_ID.Equals(dItem.RAW_ID)
                                             select new
                                             {
                                                 _v.RAW_ID,
                                                 _v.VALUE,
                                                 _v.EXPLAIN
                                             };
                                    if (vs.Count() == 1)
                                    {
                                        var v = vs.First();
                                        //sheetSub.CreateRow(0).CreateCell(c).SetCellValue(time.TIME_ID);
                                        var cellTime = row1.CreateCell(c);//创建单元格
                                        cellTime.SetCellValue(time.TIME_ID);//赋值
                                        cellTime.CellStyle = style1;

                                        if (v.VALUE != null)
                                        {

                                            var nowCell = row.CreateCell(c);
                                            nowCell.SetCellValue(Convert.ToDouble(v.VALUE));
                                            //sheetSub.CreateRow(r).CreateCell(c).SetCellValue(v.VALUE.ToString());
                                        }
                                    }
                                    else {

                                        var nowCell = row.CreateCell(c);
                                        nowCell.CellStyle = styleDisabled;
                                        nowCell.SetCellValue("x");
                                        c++;
                                        
                                        continue;
                                    }                                   
                                        
                                    c++;
                                }

                                #endregion
                            }
                        }
                        r++;
                    }
                    sheetSub.AutoSizeColumn(0);
                    sheetSub.AutoSizeColumn(1);
                    sheetSub.AutoSizeColumn(2);
                    sheetSub.AutoSizeColumn(3);
                    sheetSub.AutoSizeColumn(4);
                    sheetSub.AutoSizeColumn(5);
                }

                /*設定 一個 Setting 的Sheet*/
                var sheetSetting = workbook.CreateSheet("Setting");
                var totalSheet = 0; 
                foreach (DictionaryEntry item in htSetting) {
                    var rowSetting = sheetSetting.CreateRow(sheetSetting.LastRowNum);//在工作表中添加一行
                    rowSetting.CreateCell(0).SetCellValue(item.Key.ToString());
                    rowSetting.CreateCell(1).SetCellValue(item.Value.ToString());
                    totalSheet++;
                }
                /*將這一個sheet設為hidden*/
                workbook.SetSheetHidden(totalSheet, true);

                workbook.Write(ms);//将Excel写入流
                ms.Flush();
                ms.Position = 0;

                FileStream dumpFile = new FileStream(Path.Combine(dldir, filename), FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                ms.WriteTo(dumpFile);//将流写入文件
                dumpFile.Dispose();
                ms.Dispose();

                return  "~\\Download\\excel\\"+filename;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
               
            }
            //System.IO.File.Create(Path.Combine(dldir, filename));
            

            

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