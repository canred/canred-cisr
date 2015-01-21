using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Security.Principal;
using log4net;
using System.Reflection;

namespace CISR
{
    public class Global : System.Web.HttpApplication
    {
        public static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //CISR.Controller.Model.Authorize.AuthorizeModel model = new CISR.Controller.Model.Authorize.AuthorizeModel();
            //try
            //{
            //    var config = CISR.Parameter.Config.ParemterConfigs.GetConfig();
            //    var aType = config.AuthenticationType.ToUpper();
            //    string account = "";
            //    string domainName = "";
            //    string appName = "";
            //    appName = config.AppName;
            //    switch (aType)
            //    {
            //        case "AD":
            //            account = WindowsIdentity.GetCurrent().Name.Split('\\').Last().ToLower();
            //            domainName = WindowsIdentity.GetCurrent().Name.Split('\\').First().ToLower();
            //            break;
            //        case "PWD":
            //            if (config.LogonPage.Trim().Length > 0)
            //            {                           
            //                Response.Redirect(config.LogonPage);
            //                return;
            //            }
            //            else {
            //                throw new Exception("使用PWD登入模式，但沒有設定登入頁面");
            //            }
            //            break;
            //        case "DEV":
            //            account = config.DEVUserAccount;
            //            domainName = config.DEVUserCompany;
            //            break;
            //        default:
            //            throw new Exception("沒有設定認定方式");
            //    }

            //    if (model.hasApplicationPermission(appName, domainName, account)==false)
            //    {
            //        throw new Exception("使用者:" + account + "沒有登入" + appName + "系統的權限。");
            //    }

            //    StoreSession ss = new StoreSession();

            //    var company = model.getCompany_By_Id(domainName).CurrentRecord();
            //    if (company == null) {
            //        Response.Redirect("/warn/noPermission.aspx");
            //    }
            //    CISR.UserInfo userifno = new UserInfo();
            //    userifno.Company = company;

            //    var member = model.getAttendant_By_CompanyUuid_And_Account(company.UUID, account).CurrentRecord();
            //    if (member == null)
            //    {
            //        Response.Redirect("/warn/noPermission.aspx");
            //    }
            //    userifno.Attendant = member;

            //    userifno.MenuHTML = model.getMenuHTML(appName, domainName, account);
            //    if (userifno.MenuHTML == null)
            //    {
            //        Response.Redirect("/warn/noPermission.aspx");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    log.Error(ex);
            //    throw ex;
            //}
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}