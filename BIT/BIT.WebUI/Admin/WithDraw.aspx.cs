using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.IO;
using System.Net;
using System.Text;

using BIT.Objects;
using BIT.Controller;
using BIT.Common;

namespace BIT.WebUI.Admin
{
    public partial class WithDraw : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Singleton<BITCurrentSession>.Inst.isLoginUser)
            {
                Response.Redirect("~/Admin/Login.aspx");
            }
            else
            {
                if (Singleton<BITCurrentSession>.Inst.SessionMember.CodeId != "0")
                {
                    
                }
                else
                {
                    Response.Redirect("~/Admin/WithdrawAdmin.aspx");
                }
            }
        }

        public string getGHStatus(object status)
        {
            string ghStatus = string.Empty;
            if (status.ToString() == "1")
                ghStatus = "Success";
            else
                ghStatus = "Pending";
            return ghStatus;
        }
    }
}