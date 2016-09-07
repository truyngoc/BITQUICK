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
                if (Singleton<BITCurrentSession>.Inst.SessionMember.CodeId == "0")
                {
                    loadGH();
                }
                else
                {
                    Response.Redirect("~/Admin/GH.aspx");
                }
            }
        }

        private void loadGH()
        {
            //List<RECEIVE> lst = Singleton<RECEIVE_BC>.Inst.SelectGHBlockChain();
            ////List<RECEIVE> lst = Singleton<RECEIVE_BC>.Inst.SelectAllItems(Singleton<BITCurrentSession>.Inst.SessionMember.CodeId);
            //dtlGH.DataSource = lst;
            //dtlGH.DataBind();
        }

        public string GHTo(object wReceive)
        {
            string ghToWallet = string.Empty;
            if (wReceive.ToString() == "Bwallet")
            {
                ghToWallet = "B Wallet";
            }
            else
                ghToWallet = "Blockchain Wallet";
            return ghToWallet;
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

        public bool getSelectVisible(object status)
        {
            bool ghStatus = false;
            if (status.ToString() == "1")
                ghStatus = false;
            else
                ghStatus = true;
            return ghStatus;
        }
        string ReceiveID = string.Empty;

        protected void btnPopTransaction_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string yourValue = btn.CommandArgument;
            string url = string.Format("https://blockchain.info/tx/{0}", yourValue);
            string s = "window.open('" + url + "', 'popup_window');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }
    }
}