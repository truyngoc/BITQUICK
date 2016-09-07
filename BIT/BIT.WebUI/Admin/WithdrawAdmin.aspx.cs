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
                        imgQRCode.ImageUrl = string.Format("http://chart.googleapis.com/chart?chs=200x200&cht=qr&chl={0}", Singleton<BITCurrentSession>.Inst.SessionMember.Wallet);
                        lblSyswallet.Text = Singleton<BITCurrentSession>.Inst.SessionMember.Wallet;
                        bindDLWithDraw();
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(txtAmount.Text != string.Empty )
            {
                try
                {
                    if(Convert.ToInt32(txtAmount.Text) < 0)
                    {
                        //string notInsAmount = string.Format("alert('Please input correct amount BTC Recharge !');");
                        //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", notInsAmount, true);
                        lblError.Text = "Please input correct amount BTC Recharge !";
                        return;
                    }
                }
                catch
                {
                    //string notInsAmount = string.Format("alert('Please input correct amount BTC Recharge !');");
                    //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", notInsAmount, true);
                    lblError.Text = "Please input correct amount BTC Recharge !";
                    return;
                }
            }
            else
            {
                lblError.Text = "Please input amount BTC Recharge !";
                return;
            }
            if(txtTrans.Text == string.Empty)
            {
                //string notInsertTransaction = string.Format("alert('Please input transaction string !');");
                //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", notInsertTransaction, true);
                lblError.Text = "Please input transaction string !";
                return;
            }
            //if (Singleton<RECHARGE_BC>.Inst.isExistTransaction(txtTrans.Text))
            //{
            //    lblError.Text = "Transaction already exist !";
            //    return;
            //}

            //RECHARGE obj = new RECHARGE();
            //obj.Amount = Convert.ToDecimal(txtAmount.Text);
            //obj.CodeId = Singleton<BITCurrentSession>.Inst.SessionMember.CodeId;
            //obj.CreateDate = DateTime.Now;
            //obj.ReceiveWallet = Singleton<BITCurrentSession>.Inst.SessionMember.Sys_Wallet;
            //obj.SendWallet = Singleton<BITCurrentSession>.Inst.SessionMember.Wallet;
            //obj.Status = 0;
            //obj.Transaction = txtTrans.Text;
            //insert wallet

            //Singleton<RECHARGE_BC>.Inst.InsertItem(obj);
            //string strPHComplete = string.Format("Recharge {0} BTC Successful !", obj.Amount);
            ////ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", strPHComplete, true);

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
            //"alert('"+strPHComplete+"'); window.location='../Admin/ReCharge.aspx';", true);
            //Response.Redirect(Request.Path);
        }

        private void bindDLWithDraw()
        {
            //List<RECEIVE> lstRecharges = Singleton<RECEIVE_BC>.Inst.SelectGHBlockChain();
            //dtlRecharge.DataSource = lstRecharges;
            //dtlRecharge.DataBind();
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
        public bool getConfirmVisible()
        {
            if (Singleton<BITCurrentSession>.Inst.SessionMember.ID == 1)
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
    }
}