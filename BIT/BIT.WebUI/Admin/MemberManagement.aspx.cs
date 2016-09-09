using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIT.Common;
using BIT.Controller;
using BIT.Objects;

namespace BIT.WebUI.Admin
{
    public partial class MemberManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Singleton<BITCurrentSession>.Inst.SessionMember.CodeId == "0")
                {
                    LoadAllAcc();
                }
                else
                {
                    Response.Redirect("~/Admin/Login.aspx");
                }
            }
        }

        public void LoadAllAcc()
        {
            var user_name = txtUserName.Text.Trim();
            var ctlMem = new MEMBERS_BC();
            var lstMem = ctlMem.SearchItemByUserName(user_name);

            grdMEMBERS.DataSource = lstMem;
            grdMEMBERS.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadAllAcc();
        }

        protected void grdMEMBERS_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var ctlMem = new MEMBERS_BC();
            var iD = Convert.ToInt32(e.CommandArgument);

            switch (e.CommandName)
            {
                case "cmdEdit":
                    HttpContext.Current.Session["BIT_MemberID_Edit"] = e.CommandArgument;

                    Response.Redirect("~/Admin/EditAccount");
                    break;
                case "cmdDelete":
                    ctlMem.DeleteItem(iD);
                    LoadAllAcc();

                    break;
                case "cmdLock":
                    ctlMem.LockAccount(iD);
                    LoadAllAcc();
                    break;
            }
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMEMBERS.PageIndex = e.NewPageIndex;
            LoadAllAcc();
        }

    }
}