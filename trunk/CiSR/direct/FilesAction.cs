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
[DirectService("FilesAction")]
public class FilesAction : BaseAction
{
    [DirectMethod("loadFiles", DirectAction.Load, MethodVisibility.Visible)]
    public JObject loadFiles(string pFilesGroupId,string pageNo,string limitNo,string sort,string dir, Request request)
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
            
           var orderLimit = ExtDirect.Direct.Helper.Order.getOrderLimit(pageNo, limitNo, sort, dir);
           var totalCount = mod.getFiles_By_FileGroupId_Count(pFilesGroupId);
           var data = mod.getFiles_By_FileGroupId(pFilesGroupId, orderLimit);

           if (data.Count > 0)
           {
               jobject = JsonHelper.RecordBaseListJObject(data);
           }


           return ExtDirect.Direct.Helper.Store.OutputJObject(jobject, totalCount);
            

            //return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(new Exception("Data Not Found!"));
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    private void syncFileCount(string pFileGroupId ) { 
        CrModel mod = new CrModel();
        try{
            var count = mod.getFiles_By_FileGroupId_Count(pFileGroupId);
            var drsUploadJob = mod.getUploadJob_By_FileGroupId(pFileGroupId);
            foreach(var item in drsUploadJob){
                item.FILES_COUNT = count;
                item.gotoTable().Update_Empty2Null(item);
            }
        }catch(Exception ex){
            throw ex;
        }
    }
    [DirectMethod("submitFiles", DirectAction.FormSubmission, MethodVisibility.Visible)]
    public JObject submitFiles( string file_group_id,string upload_job_uuid, HttpRequest request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        CrModel mod = new CrModel();        
        Files_Record files = new Files_Record();
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

            
                
                //string fileGroupId = IST.Util.UID.Instance.GetUniqueID();
                files.UUID = IST.Util.UID.Instance.GetUniqueID();
                files.FILES_GROUP_ID = file_group_id;
                if (request.Files.Count == 0) {
                    throw new Exception("無上傳檔案");
                }

                #region 附件處理
                if (request.Files.Count > 0)
                {
                    var drUploadJob = mod.getUploadJob_By_Uuid(upload_job_uuid).AllRecord().First();
                    if (drUploadJob.FILES_GROUP_ID != "")
                    {
                        files.FILES_GROUP_ID = drUploadJob.FILES_GROUP_ID;
                    }
                    if (request.Files[0].FileName != "")
                    {                        
                        HttpServerUtility server = System.Web.HttpContext.Current.Server;
                        var uploadFolder = server.MapPath(CISR.Parameter.Config.ParemterConfigs.GetConfig().UploadFolder);
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
                        uploadFolder = uploadFolder + "files//";

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

                        files.FILE_NAME = request.Files[0].FileName;
                        files.SYSTEM_PATH = CISR.Parameter.Config.ParemterConfigs.GetConfig().UploadFolder + this.getUser().COMPANY_ID + "//files//" + fileUuid + "." + extName;
                        files.gotoTable().Insert_Empty2Null(files);

                        drUploadJob = mod.getUploadJob_By_Uuid(upload_job_uuid).AllRecord().First();
                        if (drUploadJob.FILES_GROUP_ID == "") {
                            drUploadJob.FILES_GROUP_ID = files.FILES_GROUP_ID;
                            drUploadJob.gotoTable().Update_Empty2Null(drUploadJob);
                        }

                    }
                }
                #endregion
                syncFileCount(file_group_id);
                return ExtDirect.Direct.Helper.Form.OutputJObject(JsonHelper.RecordBaseJObject(files));
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("removeFiles", DirectAction.Load, MethodVisibility.Visible)]
    public JObject removeFiles(string pFileUuid, Request request)
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
            var data = mod.getFiles_By_Uuid(pFileUuid).AllRecord().First();
            data.gotoTable().Delete(data);
            syncFileCount(data.FILES_GROUP_ID);
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

}

