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
    public partial class WithdrawAdmin : System.Web.UI.Page
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
                    if (!this.IsPostBack)
                    {
                        //load recharge history
                        //getCurrentPHAvailable();
                        //imgQRCode.ImageUrl = string.Format("http://chart.googleapis.com/chart?chs=200x200&cht=qr&chl={0}", Singleton<BITCurrentSession>.Inst.SessionMember.Wallet);
                        //lblSyswallet.Text = Singleton<BITCurrentSession>.Inst.SessionMember.Wallet;
                        bindDLWithDraw();
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(txtTrans.Text == string.Empty)
            {
                TNotify.Toastr.Warning("Please input transaction string !", "Completed", TNotify.NotifyPositions.toast_top_full_width, true);
                return;
            }
            else
            {
                if (Singleton<WITHDRAW_BC>.Inst.isExistTransaction(txtTrans.Text))
                {
                    TNotify.Toastr.Warning("Transaction already exist !", "Completed", TNotify.NotifyPositions.toast_top_full_width, true);
                    return;
                }
                else
                {
                    WITHDRAW objWdr = Singleton<WITHDRAW_BC>.Inst.SelectItem(Convert.ToInt32(lblIDCode.Text));
                    objWdr.TransactionId = txtTrans.Text;
                    Singleton<WITHDRAW_BC>.Inst.UpdateItem(objWdr);
                }
            }
            Response.Redirect(Request.Path);
        }

        private void bindDLWithDraw()
        {
            List<WITHDRAW> lstWITHDRAW = Singleton<WITHDRAW_BC>.Inst.SelectAllItems("0");
            dtlRecharge.DataSource = lstWITHDRAW;
            dtlRecharge.DataBind();
        }

        public string getStatus(object status)
        {
            string stts = string.Empty;
            switch(status.ToString())
            {
                case "0":
                    stts = "Pending";
                    break;
                case "1":
                    stts = "Completed";
                    break;    
                case "2":
                    stts = "Cancelled";
                    break;
            }
            return stts;
        }
        public bool getConfirmVisible(object status)
        {
            if (status.ToString() != "1")
                return true;
            else
                return false;
        }

        protected void lnkBlockchain_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string yourValue = btn.CommandArgument;

            string url = string.Format("https://blockchain.info/address/{0}", yourValue);
            string s = "window.open('" + url + "', 'popup_window');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }

        protected void lnkTransaction_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string yourValue = btn.CommandArgument;

            string url = string.Format("https://blockchain.info/tx/{0}", yourValue);
            string s = "window.open('" + url + "', 'popup_window');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);

        }

        protected void lnkCheckTrans_Click(object sender, EventArgs e)
        {
            string url = string.Format("https://blockchain.info/tx/{0}", txtTrans.Text);
            string s = "window.open('" + url + "', 'popup_window');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }

        protected void lbkBtnConfirm_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string ID = btn.CommandArgument;

            WITHDRAW objw = Singleton<WITHDRAW_BC>.Inst.SelectItem(Convert.ToInt32(ID));
            imgQRCode.ImageUrl = string.Format("http://chart.googleapis.com/chart?chs=200x200&cht=qr&chl={0}", objw.Wallet);
            lblSyswallet.Text = objw.Wallet;
            this.txtAmount.Text = objw.Amount.ToString();
            this.txtAmount.Enabled = false;
            lblIDCode.Text = ID;
        }
    }
}