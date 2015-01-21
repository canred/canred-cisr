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

#endregion

[DirectService("UserAction")]
public class UserAction : BaseAction
{

    [DirectMethod("ValidateCode", DirectAction.Load, MethodVisibility.Visible)]
    public JObject ValidateCode(string code, Request request)
    {

        System.Collections.Hashtable hash = new System.Collections.Hashtable();
        try
        {
            /*權限檢查
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            */
            if (CISR.Parameter.Config.ParemterConfigs.GetConfig().GraphicsCertification == false)
            {
                hash.Add("validation", "ok");
                return ExtDirect.Direct.Helper.Message.Success.OutputJObject(hash);
            }

            string session = ss.getObject("CheckCode").ToString();
            if (session == code)
            {
                hash.Add("validation", "ok");
            }
            else
                hash.Add("validation", "fail");
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(hash);
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("logon", DirectAction.FormSubmission, MethodVisibility.Visible)]
    public JObject logon(string company, string account, string password, HttpRequest request)
    {
        try
        { /*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            CISR.Controller.Model.Basic.BasicModel mBasic = new CISR.Controller.Model.Basic.BasicModel();
            var drAttendantV = mBasic.getAttendantV_By_Company_Account_Password(company, account, password);
            System.Collections.Hashtable hash = new System.Collections.Hashtable();

            if (drAttendantV.Count == 0)
            {
                hash.Add("validation", "CANCEL");
                return ExtDirect.Direct.Helper.Message.Success.OutputJObject(hash);
            }

            var drMenu = mBasic.getAuthorityMenuVByAttendantUuid(drAttendantV.First().UUID, CISR.Parameter.Config.ParemterConfigs.GetConfig().InitAppUuid);

            if (drAttendantV.Count == 0)
            {
                hash.Add("validation", "CANCEL");
                IST.MyException.MyException.ErrorNoThrowException(this, new Exception("UserAction->logon沒有此人員帳號存在!"));
            }

            if (drMenu.Count == 0)
            {
                hash.Add("validation", "CANCEL");
                IST.MyException.MyException.ErrorNoThrowException(this, new Exception("UserAction->logon沒有此人員帳號合適的選單存在!"));
            }

            if (drAttendantV.Count > 0 && drMenu.Count > 0)
            {
                hash.Add("validation", "OK");
                ss.setObject("CLOUD_ID", "");
                ss.setObject("USER", drAttendantV.First());
            }
            else
            {
                if (!hash.ContainsKey("validation"))
                {
                    hash.Add("validation", "CANCEL");
                }
            }


            if (IST.Config.Cloud.CloudConfigs.GetConfig().IsAuthCenter)
            {
                /*本身是身份認證中心*/
                CISR.Controller.Model.Cloud.CloudModel cMod = new CISR.Controller.Model.Cloud.CloudModel();
                //cMod.getActiveConnection_By_Uuid
                CISR.Controller.Model.Basic.Table.Record.ActiveConnection_Record newAc = new CISR.Controller.Model.Basic.Table.Record.ActiveConnection_Record();
                newAc.UUID = IST.Util.UID.Instance.GetUniqueID();
                newAc.ACCOUNT = account;
                newAc.APPLICATION = "TEST";
                newAc.COMPANY_UUID = drAttendantV.First().COMPANY_UUID;
                newAc.STARTTIME = System.DateTime.Now;
                newAc.EXPIRESTIME = System.DateTime.Now.AddHours(8);
                newAc.IP = request.UserHostAddress;
                newAc.STATUS = "ONLINE";

                newAc.gotoTable().Insert_Empty2Null(newAc);

                ss.setObject("CLOUD_ID", newAc.UUID);
                ss.setObject("USER", drAttendantV.First());

                hash.Add("CLOUD_ID", newAc.UUID);
            }

            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(hash);
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("cloudLogon", DirectAction.FormSubmission, MethodVisibility.Visible)]
    public JObject cloudLogon(string applicationName, string company, string account, string password, Request request)
    {
        try
        { /*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            CISR.Controller.Model.Basic.BasicModel mBasic = new CISR.Controller.Model.Basic.BasicModel();
            var drAttendantV = mBasic.getAttendantV_By_Company_Account_Password(company, account, password);
            System.Collections.Hashtable hash = new System.Collections.Hashtable();

            if (drAttendantV.Count == 0)
            {
                hash.Add("validation", "CANCEL");
                return ExtDirect.Direct.Helper.Message.Success.OutputJObject(hash);
            }

            var drMenu = mBasic.getAuthorityMenuVByAttendantUuid(drAttendantV.First().UUID, CISR.Parameter.Config.ParemterConfigs.GetConfig().InitAppUuid);

            if (drAttendantV.Count == 0)
            {
                hash.Add("validation", "CANCEL");
                IST.MyException.MyException.ErrorNoThrowException(this, new Exception("UserAction->logon沒有此人員帳號存在!"));
            }

            if (drMenu.Count == 0)
            {
                hash.Add("validation", "CANCEL");
                IST.MyException.MyException.ErrorNoThrowException(this, new Exception("UserAction->logon沒有此人員帳號合適的選單存在!"));
            }

            if (drAttendantV.Count > 0 && drMenu.Count > 0)
            {
                hash.Add("validation", "OK");
                ss.setObject("USER", drAttendantV.First());
            }
            else
            {
                if (!hash.ContainsKey("validation"))
                {
                    hash.Add("validation", "CANCEL");
                }
            }


            if (IST.Config.Cloud.CloudConfigs.GetConfig().IsAuthCenter)
            {
                /*本身是身份認證中心*/
                CISR.Controller.Model.Cloud.CloudModel cMod = new CISR.Controller.Model.Cloud.CloudModel();
                CISR.Controller.Model.Basic.Table.Record.ActiveConnection_Record newAc = new CISR.Controller.Model.Basic.Table.Record.ActiveConnection_Record();
                newAc.UUID = IST.Util.UID.Instance.GetUniqueID();
                newAc.ACCOUNT = account;
                newAc.APPLICATION = applicationName;
                newAc.COMPANY_UUID = drAttendantV.First().COMPANY_UUID;
                newAc.STARTTIME = System.DateTime.Now;
                newAc.EXPIRESTIME = System.DateTime.Now.AddDays(1);
                newAc.IP = request.HttpRequest.UserHostAddress;
                newAc.STATUS = "ONLINE";
                newAc.gotoTable().Insert_Empty2Null(newAc);

                hash.Add("CLOUD_ID", newAc.UUID);
            }

            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(hash);
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }


    [DirectMethod("cloudLogout", DirectAction.FormSubmission, MethodVisibility.Visible)]
    public JObject cloudLogout(string pApplication, string pCompany, string pAccount, Request request)
    {
        try
        { /*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };

            CISR.Controller.Model.Cloud.CloudModel mod = new CISR.Controller.Model.Cloud.CloudModel();
            string cloudId = request.HttpRequest.Headers["CLOUD_ID"];

            var drs = mod.getActiveConnection_By_Uuid(cloudId).AllRecord();
            if (drs.Count > 0)
            {
                foreach (var dr in drs)
                {
                    dr.STATUS = "OFFLINE";
                    dr.gotoTable().Update_Empty2Null(dr);
                }
            }
            System.Collections.Hashtable hash = new System.Collections.Hashtable();
            hash.Add("validation", "OK");
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(hash);
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("forgetPassword", DirectAction.FormSubmission, MethodVisibility.Visible)]
    public JObject forgetPassword(string company, string account, HttpRequest request)
    {
        try
        {
            /*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            CISR.Controller.Model.Basic.BasicModel mBasic = new CISR.Controller.Model.Basic.BasicModel();
            var drAttendantV = mBasic.getAttendantV_By_Company_Account_Password(company, account);
            System.Collections.Hashtable hash = new System.Collections.Hashtable();
            if (drAttendantV.Count == 1)
            {
                hash.Add("status", "OK");
                hash.Add("email", drAttendantV.First().EMAIL);
                IST.Util.Mail.SmtpMailObj mail = new IST.Util.Mail.SmtpMailObj();
                mail.To = drAttendantV.First().EMAIL;
                mail.Contents = "GHG 14064 System<BR>";
                mail.Contents += "Your Password is " + drAttendantV.First().PASSWORD;
                mail.Subject = "Forget Password from 14064";
                IST.Util.Mail.SmtpMailer.Send(mail);
            }
            else
            {
                hash.Add("status", "FAIL");
                hash.Add("email", "");
            }
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(hash);
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("keepSession", DirectAction.Load, MethodVisibility.Visible)]
    public JObject keepSession(Request request)
    {

        System.Collections.Hashtable hash = new System.Collections.Hashtable();
        try
        {
            /*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            var existSession = ss.getObject("USER");
            if (existSession == null)
            {
                hash.Add("validation", "fail");
            }
            else
            {
                hash.Add("validation", "ok");
            }
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(hash);
        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }

    }


    [DirectMethod("getUserInfo", DirectAction.Load, MethodVisibility.Visible)]
    public JObject getUserInfo(Request request)
    {
        List<JObject> jobject = new List<JObject>();
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
            getUser().PASSWORD = "*************";
            return (JsonHelper.RecordBaseJObject(getUser()));

        }
        catch (Exception ex)
        {
            log.Error(ex); IST.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }

    }


}



