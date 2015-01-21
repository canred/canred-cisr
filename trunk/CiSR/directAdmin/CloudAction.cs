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
using System.Net;
using System.Net.Sockets;

#endregion

[DirectService("CloudAction")]
public class CloudAction : BaseAction
{


    [DirectMethod("loadActiveConnection", DirectAction.Load, MethodVisibility.Visible)]
    public JObject loadActiveConnection(string activeConnectId, Request request)
    {
        IST.Cloud cloud = new IST.Cloud();
        try
        { /*權限檢查
                if (!checkProxy(new StackTrace().GetFrame(0)))
                {
                    throw new Exception("Permission Denied!");
                };
               */
            CISR.Controller.Model.Cloud.CloudModel mod = new CISR.Controller.Model.Cloud.CloudModel();
            var drsAc = mod.getActiveConnection_By_Uuid(activeConnectId).AllRecord();
            var jobject = JsonHelper.RecordBaseListJObject(drsAc);
            return ExtDirect.Direct.Helper.Store.OutputJObject(jobject, drsAc.Count);
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
        finally
        {
            cloud = null;
        }
    }

    [DirectMethod("connectTest", DirectAction.Load, MethodVisibility.Visible)]
    public JObject connectTest(string serverweburl, Request request)
    {
        IST.Cloud cloud = new IST.Cloud();
        try
        { /*權限檢查
                if (!checkProxy(new StackTrace().GetFrame(0)))
                {
                    throw new Exception("Permission Denied!");
                };
               */
            var requestUrl = "";
            if (serverweburl.EndsWith("\\"))
            {
                serverweburl = serverweburl.Substring(0, serverweburl.Length - 1);
            }
            requestUrl = serverweburl + "\\router.ashx";
            /*呼叫遠端的伺服器回應(是也就對方的電腦)*/
            var reutrnObj = cloud.CallDirect(requestUrl, "CloudAction.connect", new string[1] { serverweburl }, "");

            return (JObject)reutrnObj;
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
        finally
        {
            cloud = null;
        }
    }


    [DirectMethod("connect", DirectAction.Load, MethodVisibility.Visible)]
    public JObject connect(string serverweburl, Request request)
    {
        try
        { /*權限檢查
                if (!checkProxy(new StackTrace().GetFrame(0)))
                {
                    throw new Exception("Permission Denied!");
                };
               */

            if (IST.Config.Cloud.CloudConfigs.GetConfig().Role.ToUpper() != "MEMBER")
            {
                return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(new Exception("Cloud->Rolue must be member"));
            }

            if (IST.Config.Cloud.CloudConfigs.GetConfig().SupportCloud != true)
            {
                return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(new Exception("Cloud->SupportCloud must be true"));
            }
            /*
            if (IST.Config.Cloud.CloudConfigs.GetConfig().IsAuthCenter != false)
            {
                return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(new Exception("Cloud->IsAuthCenter must be false"));
            }
             */

            if (IST.Config.DirectAuth.DirectAuthConfigs.GetConfig().AllowCrossPost != true)
            {
                return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(new Exception("DirectAuth->AllowCrossPost must be true"));
            }

            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("settingCloud", DirectAction.Load, MethodVisibility.Visible)]
    public JObject settingCloud(string serverweburl, Request request)
    {
        try
        { /*權限檢查
                if (!checkProxy(new StackTrace().GetFrame(0)))
                {
                    throw new Exception("Permission Denied!");
                };*/
            var strSlave = IST.Config.Cloud.CloudConfigs.GetConfig().Slave;
            var jSlave = JObject.Parse("{" + strSlave + "}")["Slave"] as JArray;
            var ip = serverweburl.Split('/')[2];
            var isExist = false;
            foreach (var item in jSlave)
            {
                if (ip == item["IP"].Value<string>())
                {
                    item["ACTIVE"] = "R";
                    isExist = true;
                }
            }

            if (isExist == false)
            {
                JObject newSlave = new JObject(
                    new JProperty("IP", ip),
                    new JProperty("ACTIVE", "R"));
                jSlave.Add(newSlave);
            }


            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(InitAction.ConfigFilePath(InitAction.ConfigType.CloudFilePath));
            string saveSlave = "<![CDATA[";
            saveSlave += "Slave:";
            saveSlave += jSlave.ToString();
            saveSlave += "";
            saveSlave += "]]>";
            //var newComment = doc.CreateComment(saveSlave);
            doc.GetElementsByTagName("Slave")[0].InnerXml = saveSlave;
            doc.Save(InitAction.ConfigFilePath(InitAction.ConfigType.CloudFilePath));

            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("settingSlave", DirectAction.Load, MethodVisibility.Visible)]
    public JObject settingSlave(string serverweburl, Request request)
    {
        IST.Cloud cloud = new IST.Cloud();
        try
        { /*權限檢查
                if (!checkProxy(new StackTrace().GetFrame(0)))
                {
                    throw new Exception("Permission Denied!");
                };*/
            var requestUrl = "";
            if (serverweburl.EndsWith("\\"))
            {
                serverweburl = serverweburl.Substring(0, serverweburl.Length - 1);
            }
            requestUrl = serverweburl + "\\router.ashx";

            string authCentetUrl = IST.Config.Cloud.CloudConfigs.GetConfig().AuthCenterPrototype + ":////" + LocalIPAddress() + "/" + CISR.Parameter.Config.ParemterConfigs.GetConfig().AppName + ":" + IST.Config.Cloud.CloudConfigs.GetConfig().AuthCenterPort;

            /*呼叫遠端的伺服器回應(是也就對方的電腦)*/
            var reutrnObj = cloud.CallDirect(requestUrl, "CloudAction.settingSlaveAuthMaster", new string[1] { authCentetUrl }, "");

            return (JObject)reutrnObj;
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
        finally
        {
            cloud = null;
        }
    }

    public string LocalIPAddress()
    {
        return IST.Config.Cloud.CloudConfigs.GetConfig().AuthCenterIP;
    }

    [DirectMethod("settingSlaveAuthMaster", DirectAction.Load, MethodVisibility.Visible)]
    public JObject settingSlaveAuthMaster(string authMaster, Request request)
    {
        try
        { /*權限檢查
                if (!checkProxy(new StackTrace().GetFrame(0)))
                {
                    throw new Exception("Permission Denied!");
                };*/
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(InitAction.ConfigFilePath(InitAction.ConfigType.CloudFilePath));
            doc.GetElementsByTagName("AuthMaster")[0].InnerText = authMaster;
            doc.Save(InitAction.ConfigFilePath(InitAction.ConfigType.CloudFilePath));

            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("checkConfig", DirectAction.Load, MethodVisibility.Visible)]
    public JObject checkConfig(Request request)
    {
        try
        { /*權限檢查
                if (!checkProxy(new StackTrace().GetFrame(0)))
                {
                    throw new Exception("Permission Denied!");
                };*/
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }





}



