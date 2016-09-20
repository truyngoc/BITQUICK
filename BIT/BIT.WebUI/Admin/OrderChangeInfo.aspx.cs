using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIT.Objects;
using BIT.Controller;
using BIT.Common;
using System.Text;

namespace BIT.WebUI.Admin
{
    public partial class OrderChangeInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Singleton<BITCurrentSession>.Inst.isLoginUser)
            {
                Response.Redirect("~/Admin/Login.aspx");
            }
            else
            {
                if (Singleton<BITCurrentSession>.Inst.SessionMember.CodeId == "0")
                {
                    LoadAllAcc();
                }
                else
                {
                    LoadMember();
                    sessionSearch.Visible = false;
                }

            }
        }

        public void LoadAllAcc()
        {
            var user_name = txtUsername.Text.Trim();
            var ctlMem = new MEMBERS_BC();
            var lstMem = ctlMem.SearchItemByUserName_ADMIN(user_name);

            grdMembers.DataSource = lstMem;
            grdMembers.DataBind();
        }

        public void LoadMember()
        {
            var ctlMem = new MEMBERS_BC();
            var lstMem = ctlMem.SearchItemByUserName_EDIT(Singleton<BITCurrentSession>.Inst.SessionMember.Username);

            grdMembers.DataSource = lstMem;
            grdMembers.DataBind();
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {

        }

        public bool ShowConfirm(string upline)
        {
            if (Singleton<BITCurrentSession>.Inst.SessionMember.CodeId == "0")
            {
                return true;
            }
            else if (Singleton<BITCurrentSession>.Inst.SessionMember.Username == upline)
                return true;
            else
            {
                return false;
            }
        }
        public string getStatus(string STA)
        {
            string restring = string.Empty;
            switch (STA)
            {
                case "0":
                    restring = "Waiting Upline Confirm";
                    break;
                case "1":
                    restring = "Waiting BitQuick Confirm";
                    break;
                case "2":
                    restring = "Success";
                    break;
            }
            return restring;
        }
    }
}