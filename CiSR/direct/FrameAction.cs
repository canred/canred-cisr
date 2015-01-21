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
#endregion
[DirectService("FrameAction")]
public class FrameAction : BaseAction
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="parentUuid"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [DirectMethod("loadFrameTree", DirectAction.TreeStore, MethodVisibility.Visible)]
    //public JObject loadMenuTree(string parentUuid, Request request)
    public JObject loadFrameTree(string parentUuid, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        BasicModel model = new BasicModel();
        CISR.Model.Cr.Table.FrameHead tblFrameHead = new CISR.Model.Cr.Table.FrameHead();
        #endregion
        try
        {
            /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            /*取得資料*/
            var genTable = new CISR.Model.Cr.Table.FrameHead();
            var dataTable = model.getFrameHead_By_RootUuid_DataTable(parentUuid);
            dataTable.Columns.Add("leaf", System.Type.GetType("System.Boolean"));
            //dataTable.Columns.Add("id");
            dataTable.Columns.Add("name");

            dataTable.Columns.Add("expanded", System.Type.GetType("System.Boolean"));
            //dataTable.Columns.Add("checked", typeof(Boolean));
            foreach (DataRow dr in dataTable.Rows)
            {

                var children = model.getFrameHead_By_RootUuid_DataTable(dr[tblFrameHead.UUID].ToString());
                if (children.Rows.Count == 0)
                {
                    dr["leaf"] = true;
                }
                else
                {
                    dr["leaf"] = false;
                }
                dr["name"] = dr[tblFrameHead.C_NAME].ToString();
                dr["expanded"] = true;
            }
           
            //jsonStr.Append(JsonHelper.DataTableSerializer(dataTable));
            var jarray = JsonHelper.DataTableSerializerJArray(dataTable);

            foreach (var item in jarray) {
                var thisUuid = item["UUID"].ToString();
                var thisLeaf = item["leaf"].ToString();
                if (thisLeaf.ToLower() == "false") {
                    item["children"] = _loadFrameTree(thisUuid,false);
                }
            }
            /*使用Store Std out 『Sotre物件標準輸出格式』*/
            return ExtDirect.Direct.Helper.Tree.Output(jarray, 9999);
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            /*將Exception轉成EXT Exception JSON格式*/
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }    
    public JArray _loadFrameTree(string parentUuid,bool isSecond)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        BasicModel model = new BasicModel();
        CISR.Model.Cr.Table.FrameHead tblFrameHead = new CISR.Model.Cr.Table.FrameHead();
        #endregion
        try
        {           
            /*取得資料*/
            var genTable = new CISR.Model.Cr.Table.FrameHead();
            var dataTable = model.getFrameHead_By_RootUuid_DataTable(parentUuid);
            dataTable.Columns.Add("leaf", System.Type.GetType("System.Boolean"));      
            dataTable.Columns.Add("name");
            dataTable.Columns.Add("expanded", System.Type.GetType("System.Boolean"));
            foreach (DataRow dr in dataTable.Rows)
            {
                var children = model.getFrameHead_By_RootUuid_DataTable(dr[tblFrameHead.UUID].ToString());
                if (children.Rows.Count == 0)
                {
                    dr["leaf"] = true;
                }
                else
                {
                    dr["leaf"] = false;
                }
                dr["name"] = dr[tblFrameHead.C_NAME].ToString();
                if (isSecond == true)
                {
                    dr["expanded"] = true;
                }
                else {
                    dr["expanded"] = false;
                }
                
            }            
            var jarray = JsonHelper.DataTableSerializerJArray(dataTable);
            foreach (var item in jarray)
            {
                var thisUuid = item["UUID"].ToString();
                var thisLeaf = item["leaf"].ToString();
                if (thisLeaf.ToLower() == "false")
                {
                    item["children"] = _loadFrameTree(thisUuid,false);
                }
            }
            return jarray;
            /*使用Store Std out 『Sotre物件標準輸出格式』*/
            //return ExtDirect.Direct.Helper.Tree.Output(jarray, 9999);
        }
        catch (Exception ex)
        {
            log.Error(ex); 
            IST.MyException.MyException.Error(this, ex);
            throw ex;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parentUuid"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [DirectMethod("loadTreeRoot", DirectAction.Store, MethodVisibility.Visible)]
    //public JObject loadTreeRoot(string pApplicationHeadUuid, Request request)
   public JObject loadTreeRoot(string pCompanyUuid, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        BasicModel model = new BasicModel();
        FrameHead table = new FrameHead();
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
            var data = model.getFrameHead_By_CompanyUuid(pCompanyUuid, null);
            if (data.Count == 0) {
                var drCompany = model.getCompany_By_Uuid(pCompanyUuid);
                if(drCompany.AllRecord().Count>0){
                    /*Create new root for FRAME_HEAD*/
                    FrameHead_Record newF = new FrameHead_Record();
                    newF.UUID = IST.Util.UID.Instance.GetUniqueID();
                    newF.C_NAME = drCompany.AllRecord().First().C_NAME;
                    newF.E_NAME = drCompany.AllRecord().First().E_NAME;
                    newF.COMPANY_UUID = drCompany.AllRecord().First().UUID;
                    newF.CREATE_DATE = DateTime.Now;
                    newF.DLEVEL = 1;
                    newF.FRAME_ID = drCompany.AllRecord().First().ID;
                    newF.FULL_FRAME_ID_LIST = drCompany.AllRecord().First().ID;
                    newF.FULL_FRAME_NAME_LIST = newF.C_NAME;
                    newF.FULL_FRAME_UUID_LIST = newF.UUID;
                    newF.IS_ACTIVE = "Y";
                    newF.KPI_PACKAGE_UUID = null;
                    newF.ORD = 1;
                    newF.PARENT_FRAME_HEAD_UUID = null;
                    newF.REGION_UUID = null;
                    newF.UPDATE_DATE = DateTime.Now;
                    newF.ZH_NAME = drCompany.NAME_ZH_CN;
                    newF.gotoTable().Insert_Empty2Null(newF);
                    data = model.getFrameHead_By_CompanyUuid(pCompanyUuid, null);
                }
            }
            foreach (var dr in data)
            {
                if (dr.PARENT_FRAME_HEAD_UUID.Trim() == "")
                {
                    return JsonHelper.RecordBaseJObject(dr);
                }
            }
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(new Exception("Data Not Found!"));
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }


    [DirectMethod("submitFrameCategory", DirectAction.FormSubmission, MethodVisibility.Visible)]
    public JObject submitFrameCategory(string uuid,string frame_category_name,HttpRequest request)
    {
        #region Declare
        var action = SubmitAction.None;
        CrModel mod = new CrModel();
        FrameCategory_Record drFrameCategory = new FrameCategory_Record();
        string errorMsg = "update frame head record fail.";
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

                drFrameCategory = mod.getFrameCategory_By_Uuid(uuid).AllRecord().First();                
                action = SubmitAction.Edit;
            }
            else
            {
                action = SubmitAction.Create;                
                drFrameCategory.UUID = IST.Util.UID.Instance.GetUniqueID();
            }
            /*固定要更新的欄位*/
            drFrameCategory.FRAME_CATEGORY_NAME = frame_category_name;

            if (action == SubmitAction.Edit)
            {
                drFrameCategory.gotoTable().Update_Empty2Null(drFrameCategory);
            }
            else if (action == SubmitAction.Create)
            {
                drFrameCategory.gotoTable().Insert_Empty2Null(drFrameCategory);
            }

            System.Collections.Hashtable ht = new System.Collections.Hashtable();

            ht.Add("uuid", drFrameCategory.UUID);
            
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(ht);
            
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("submitFrameHead", DirectAction.FormSubmission, MethodVisibility.Visible)]
    public JObject submitFrameHead(string company_uuid,
string create_date,
string c_name,
string dlevel,
string e_name,
string frame_id,
string full_frame_id_list,
string full_frame_name_list,
string full_frame_uuid_list,
string is_active,
string kpi_package_uuid,
string ord,
string parent_frame_head_uuid,
string region_uuid,
string update_date,
string uuid,
string zh_name,
string currency,
        string frame_category_uuid,

                            HttpRequest request)
    {
        #region Declare
        var action = SubmitAction.None;
        CrModel mod = new CrModel();
        FrameHead_Record drFrameHead = new FrameHead_Record();
        string errorMsg = "update frame head record fail.";
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

                drFrameHead = mod.getFrameHead_By_Uuid(uuid).AllRecord().First();
                //判斷有沒有子項，有的話不可修改
                /*
                var canBeChange = getChildByMenuUuid(uuid, drAppMenu.APPMENU_UUID);
                if (!canBeChange)
                {
                    errorMsg = "尚有子項，無法異動節點";
                }
                else
                 */
                action = SubmitAction.Edit;
                drFrameHead.ORD = Convert.ToInt16(ord);
            }
            else
            {
                action = SubmitAction.Create;
                drFrameHead.UUID = IST.Util.UID.Instance.GetUniqueID();
                drFrameHead.CREATE_DATE = DateTime.Now;
                //drFrameHead.CREATE_USER = getUser().UUID;
                //drFrameHead.UPDATE_USER = getUser().UUID;
                drFrameHead.CREATE_DATE = DateTime.Now;
                drFrameHead.PARENT_FRAME_HEAD_UUID = parent_frame_head_uuid;
                drFrameHead.ORD = mod.getFrameHead_MaxOrd(parent_frame_head_uuid) + 1;
                //新增一定沒有子項
                drFrameHead.HASCHILD = "N";
            }
            /*固定要更新的欄位*/
            drFrameHead.UPDATE_DATE = DateTime.Now;
            drFrameHead.COMPANY_UUID = company_uuid;

            /*非固定更新的欄位*/
            drFrameHead.IS_ACTIVE = is_active;
            drFrameHead.C_NAME = c_name;
            //drFrameHead.DLEVEL = Convert.ToInt16(dlevel);
            drFrameHead.E_NAME = e_name;
            drFrameHead.FRAME_ID = frame_id;
            //drFrameHead.FULL_FRAME_ID_LIST = full;
            //drFrameHead.FULL_FRAME_NAME_LIST = parameter_class;
            //drFrameHead.FULL_FRAME_UUID_LIST = image;
            drFrameHead.IS_ACTIVE = is_active;
            drFrameHead.KPI_PACKAGE_UUID = kpi_package_uuid;
            drFrameHead.PARENT_FRAME_HEAD_UUID = parent_frame_head_uuid;
            drFrameHead.REGION_UUID = region_uuid;
            drFrameHead.ZH_NAME = zh_name;
            drFrameHead.CURRENCY = currency;
            drFrameHead.FRAME_CATEGORY_UUID = frame_category_uuid;
            //drFrameHead.ORD = System.Convert.ToInt32(ord);

            if (action == SubmitAction.Edit)
            {
                drFrameHead.gotoTable().Update_Empty2Null(drFrameHead);
            }
            else if (action == SubmitAction.Create)
            {
                drFrameHead.gotoTable().Insert_Empty2Null(drFrameHead);
            }

            if (action == SubmitAction.Edit || action == SubmitAction.Create)
            {
                //更新父項的HASCHIIST = "Y"
                updateParentFrameHead(parent_frame_head_uuid, "Y");
                System.Collections.Hashtable otherParam = new System.Collections.Hashtable();
                otherParam.Add("UUID", drFrameHead.UUID);
                adjustFrameHead(drFrameHead.UUID);
                return ExtDirect.Direct.Helper.Message.Success.OutputJObject(otherParam);
            }
            else
                return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(new Exception(errorMsg));
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    private void adjustFrameHead(string uuid) {
        CrModel mod = new CrModel();
        var cur = mod.getFrameHead_By_Uuid(uuid).AllRecord().First();
        int dlevel = 1;
        string fullFrameNameList = "";
        string fullFrameIdList = "";
        string fullFrameUuidList = "";

        var root = mod.getFrameHead_Root(cur.COMPANY_UUID);
        //var parent = new FrameHead_Record();
        do{
            dlevel++;
            fullFrameIdList = cur.FRAME_ID + ":" + fullFrameIdList;
            fullFrameNameList = cur.C_NAME + ":" + fullFrameNameList;
            fullFrameUuidList = cur.UUID + ":" + fullFrameUuidList;
            cur = mod.getFrameHead_By_Uuid(cur.PARENT_FRAME_HEAD_UUID).AllRecord().First();
        } while (cur.PARENT_FRAME_HEAD_UUID != "");

        cur = mod.getFrameHead_By_Uuid(uuid).AllRecord().First();
        cur.DLEVEL = dlevel;
        cur.FULL_FRAME_ID_LIST = root.FRAME_ID+":"+fullFrameIdList;
        cur.FULL_FRAME_NAME_LIST = root.C_NAME+":"+fullFrameNameList;
        cur.FULL_FRAME_UUID_LIST = root.UUID+":"+fullFrameUuidList;
        cur.gotoTable().Update_Empty2Null(cur);
    }

    #region  updateParentFrameHead
    private bool updateParentFrameHead(string parent_appmenu_uuid, string haschild)
    {
        bool success = true;
        CrModel modBasic = new CrModel();
        FrameHead dtAppMenu = new FrameHead();
        FrameHead_Record drAppMenu = new FrameHead_Record();
        dtAppMenu = modBasic.getFrameHead_By_Uuid(parent_appmenu_uuid);
        if (dtAppMenu.AllRecord().Count > 0)
        {
            drAppMenu = dtAppMenu.AllRecord().First();
            drAppMenu.HASCHILD = haschild;
            drAppMenu.gotoTable().Update_Empty2Null(drAppMenu);
        }
        else
            success = false;
        return success;
    }
    #endregion

    #region getChildByMenuUuid
    private bool getChildByMenuUuid(string parent_appmenu_uuid, string appmenu_uuid)
    {
        bool canBeChange = true;
        bool hasChild = true;
        BasicModel modBasic = new BasicModel();
        var child = modBasic.getAppmenu_By_ParentUuid_DataTable(parent_appmenu_uuid);
        var self = modBasic.getAppmenu_By_Uuid(appmenu_uuid).AllRecord().First();
        if (child.Count == 0)
            hasChild = false;

        if (self.APPMENU_UUID != appmenu_uuid && hasChild)
            canBeChange = false;

        return canBeChange;
    }
    #endregion


[DirectMethod("infoFrameCategory", DirectAction.Store, MethodVisibility.Visible)]
    public JObject infoFrameCategory(string pUuid, Request request)
    {
        #region Declare
        CrModel mod = new CrModel();
        #endregion
        try
        {
            /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            var dtFrameCategory = mod.getFrameCategory_By_Uuid(pUuid);
            if (dtFrameCategory.AllRecord().Count > 0)
            {
                var drFrameCategory = dtFrameCategory.AllRecord().First();
                return ExtDirect.Direct.Helper.Form.OutputJObject(JsonHelper.RecordBaseJObject(drFrameCategory));
            }
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(new Exception("Data Not Found!"));
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pUuid"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [DirectMethod("infoFrameHead", DirectAction.Store, MethodVisibility.Visible)]
    public JObject infoFrameHead(string pUuid, Request request)
    {
        #region Declare
        CrModel mod = new CrModel();
        #endregion
        try
        {
            /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            var dtFrameHead = mod.getFrameHead_By_Uuid(pUuid);
            if (dtFrameHead.AllRecord().Count > 0)
            {

                var drFramHead = dtFrameHead.AllRecord().First();
                var allFrame = drFramHead.FULL_FRAME_UUID_LIST.Split(':');
                for (var i = allFrame.Length - 1; i >= 0; i--)
                {
                    if (allFrame[i].Trim().Length == 0)
                    {
                        continue;
                    }
                    else {
                        var tmp = mod.getFrameHead_By_Uuid(allFrame[i]).AllRecord().First();
                        if (tmp.KPI_PACKAGE_UUID.Trim().Length == 0)
                        {
                            continue;
                        }
                        else
                        {
                            drFramHead.KPI_PACKAGE_UUID = tmp.KPI_PACKAGE_UUID;
                            drFramHead.gotoTable().Update_Empty2Null(drFramHead);
                            break;
                        }
                    }

                }

                allFrame = drFramHead.FULL_FRAME_UUID_LIST.Split(':');
                for (var i = allFrame.Length - 1; i >= 0; i--)
                {
                    if (allFrame[i].Trim().Length == 0)
                    {
                        continue;
                    }
                    else
                    {
                        var tmp = mod.getFrameHead_By_Uuid(allFrame[i]).AllRecord().First();
                        if (tmp.CURRENCY.Trim().Length == 0)
                        {
                            continue;
                        }
                        else
                        {
                            drFramHead.CURRENCY = tmp.CURRENCY;
                            drFramHead.gotoTable().Update_Empty2Null(drFramHead);
                            break;
                        }
                    }

                }

                allFrame = drFramHead.FULL_FRAME_UUID_LIST.Split(':');
                for (var i = allFrame.Length - 1; i >= 0; i--)
                {
                    if (allFrame[i].Trim().Length == 0)
                    {
                        continue;
                    }
                    else
                    {
                        var tmp = mod.getFrameHead_By_Uuid(allFrame[i]).AllRecord().First();
                        if (tmp.FRAME_CATEGORY_UUID.Trim().Length == 0)
                        {
                            continue;
                        }
                        else
                        {
                            drFramHead.FRAME_CATEGORY_UUID = tmp.FRAME_CATEGORY_UUID;
                            drFramHead.gotoTable().Update_Empty2Null(drFramHead);
                            break;
                        }
                    }

                }

                    /*將List<RecordBase>變成JSON字符串*/
                dtFrameHead = mod.getFrameHead_By_Uuid(pUuid);
                return ExtDirect.Direct.Helper.Form.OutputJObject(JsonHelper.RecordBaseJObject(drFramHead));
            }
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(new Exception("Data Not Found!"));
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("getFrameChildCount", DirectAction.Store, MethodVisibility.Visible)]
    public JObject getFrameChildCount(string pParentFrameHeadUuid, Request request)
    {
        #region Declare
        CrModel mod = new CrModel();
        #endregion
        try
        {
            /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            var dtFrameHead = mod.getFrameHead_By_ParentFrameHeadUuid(pParentFrameHeadUuid);

            System.Collections.Hashtable ht = new System.Collections.Hashtable();

            var count = dtFrameHead.Count();
            ht.Add("COUNT", count );
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(ht);

           
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }



   


    /// <summary>
    /// 
    /// </summary>
    /// <param name="pUuid"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [DirectMethod("deleteFrameHead", DirectAction.Store, MethodVisibility.Visible)]
    //public JObject deleteAppMenu(string pUuid, Request request)
    public JObject deleteFrameHead(string pUuid, Request request)
    {
        #region Declare
        CISR.Model.Cr.CrModel mod = new CISR.Model.Cr.CrModel();
        #endregion
        try
        {
            /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            var dtAppmenu = mod.getFrameHead_By_Uuid(pUuid);
            if (dtAppmenu.AllRecord().Count > 0)
            {
                /*將List<RecordBase>變成JSON字符串*/
                var drSitemap = dtAppmenu.AllRecord().First();
                drSitemap.gotoTable().Delete(drSitemap);
                return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
            }
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(new Exception("delete SiteMap record fail."));
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("loadFrameCategory", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadFrameCategory(string pKeyword,string pageNo, string limitNo, string sort, string dir, Request request)
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
            /*是Store操作一下就可能含有分頁資訊。*/
            orderLimit = ExtDirect.Direct.Helper.Order.getOrderLimit(pageNo, limitNo, sort, dir);
            /*取得總資料數*/
            //var totalCount = modBasic.getFrameHead_By_CompanyUuid_Count(pCompanyUuid);
            /*取得資料*/
            var data = mod.getFrameCategory(pKeyword, orderLimit);
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


//[DirectMethod("loadFrameCategory", DirectAction.Store, MethodVisibility.Visible)]
//    public JObject loadFrameCategory(string pageNo, string limitNo, string sort, string dir, Request request)
//    {
//        #region Declare
//        List<JObject> jobject = new List<JObject>();
//        CrModel mod = new CrModel();
//        OrderLimit orderLimit = null;
//        Appmenu tblAppmenu = new Appmenu();
//        #endregion
//        try
//        {  /*Cloud身份檢查*/
//            checkUser(request.HttpRequest);
//            if (this.getUser() == null)
//            {
//                throw new Exception("Identity authentication failed.");
//            }/*權限檢查*/
//            if (!checkProxy(new StackTrace().GetFrame(0)))
//            {
//                throw new Exception("Permission Denied!");
//            };
//            /*是Store操作一下就可能含有分頁資訊。*/
//            orderLimit = ExtDirect.Direct.Helper.Order.getOrderLimit(pageNo, limitNo, sort, dir);
//            /*取得總資料數*/
//            //var totalCount = modBasic.getFrameHead_By_CompanyUuid_Count(pCompanyUuid);
//            /*取得資料*/
//            var data = mod.getFrameCategory(orderLimit);
//            var totalCount = data.Count;
//            if (data.Count > 0)
//            {
//                /*將List<RecordBase>變成JSON字符串*/
//                jobject = JsonHelper.RecordBaseListJObject(data);
//            }
//            /*使用Store Std out 『Sotre物件標準輸出格式』*/
//            return ExtDirect.Direct.Helper.Store.OutputJObject(jobject, totalCount);
//        }
//        catch (Exception ex)
//        {
//            log.Error(ex); IST.MyException.MyException.Error(this, ex);
//            /*將Exception轉成EXT Exception JSON格式*/
//            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
//        }
//    }


[DirectMethod("loadFrameCategoryAddAll", DirectAction.Store, MethodVisibility.Visible)]
public JObject loadFrameCategoryAddAll(string pageNo, string limitNo, string sort, string dir, Request request)
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
        /*是Store操作一下就可能含有分頁資訊。*/
        orderLimit = ExtDirect.Direct.Helper.Order.getOrderLimit(pageNo, limitNo, sort, dir);
        /*取得總資料數*/
        //var totalCount = modBasic.getFrameHead_By_CompanyUuid_Count(pCompanyUuid);
        /*取得資料*/
        var data = mod.getFrameCategory(orderLimit);
        var totalCount = data.Count;
        if (data.Count > 0)
        {
            var all = new FrameCategory_Record();
            all.UUID="";
            all.FRAME_CATEGORY_NAME="全部";
            
            data.Insert(0, all);
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



[DirectMethod("loadFrameCategory2AddAll", DirectAction.Store, MethodVisibility.Visible)]
public JObject loadFrameCategory2AddAll(string pFrameHeadUuid,string pageNo, string limitNo, string sort, string dir, Request request)
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
        /*是Store操作一下就可能含有分頁資訊。*/
        orderLimit = ExtDirect.Direct.Helper.Order.getOrderLimit(pageNo, limitNo, sort, dir);
        /*取得總資料數*/
        //var totalCount = modBasic.getFrameHead_By_CompanyUuid_Count(pCompanyUuid);
        /*取得資料*/
        var fdata = mod.getVFrameHead_by_PrrentFrameHeadUuid(pFrameHeadUuid, new OrderLimit());
        //f//orm a in fdata

        var dis = from a in fdata
                  group a by a.FRAME_CATEGORY_UUID into groupA
                  select new {
                      FRAME_CATEGORY_UUID=groupA.Key
                  }
                  ;

        List<object> lsUuid = new List<object>();
        foreach (var uuid in dis)
        {
            if(uuid.FRAME_CATEGORY_UUID.ToString().Trim().Length>0){
                lsUuid.Add(uuid.FRAME_CATEGORY_UUID.ToString().Trim());
            }            
        }

        var data = mod.getFrameCategory_InUuid(lsUuid,new OrderLimit());
        var totalCount = data.Count;
        if (data.Count > 0)
        {
            var all = new FrameCategory_Record();
            all.UUID = "";
            all.FRAME_CATEGORY_NAME = "全部";
            data.Insert(0, all);
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


    [DirectMethod("loadFrameHead", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadFrameHead(string pCompanyUuid, string pageNo, string limitNo, string sort, string dir, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        BasicModel modBasic = new BasicModel();
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
            /*是Store操作一下就可能含有分頁資訊。*/
            orderLimit = ExtDirect.Direct.Helper.Order.getOrderLimit(pageNo, limitNo, sort, dir);
            /*取得總資料數*/
            var totalCount = modBasic.getFrameHead_By_CompanyUuid_Count(pCompanyUuid);
            /*取得資料*/
            var data = modBasic.getFrameHead_By_CompanyUuid(pCompanyUuid, orderLimit);
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

    [DirectMethod("addKPIPackageInFrame", DirectAction.Load, MethodVisibility.Visible)]
    public JObject addKPIPackageInFrame(string pFrameHeadUuid, Request request)
    {
        #region Declare
        //List<JObject> jobject = new List<JObject>();
        CrModel mod = new  CrModel();
        //OrderLimit orderLimit = null;
        //Appmenu tblAppmenu = new Appmenu();
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
            //orderLimiloadFrameTreet = ExtDirect.Direct.Helper.Order.getOrderLimit(pageNo, limitNo, sort, dir);
            /*取得總資料數*/
            var dr = mod.getFrameHead_By_Uuid(pFrameHeadUuid).AllRecord().First();
            KpiPackage_Record kpipackage = new KpiPackage_Record();
            kpipackage.UUID = IST.Util.UID.Instance.GetUniqueID();
            kpipackage.COMPANY_UUID = dr.COMPANY_UUID;
            kpipackage.NAME = DateTime.Now.ToString();
            kpipackage.gotoTable().Insert_Empty2Null(kpipackage);
            dr.KPI_PACKAGE_UUID = kpipackage.UUID;
            dr.gotoTable().Update_Empty2Null(dr);
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            ht.Add("KpiPackageUuid", kpipackage.UUID);
            ht.Add("kpiPackageName", kpipackage.NAME);
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(ht);
            //return ExtDirect.Direct.Helper.Form.OutputJObject();//.Store.OutputJObject(jobject, totalCount);
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            /*將Exception轉成EXT Exception JSON格式*/
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }



    [DirectMethod("infoKpiPackage", DirectAction.Store, MethodVisibility.Visible)]
    public JObject infoKpiPackage(string pUuid, Request request)
    {
        #region Declare
        CrModel mod = new CrModel();
        #endregion
        try
        {
            /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            var dtKpiPackage = mod.getKpiPackage_By_Uuid(pUuid);
            if (dtKpiPackage.AllRecord().Count > 0)
            {
                /*將List<RecordBase>變成JSON字符串*/
                return ExtDirect.Direct.Helper.Form.OutputJObject(JsonHelper.RecordBaseJObject(dtKpiPackage.AllRecord().First()));
            }
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(new Exception("Data Not Found!"));
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("submitKpiPackage", DirectAction.FormSubmission, MethodVisibility.Visible)]
    public JObject submitKpiPackage(string uuid,
string company_uuid,
string name,
string scope_month_id,
                            HttpRequest request)
    {
        #region Declare
        var action = SubmitAction.None;
        CrModel mod = new CrModel();
        KpiPackage_Record drKpiPackage = new KpiPackage_Record();
        string errorMsg = "update frame head record fail.";
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
                drKpiPackage = mod.getKpiPackage_By_Uuid(uuid).AllRecord().First();               
                action = SubmitAction.Edit;
            }
            else
            {
                action = SubmitAction.Create;
                drKpiPackage.UUID = IST.Util.UID.Instance.GetUniqueID();
              
            }            

            /*非固定更新的欄位*/
            drKpiPackage.COMPANY_UUID = company_uuid;
            drKpiPackage.NAME = name;
            drKpiPackage.SCOPE_MONTH_ID = scope_month_id;          

            if (action == SubmitAction.Edit)
            {
                drKpiPackage.gotoTable().Update_Empty2Null(drKpiPackage);
            }
            else if (action == SubmitAction.Create)
            {
                drKpiPackage.gotoTable().Insert_Empty2Null(drKpiPackage);
            }
            System.Collections.Hashtable ht = new System.Collections.Hashtable();

            if (action == SubmitAction.Edit || action == SubmitAction.Create)
            {
                ht.Add("UUID", drKpiPackage.UUID);
                return ExtDirect.Direct.Helper.Message.Success.OutputJObject(ht);
            }
            else
                return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(new Exception(errorMsg));
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("loadVFrameItem", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadVFrameItem(string pFrameHeadUuid, string keyword, string pageNo, string limitNo, string sort, string dir, Request request)
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
            var totalCount = model.getVFrameItem_by_FrameHeadUuid_Skip_Count(pFrameHeadUuid, false);
            var data = model.getVFrameItem_by_FrameHeadUuid_Skip(pFrameHeadUuid, false, orderLimit);


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


    [DirectMethod("addRawToFrame", DirectAction.Store, MethodVisibility.Visible)]
    //public JObject deleteAppMenu(string pUuid, Request request)
    public JObject addRawToFrame(string pRawHeadUuid,string pFrameHeadUuid, Request request)
    {
        #region Declare
        CISR.Model.Cr.CrModel mod = new CISR.Model.Cr.CrModel();
        FrameItem_Record nRow = new FrameItem_Record();
        #endregion
        try
        {
            /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };

            var drsRawHead = mod.getRawHead_By_Uuid(pRawHeadUuid);
            if (drsRawHead.AllRecord().Count == 0) {
                throw new Exception("此項資料收集不存在!");
            }

            var drRawHead = drsRawHead.AllRecord().First();

            if (drRawHead.COMPANY_UUID != getUser().COMPANY_UUID) {
                throw new Exception("此項資料非使用者所屬公司!");
            }


            var drFrameItem = mod.getFrameItem_By_FrameHeadUuid(pFrameHeadUuid, pRawHeadUuid);
            if (drFrameItem == null)
            {
                nRow.UUID = IST.Util.UID.Instance.GetUniqueID();
                nRow.CREATE_DATE = DateTime.Now;
                nRow.FRAME_HEAD_UUID = pFrameHeadUuid;
                nRow.IS_ACTIVE = "Y";
                nRow.ORD = null;
                nRow.PWG1_SHOW = null;
                nRow.PWG2_SHOW = null;
                nRow.PWG3_SHOW = null;
                nRow.PWG4_SHOW = null;
                nRow.PWG5_SHOW = null;
                nRow.PWG1_GID = null;
                nRow.PWG2_GID = null;
                nRow.PWG3_GID = null;
                nRow.PWG4_GID = null;
                nRow.PWG5_GID = null;
                nRow.RAW_HEAD_UUID = pRawHeadUuid;
                nRow.SKIP = "N";
                nRow.SKIP_RESULT = "";
                nRow.UPDATE_DATE = DateTime.Now;
                nRow.gotoTable().Insert_Empty2Null(nRow);
            }
            else {
                drFrameItem.IS_ACTIVE = "Y";
                drFrameItem.SKIP_RESULT = "";
                drFrameItem.SKIP = "N";
                drFrameItem.gotoTable().Update_Empty2Null(drFrameItem);
            }
            
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
            
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("addRawToFrameBatch", DirectAction.Store, MethodVisibility.Visible)]
    //public JObject deleteAppMenu(string pUuid, Request request)
    public JObject addRawToFrameBatch(string arrRawHeadUuid, string pFrameHeadUuid, Request request)
    {
        #region Declare
        CISR.Model.Cr.CrModel mod = new CISR.Model.Cr.CrModel();
        FrameItem_Record nRow = new FrameItem_Record();
        #endregion
        try
        {
            /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };

            foreach (var pRawHeadUuid in arrRawHeadUuid.Split(';')) {
                if(pRawHeadUuid=="")
                    continue;

                var drsRawHead = mod.getRawHead_By_Uuid(pRawHeadUuid);
                if (drsRawHead.AllRecord().Count == 0)
                {
                    throw new Exception("此項資料收集不存在!");
                }

                var drRawHead = drsRawHead.AllRecord().First();

                if (drRawHead.COMPANY_UUID != getUser().COMPANY_UUID)
                {
                    throw new Exception("此項資料非使用者所屬公司!");
                }


                var drFrameItem = mod.getFrameItem_By_FrameHeadUuid(pFrameHeadUuid, pRawHeadUuid);
                if (drFrameItem == null)
                {
                    nRow.UUID = IST.Util.UID.Instance.GetUniqueID();
                    nRow.CREATE_DATE = DateTime.Now;
                    nRow.FRAME_HEAD_UUID = pFrameHeadUuid;
                    nRow.IS_ACTIVE = "Y";
                    nRow.ORD = null;
                    nRow.PWG1_SHOW = null;
                    nRow.PWG2_SHOW = null;
                    nRow.PWG3_SHOW = null;
                    nRow.PWG4_SHOW = null;
                    nRow.PWG5_SHOW = null;
                    nRow.PWG1_GID = null;
                    nRow.PWG2_GID = null;
                    nRow.PWG3_GID = null;
                    nRow.PWG4_GID = null;
                    nRow.PWG5_GID = null;
                    nRow.RAW_HEAD_UUID = pRawHeadUuid;
                    nRow.SKIP = "N";
                    nRow.SKIP_RESULT = "";
                    nRow.UPDATE_DATE = DateTime.Now;
                    nRow.gotoTable().Insert_Empty2Null(nRow);
                }
                else
                {
                    drFrameItem.IS_ACTIVE = "Y";
                    drFrameItem.SKIP_RESULT = "";
                    drFrameItem.SKIP = "N";
                    drFrameItem.gotoTable().Update_Empty2Null(drFrameItem);
                }
            }
            

            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();

        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }


    [DirectMethod("removeRawFromFrame", DirectAction.Store, MethodVisibility.Visible)]
    //public JObject deleteAppMenu(string pUuid, Request request)
    public JObject removeRawFromFrame(string pRawHeadUuid, string pFrameHeadUuid, Request request)
    {
        #region Declare
        CISR.Model.Cr.CrModel mod = new CISR.Model.Cr.CrModel();
        FrameItem_Record nRow = new FrameItem_Record();
        #endregion
        try
        {
            /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };

            var drsRawHead = mod.getRawHead_By_Uuid(pRawHeadUuid);   
            var drRawHead = drsRawHead.AllRecord().First();

            if (drRawHead.COMPANY_UUID != getUser().COMPANY_UUID)
            {
                throw new Exception("此項資料非使用者所屬公司!");
            }


            var drFrameItem = mod.getFrameItem_By_FrameHeadUuid(pFrameHeadUuid, pRawHeadUuid);
            drFrameItem.gotoTable().Delete(drFrameItem);

            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();

        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }


    [DirectMethod("removeRawFromFrameBatch", DirectAction.Store, MethodVisibility.Visible)]
    //public JObject deleteAppMenu(string pUuid, Request request)
    public JObject removeRawFromFrameBatch(string arrRawHeadUuid, string pFrameHeadUuid, Request request)
    {
        #region Declare
        CISR.Model.Cr.CrModel mod = new CISR.Model.Cr.CrModel();
        FrameItem_Record nRow = new FrameItem_Record();
        #endregion
        try
        {
            /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            foreach (var pRawHeadUuid in arrRawHeadUuid.Split(';'))
            {
                if (pRawHeadUuid == "")
                    continue;

                var drsRawHead = mod.getRawHead_By_Uuid(pRawHeadUuid);
                var drRawHead = drsRawHead.AllRecord().First();

                if (drRawHead.COMPANY_UUID != getUser().COMPANY_UUID)
                {
                    throw new Exception("此項資料非使用者所屬公司!");
                }


                var drFrameItem = mod.getFrameItem_By_FrameHeadUuid(pFrameHeadUuid, pRawHeadUuid);
                drFrameItem.gotoTable().Delete(drFrameItem);
            }
            

            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();

        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }
    [DirectMethod("checkFramwPWG", DirectAction.Store, MethodVisibility.Visible)]
    //public JObject deleteAppMenu(string pUuid, Request request)
    public JObject checkFramwPWG(string pFrameItemUuid, string seq, Request request)
    {
        #region Declare
        CISR.Model.Cr.CrModel mod = new CISR.Model.Cr.CrModel();
        FrameItem_Record nRow = new FrameItem_Record();
        #endregion
        try
        {
            /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };

            var drsRawHead = mod.getFrameItem_By_Uuid(pFrameItemUuid);
            if (drsRawHead.AllRecord().Count == 0)
            {
                throw new Exception("此項資料不存在!");
            }

            var drFrameItem = drsRawHead.AllRecord().First();

            string pwgUuid = "";
            if(Convert.ToInt16(seq)==1){
                pwgUuid = drFrameItem.PWG1_GID;
            }
            else if (Convert.ToInt16(seq) == 2)
            {
                pwgUuid = drFrameItem.PWG2_GID;
            }
            else if (Convert.ToInt16(seq) == 3)
            {
                pwgUuid = drFrameItem.PWG3_GID;
            }
            else if (Convert.ToInt16(seq) == 4)
            {
                pwgUuid = drFrameItem.PWG4_GID;
            }
            else if (Convert.ToInt16(seq) == 5)
            {
                pwgUuid = drFrameItem.PWG5_GID;
            }
            else {
                throw new Exception("seq參數錯誤!");
            }

           
            var drsPwg = mod.getPwg_By_Uuid(pwgUuid);

            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            var drPwg = new Pwg_Record();
            if (drsPwg.Count == 0)
            {
                
                drPwg.GID = IST.Util.UID.Instance.GetUniqueID();
                drPwg.ATTENDANT_UUID = null;
                drPwg.gotoTable().Insert_Empty2Null(drPwg);
                ht.Add("GID", drPwg.GID);


                if (Convert.ToInt16(seq) == 1)
                {
                    drFrameItem.PWG1_GID = drPwg.GID;
                }
                else if (Convert.ToInt16(seq) == 2)
                {
                    drFrameItem.PWG2_GID = drPwg.GID;
                }
                else if (Convert.ToInt16(seq) == 3)
                {
                    drFrameItem.PWG3_GID = drPwg.GID;
                }
                else if (Convert.ToInt16(seq) == 4)
                {
                    drFrameItem.PWG4_GID = drPwg.GID;
                }
                else if (Convert.ToInt16(seq) == 5)
                {
                    drFrameItem.PWG5_GID = drPwg.GID;
                }
                else
                {
                    throw new Exception("seq參數錯誤!");
                }
                drFrameItem.gotoTable().Update_Empty2Null(drFrameItem);


            }
            else {
                ht.Add("GID", drsPwg.First().GID);
            }

  
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(ht);

        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }


    [DirectMethod("loadAttendantNotIncludePwg", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadAttendantNotIncludePwg(string pPwgUuid, string frameHeadUuid, string keyword, string pageNo, string limitNo, string sort, string dir, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        CISR.Model.Cr.CrModel model = new CISR.Model.Cr.CrModel();
        BasicModel bModel = new BasicModel();
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
            var drFrameHead = model.getFrameHead_By_Uuid(frameHeadUuid).AllRecord().First();
            var drsAttendant = bModel.getAttendant_By_CompanyUuid(drFrameHead.COMPANY_UUID, keyword, true, orderLimit);
            //var data = model.getVPwg_By_PwgUuid(pPwgUuid);


            var drsSelect = model.getVPwg_By_PwgGid(pPwgUuid).AllRecord();
            var drsUnselect = new List<Attendant_Record>();
            foreach (var item in drsAttendant)
            {
                
                var isExist = drsSelect.Count(c => c.ATTENDANT_UUID.Equals(item.UUID)) > 0 ? true : false;
                if (isExist == false)
                {
                    drsUnselect.Add(item.Clone());
                }
            }
            var totalCount = drsUnselect.Count();

            foreach (var item in drsUnselect) {
                item.PASSWORD = "";
            }

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


    [DirectMethod("loadAttendant", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadAttendant( string keyword, string pageNo, string limitNo, string sort, string dir, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        CISR.Model.Cr.CrModel model = new CISR.Model.Cr.CrModel();
        BasicModel bModel = new BasicModel();
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
            var totalCount = bModel.getAttendant_By_CompanyUuid_Count(getUser().COMPANY_UUID, keyword,true);
            var drsAttendant = bModel.getAttendant_By_CompanyUuid(getUser().COMPANY_UUID, keyword, true, orderLimit);
            
            if (drsAttendant.Count > 0)
            {
                /*將List<RecordBase>變成JSON字符串*/
                jobject = JsonHelper.RecordBaseListJObject(drsAttendant);
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

    [DirectMethod("loadPwg", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadPwg(string pPwgUuid, string keyword, string pageNo, string limitNo, string sort, string dir, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        CISR.Model.Cr.CrModel model = new CISR.Model.Cr.CrModel();
        BasicModel bModel = new BasicModel();
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

            var drsVpwg = model.getVPwg_By_PwgGid(pPwgUuid).AllRecord();
            var totalCount = drsVpwg.Count();


            if (drsVpwg.Count > 0)
            {
                /*將List<RecordBase>變成JSON字符串*/
                jobject = JsonHelper.RecordBaseListJObject(drsVpwg);
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


    public string getPwdShow(string pPwgGid) {
        CrModel mod = new CrModel();
        string ret = "";
        try
        {
            var drsPwg = mod.getVPwg_By_PwgGid(pPwgGid);
            var drsPwg2 = drsPwg.AllRecord().OrderBy(c => c.C_NAME).ToList();
            foreach (var item in drsPwg2) {
                ret += item.C_NAME + ",";
            }
            if (ret.EndsWith(",")) {
                ret = ret.Substring(0, ret.Length - 1);
            }
            return ret;
            
        }
        catch (Exception ex) {
            throw ex;
        }
    }

    public int? getLastFlow(string pFrameItemUuid)
    {
        CrModel mod = new CrModel();
        int? ret = null;
        try
        {
            var drFrameItem = mod.getFrameItem_By_Uuid(pFrameItemUuid).AllRecord().First();
            if (drFrameItem.PWG5_GID != "") {
                if (getPwdShow(drFrameItem.PWG5_GID) != "") {
                    ret = 5;
                    return ret;
                }
            }
            if (drFrameItem.PWG4_GID != "")
            {
                if (getPwdShow(drFrameItem.PWG4_GID) != "")
                {
                    ret = 4;
                    return ret;
                }
            }
            if (drFrameItem.PWG3_GID != "")
            {
                if (getPwdShow(drFrameItem.PWG3_GID) != "")
                {
                    ret = 3;
                    return ret;
                }
            }
            if (drFrameItem.PWG2_GID != "")
            {
                if (getPwdShow(drFrameItem.PWG2_GID) != "")
                {
                    ret = 2;
                    return ret;
                }
            }
            if (drFrameItem.PWG1_GID != "")
            {
                if (getPwdShow(drFrameItem.PWG1_GID) != "")
                {
                    ret = 1;
                    return ret;
                }
            }
            
            return ret;
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [DirectMethod("addAttendToPwgBatch", DirectAction.Store, MethodVisibility.Visible)]
    public JObject addAttendToPwgBatch(string pArrayAttendantUuid, string pArrayFrameItemUuid, string seq, Request request)
    {
        
        #region Declare
        CISR.Model.Cr.CrModel mod = new CISR.Model.Cr.CrModel();        
        #endregion
        try
        {
            /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };

            string[] pAttendantUuid = pArrayAttendantUuid.Split(';');
            string[] pFrameItemUuid = pArrayFrameItemUuid.Split(';');
            bool hasError = false;
            foreach (string fi in pFrameItemUuid) {
                if (fi.Trim().Length > 0) { 
                    try{
                        var drFrameItem =  mod.getFrameItem_By_Uuid(fi).AllRecord().First();
                        var pwdGid = "";
                        if (seq == "1") {
                            pwdGid = drFrameItem.PWG1_GID;
                        }
                        else if (seq == "2") {
                            pwdGid = drFrameItem.PWG2_GID;
                        }
                        else if (seq == "3") {
                            pwdGid = drFrameItem.PWG3_GID;
                        }
                        else if (seq == "4") {
                            pwdGid = drFrameItem.PWG4_GID;
                        }
                        else if (seq == "5") {
                            pwdGid = drFrameItem.PWG5_GID;
                        }

                        if (pwdGid == "") {
                            pwdGid = IST.Util.UID.Instance.GetUniqueID();
                            if (seq == "1")
                            {
                                drFrameItem.PWG1_GID = pwdGid;
                            }
                            else if (seq == "2")
                            {
                                drFrameItem.PWG2_GID = pwdGid;
                            }
                            else if (seq == "3")
                            {
                                drFrameItem.PWG3_GID = pwdGid;
                            }
                            else if (seq == "4")
                            {
                                drFrameItem.PWG4_GID = pwdGid;
                            }
                            else if (seq == "5")
                            {
                                drFrameItem.PWG5_GID = pwdGid;
                            }
                            drFrameItem.gotoTable().Update_Empty2Null(drFrameItem);
                        }
                        else
                        {
                            var drsPwg = mod.getPwg_By_Uuid(pwdGid);
                            for (var i = 0; i < drsPwg.Count; i++) { 
                                drsPwg[i].gotoTable().Delete(drsPwg[i]);
                            }
                            //drsPwg[0].ATTENDANT_UUID = null;
                            
                            
                        }



                        foreach (string at in pAttendantUuid)
                        {
                            if (at.Trim().Length > 0)
                            {
                                addAttendToPwg(at, pwdGid, fi, seq, request);
                            }
                        }
                    }catch(Exception ex){
                        hasError = true;
                    }
                }
            }

            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }
    [DirectMethod("addAttendToPwg", DirectAction.Store, MethodVisibility.Visible)]    
    public JObject addAttendToPwg(string pAttendantUuid, string pPwgGid,string pFrameItemUuid,string seq, Request request)
    {
        #region Declare
        CISR.Model.Cr.CrModel mod = new CISR.Model.Cr.CrModel();        
        #endregion
        try
        {
            /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };

            var drPwg = mod.getPwg_By_Gid_And_AttendantUuid(pPwgGid, pAttendantUuid);
            if (drPwg.AllRecord().Count==0) {
                Pwg_Record newPwg = new Pwg_Record();
                newPwg.GID = pPwgGid;
                newPwg.ATTENDANT_UUID = pAttendantUuid;                
                newPwg.gotoTable().Insert_Empty2Null(newPwg);


                var drFrameItem = mod.getFrameItem_By_Uuid(pFrameItemUuid).AllRecord().First();
                var showName = getPwdShow(pPwgGid);
                if (seq == "1") {
                    drFrameItem.PWG1_SHOW = showName;
                }
                else if (seq == "2")
                {
                    drFrameItem.PWG2_SHOW = showName;
                }
                else if (seq == "3")
                {
                    drFrameItem.PWG3_SHOW = showName;
                }
                else if (seq == "4")
                {
                    drFrameItem.PWG4_SHOW = showName;
                }
                else if (seq == "5")
                {
                    drFrameItem.PWG5_SHOW = showName;
                }
                else {
                    throw new Exception("SEQ指定錯誤");
                }
                drFrameItem.LAST_FLOW = getLastFlow(pFrameItemUuid);
                drFrameItem.gotoTable().Update_Empty2Null(drFrameItem);
            }
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();

        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("removeAttendFromPwg", DirectAction.Store, MethodVisibility.Visible)]
    public JObject removeAttendFromPwg(string pAttendantUuid, string pPwgGid, string pFrameItemUuid, string seq, Request request)
    {
        #region Declare
        CISR.Model.Cr.CrModel mod = new CISR.Model.Cr.CrModel();        
        #endregion
        try
        {
            /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };

            var drPwg = mod.getPwg_By_Gid_And_AttendantUuid(pPwgGid, pAttendantUuid);
            if (drPwg != null)
            {
                drPwg.DeleteAllRecord();

                var drFrameItem = mod.getFrameItem_By_Uuid(pFrameItemUuid).AllRecord().First();
                var showName = getPwdShow(pPwgGid);
                if (seq == "1")
                {
                    drFrameItem.PWG1_SHOW = showName;
                }
                else if (seq == "2")
                {
                    drFrameItem.PWG2_SHOW = showName;
                }
                else if (seq == "3")
                {
                    drFrameItem.PWG3_SHOW = showName;
                }
                else if (seq == "4")
                {
                    drFrameItem.PWG4_SHOW = showName;
                }
                else if (seq == "5")
                {
                    drFrameItem.PWG5_SHOW = showName;
                }
                else
                {
                    throw new Exception("SEQ指定錯誤");
                }
                drFrameItem.LAST_FLOW = getLastFlow(pFrameItemUuid);
                drFrameItem.gotoTable().Update_Empty2Null(drFrameItem);
            }

            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("loadFrameHeadCmb1", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadFrameHeadCmb1(string pCompanyUuid, string pageNo, string limitNo, string sort, string dir, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        BasicModel modBasic = new BasicModel();
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
            /*是Store操作一下就可能含有分頁資訊。*/
            orderLimit = ExtDirect.Direct.Helper.Order.getOrderLimit(pageNo, limitNo, sort, dir);
            /*取得總資料數*/
            //var totalCount = modBasic.getFrameHead_By_CompanyUuid_Count(pCompanyUuid);
            //totalCount--;
            /*取得資料*/
            List<FrameHead_Record> result = new List<FrameHead_Record>();
            var root = modBasic.getFrameHead_By_CompanyUuid_Dlevel(pCompanyUuid, 2);
            var totalCount = root.Count();
           // result.Add(root);
            //getAllFrameHead(root.UUID, ref result);



            if (root.Count > 0)
            {
                /*將List<RecordBase>變成JSON字符串*/
                jobject = JsonHelper.RecordBaseListJObject(root);
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

    [DirectMethod("loadFrameHeadCmb2", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadFrameHeadCmb2(string pParentFrameHeadUuid,string pFrameCategoryUuid, string pageNo, string limitNo, string sort, string dir, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        BasicModel modBasic = new BasicModel();
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
            /*是Store操作一下就可能含有分頁資訊。*/
            orderLimit = ExtDirect.Direct.Helper.Order.getOrderLimit(pageNo, limitNo, sort, dir);
            /*取得總資料數*/
            //var totalCount = modBasic.getFrameHead_By_CompanyUuid_Count(pCompanyUuid);
            //totalCount--;
            /*取得資料*/
            List<FrameHead_Record> result = new List<FrameHead_Record>();
            IList<FrameHead_Record> root = null;
            if (pFrameCategoryUuid.Trim().Length == 0) {
                root = modBasic.getFrameHead_By_RootUuid(pParentFrameHeadUuid);
            }
            else
            {
                root = modBasic.getFrameHead_By_RootUuid_FrameCategoryUuid(pParentFrameHeadUuid, pFrameCategoryUuid);
            }
            
            
            var totalCount = root.Count();
            // result.Add(root);
            //getAllFrameHead(root.UUID, ref result);



            if (root.Count > 0)
            {
                /*將List<RecordBase>變成JSON字符串*/
                jobject = JsonHelper.RecordBaseListJObject(root);
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

    [DirectMethod("loadFrameHeadCmbParentFrameHead", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadFrameHeadCmbParentFrameHead(string pFrameHeadUuid, string pageNo, string limitNo, string sort, string dir, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        BasicModel modBasic = new BasicModel();
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
            /*是Store操作一下就可能含有分頁資訊。*/
            orderLimit = ExtDirect.Direct.Helper.Order.getOrderLimit(pageNo, limitNo, sort, dir);
            /*取得總資料數*/
            
            /*取得資料*/
            List<FrameHead_Record> result = new List<FrameHead_Record>();
            //var root = modBasic.getFrameHead_Root_By_CompanyUuid(pCompanyUuid).First();
            // result.Add(root);
            getAllFrameHead(pFrameHeadUuid, ref result);



            if (result.Count > 0)
            {
                /*將List<RecordBase>變成JSON字符串*/
                jobject = JsonHelper.RecordBaseListJObject(result);
            }
            /*使用Store Std out 『Sotre物件標準輸出格式』*/
            return ExtDirect.Direct.Helper.Store.OutputJObject(jobject, result.Count);
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            /*將Exception轉成EXT Exception JSON格式*/
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("loadFrameHeadCmbParentFrameHeadAddAll", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadFrameHeadCmbParentFrameHeadAddAll(string pFrameHeadUuid, string pageNo, string limitNo, string sort, string dir, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        BasicModel modBasic = new BasicModel();
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
            /*是Store操作一下就可能含有分頁資訊。*/
            orderLimit = ExtDirect.Direct.Helper.Order.getOrderLimit(pageNo, limitNo, sort, dir);
            /*取得總資料數*/

            /*取得資料*/
            List<FrameHead_Record> result = new List<FrameHead_Record>();
            //var root = modBasic.getFrameHead_Root_By_CompanyUuid(pCompanyUuid).First();
            // result.Add(root);
            getAllFrameHead(pFrameHeadUuid, ref result);



            if (result.Count > 0)
            {
                /*將List<RecordBase>變成JSON字符串*/
                FrameHead_Record all = new FrameHead_Record();
                all.UUID="";
                all.FULL_FRAME_NAME_LIST = "1:2:全部:全部";                
                all.FULL_FRAME_UUID_LIST = mod.getFrameHead_By_Uuid(pFrameHeadUuid).AllRecord().First().FULL_FRAME_UUID_LIST;
                all.C_NAME = "全部";
                
                result.Insert(0, all);
                jobject = JsonHelper.RecordBaseListJObject(result);
            }
            /*使用Store Std out 『Sotre物件標準輸出格式』*/
            return ExtDirect.Direct.Helper.Store.OutputJObject(jobject, result.Count);
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            /*將Exception轉成EXT Exception JSON格式*/
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("loadFrameHeadCmb", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadFrameHeadCmb(string pCompanyUuid, string pageNo, string limitNo, string sort, string dir, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        BasicModel modBasic = new BasicModel();
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
            /*是Store操作一下就可能含有分頁資訊。*/
            orderLimit = ExtDirect.Direct.Helper.Order.getOrderLimit(pageNo, limitNo, sort, dir);
            /*取得總資料數*/
            var totalCount = modBasic.getFrameHead_By_CompanyUuid_Count(pCompanyUuid);
            totalCount--;
            /*取得資料*/
            List<FrameHead_Record> result = new List<FrameHead_Record>();
            var root = modBasic.getFrameHead_Root_By_CompanyUuid(pCompanyUuid).First();
            // result.Add(root);
            getAllFrameHead(root.UUID, ref result);



            if (result.Count > 0)
            {
                /*將List<RecordBase>變成JSON字符串*/
                jobject = JsonHelper.RecordBaseListJObject(result);
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


    [DirectMethod("loadFrameHeadCmb3", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadFrameHeadCmb3(string pParentFrameHeadUuid, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        BasicModel modBasic = new BasicModel();
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
            /*是Store操作一下就可能含有分頁資訊。*/
            //orderLimit = ExtDirect.Direct.Helper.Order.getOrderLimit(pageNo, limitNo, sort, dir);
            /*取得總資料數*/
            //var totalCount = modBasic.getFrameHead_By_CompanyUuid_Count(pCompanyUuid);
            //totalCount--;
            /*取得資料*/
            List<FrameHead_Record> result = new List<FrameHead_Record>();
            //modBasic.getframehead_by_
            var root = modBasic.getFrameHead_By_Uuid(pParentFrameHeadUuid).First();
            // result.Add(root);
            getAllFrameHead(root.UUID, ref result);
            var totalCount = result.Count;
            if (result.Count > 0)
            {
                /*將List<RecordBase>變成JSON字符串*/
                jobject = JsonHelper.RecordBaseListJObject(result);
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


    private List<FrameHead_Record> getAllFrameHead(string pUuid,ref List<FrameHead_Record> result) {
        BasicModel mod = new BasicModel();
        try
        {
            var drsChildren = mod.getFrameHead_By_RootUuid(pUuid);
            if (drsChildren.Count > 0) {
                foreach (var item in drsChildren) {
                    result.Add(item);
                    getAllFrameHead(item.UUID, ref result);
                }
            }
            return result;
        }
        catch (Exception ex) {
            throw ex;
        }
    }

}

