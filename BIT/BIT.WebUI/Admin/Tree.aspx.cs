using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using BIT.Controller;
using BIT.Objects;
using BIT.Common;

namespace BIT.WebUI.Admin
{
    public partial class Tree : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!Singleton<BITCurrentSession>.Inst.isLoginUser)
                {
                    Response.Redirect("~/Admin/Login");
                }
                else
                {
                    string username = Singleton<BITCurrentSession>.Inst.SessionMember.Username;

                    hidUserName.Value = username;
                }
            }
        }

        [WebMethod]
        public static List<object> GetChartData(string username)
        {
            MEMBERS_BC ctlMem = new MEMBERS_BC();

            var data = ctlMem.GetChartData(username);

            return data;
        }
    }
}