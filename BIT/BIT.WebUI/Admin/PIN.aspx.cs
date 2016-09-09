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
    public partial class PIN : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (hidMonth.Value != string.Empty)
                {
                    drTimeInvest.SelectedIndex = Convert.ToInt32(hidMonth.Value);
                }
                //}
                if (Singleton<BITCurrentSession>.Inst.isLoginUser)
                {
                    if (Singleton<BITCurrentSession>.Inst.SessionMember.CodeId == "0")
                    {
                        Response.Redirect("../Admin/AdminPin.aspx");
                    }
                    else
                    {
                        loadPackInfo();
                    
                        bindDataList();
                        getAdminWallet();
                    }
                }
            }
        }

        public void ShowMessageError(Label lblMsgErr, string sMsgErr = "", bool bVisible = false)
        {
            lblMsgErr.Text = sMsgErr;
            lblMsgErr.Visible = bVisible;
        }

        protected void btnUpdate_Click1(object sender, EventArgs e)
        {
            //Check if invest package not expire - cannot buy new package
            if (txtPasswordPIN.Text != Singleton<BITCurrentSession>.Inst.SessionMember.Password_PIN)
            {
                TNotify.Toastr.Warning("Wrong transaction password, please try again", "Error", TNotify.NotifyPositions.toast_top_full_width, true);
                return;
            }

            try
            {
                //get temp object to insert, start date ,end date, expired date will be update after admin confirm transaction
                PACKAGE_TRANSACTION obj = Singleton<PACKAGE_TRANSACTION_BC>.Inst.SelectActiveItem(Singleton<BITCurrentSession>.Inst.SessionMember.CodeId);
                PIN_TRANSACTION objPIN = new PIN_TRANSACTION();
                objPIN.CODE_ID = Singleton<BITCurrentSession>.Inst.SessionMember.CodeId;
                objPIN.AMOUNT = Convert.ToDecimal(txtTotalAmount.Text);
                objPIN.CONFIRM_DATE = DateTime.Now;
                objPIN.CONFIRM_SEND = false;
                objPIN.CREATE_DATE = DateTime.Now;
                objPIN.FROM_DATE = DateTime.Now;
                switch (drTimeInvest.SelectedValue)
                {
                    case "1":
                        objPIN.TO_DATE = DateTime.Now.AddMonths(1);
                        break;
                    case "2":
                        objPIN.TO_DATE = DateTime.Now.AddMonths(2);
                        break;
                    case "3":
                        objPIN.TO_DATE = DateTime.Now.AddMonths(3);
                        break;
                }

                objPIN.TRANSACTION_PIN = txtTransaction.Text;


                Singleton<PIN_TRANSACTION_BC>.Inst.InsertItem(objPIN);

                TNotify.Alerts.Danger(string.Format("Extend Invest Package {0} Completed", lblCurrentPack.Text), true);
                Response.Redirect("../Admin/PIN.aspx");

            }
            catch (Exception ex)
            {
                TNotify.Toastr.Warning("Error occur ! Please try again", "Error", TNotify.NotifyPositions.toast_top_full_width, true);
            }
        }

        private void loadPackInfo()
        {
            //load packinfo
            PACKAGE_TRANSACTION pckActive = Singleton<PACKAGE_TRANSACTION_BC>.Inst.SelectActiveItem(Singleton<BITCurrentSession>.Inst.SessionMember.CodeId);
            lblCurrentPack.Text = pckActive.PACKAGEID.ToString();

            //PIN spin = Singleton
        }


        public void bindDataList()
        {
            List<PIN_TRANSACTION> lstPackage = Singleton<PIN_TRANSACTION_BC>.Inst.SelectAllItems(Singleton<BITCurrentSession>.Inst.SessionMember.CodeId);
            grdListPH.DataSource = lstPackage;
            grdListPH.DataBind();
        }

        protected void drTimeInvest_SelectedIndexChanged(object sender, EventArgs e)
        {
            hidMonth.Value = drTimeInvest.SelectedIndex.ToString();
            //HttpContext.Current.Session["MonthSelect"] = drTimeInvest.SelectedIndex;
            string currentPack = lblCurrentPack.Text;
            switch (currentPack)
            {
                case "1":
                    txtTotalAmount.Text = (Convert.ToInt32(drTimeInvest.SelectedValue) * 0.2).ToString();
                    break;
                case "2":
                    txtTotalAmount.Text = (Convert.ToInt32(drTimeInvest.SelectedValue) * 0.25).ToString();
                    //extendValue = (decimal)0.25;
                    break;
                case "3":
                    txtTotalAmount.Text = (Convert.ToInt32(drTimeInvest.SelectedValue) * 0.3).ToString();
                    //extendValue = (decimal)0.3;
                    break;
                case "4":
                    txtTotalAmount.Text = ( Convert.ToInt32(drTimeInvest.SelectedValue) * 0.3).ToString();
                    //extendValue = (decimal)0.3;
                    break;
                case "5":
                    txtTotalAmount.Text = (Convert.ToInt32(drTimeInvest.SelectedValue) * 0.3).ToString();
                    //extendValue = (decimal)0.3;
                    break;
            }
        }

        public string getStatus(object statusPH)
        {
            string restring = string.Empty;
            switch (statusPH.ToString())
            {
                case "0":
                    restring = "Waiting Confirm";
                    break;
                case "1":
                    restring = "Confirmed";
                    break;
            }
            return restring;
        }

        public string datecount(object startDate)
        {
            return (DateTime.Now.DayOfYear - Convert.ToDateTime(startDate).DayOfYear).ToString();
        }

        public void getAdminWallet()
        {
            string admWallet = Singleton<MEMBERS_BC>.Inst.SelectRandomAdmin().Wallet;
            imgAdminWallet.ImageUrl = string.Format("http://chart.googleapis.com/chart?chs=200x200&cht=qr&chl={0}", admWallet);
            lblAdminWallet.Text = admWallet;
        }
    }
}