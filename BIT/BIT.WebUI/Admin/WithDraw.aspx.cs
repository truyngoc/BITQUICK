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
                    getCWalletAmount();
                    bindDataList();
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

        public void getCWalletAmount()
        {
            WALLET userWallet = Singleton<WALLET_BC>.Inst.SelectItemByCodeId(Singleton<BITCurrentSession>.Inst.SessionMember.CodeId);
            txtAmount.Text = userWallet.C_Wallet.ToString();
        }

        public void bindDataList()
        {
            List<WITHDRAW> lstWD = Singleton<WITHDRAW_BC>.Inst.SelectAllItems(Singleton<BITCurrentSession>.Inst.SessionMember.CodeId);
            dtlWithDraw.DataSource = lstWD;
            dtlWithDraw.DataBind();
        }

        protected void btnWithDraw_Click(object sender, EventArgs e)
        {
            ////insert into withdraw
            WITHDRAW objWD = new WITHDRAW();
            objWD.CodeId = Singleton<BITCurrentSession>.Inst.SessionMember.CodeId;
            objWD.Date_Create = DateTime.Now;
            objWD.Amount = Convert.ToDecimal( txtAmount.Text);
            objWD.Status = 0;
            objWD.TransactionId = string.Empty;
            objWD.Wallet = Singleton<BITCurrentSession>.Inst.SessionMember.Wallet;

            //insert
            Singleton<WITHDRAW_BC>.Inst.InsertItem(objWD);
            TNotify.Toastr.Warning("Withdraw Completed ", "Completed", TNotify.NotifyPositions.toast_top_full_width, true);
            Response.Redirect("../Admin/Withdraw.aspx");
        }
    }
}