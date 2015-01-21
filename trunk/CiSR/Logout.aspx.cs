using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CISR
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CISR.Util.Session.Store ss = new CISR.Util.Session.Store();
            ss.ClearCookieInSession();
        }
    }
}
