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
    public partial class SelectPackInvest : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Session["PackSelect"] != null)
                {
                    drPackSelectTion.SelectedIndex = (int)Session["PackSelect"];
                }
                if (Session["MonthSelect"] != null)
                {
                    drTimeInvest.SelectedIndex = (int)Session["MonthSelect"];
                }
                //}
                if (Singleton<BITCurrentSession>.Inst.isLoginUser)
                {
                    if (Singleton<BITCurrentSession>.Inst.SessionMember.CodeId == "0")
                    {
                        Response.Redirect("../Admin/AdminSelectPackInvest.aspx");
                    }
                    else
                    {
                        getSpackage();
                        bindDataList();
                        getAdminWallet();
                    }
                }
            }
        }

        public MEMBERS GetDataOnForm()
        {
            MEMBERS obj = new MEMBERS();

            obj.CodeId = hidCodeId.Value;
            //obj.Fullname = txtFullName.Text.Trim();
            //obj.Phone = txtPhone.Text.Trim();
            //obj.Wallet = txtWallet.Text.Trim();
            obj.Password_PIN = txtPasswordPIN.Text.Trim();
            return obj;
        }

        public void UpdateProfile()
        {
            MEMBERS_BC ctlMember = new MEMBERS_BC();

            MEMBERS obj = GetDataOnForm();

            //Tung: Them doan check Password 2
            if (obj.Password_PIN == Singleton<BITCurrentSession>.Inst.SessionMember.Password_PIN)
            {
                ctlMember.UpdateItem(obj);
                ShowMessageError(lblMessage, "Update profile member successful", true);
            }
            else
            {
                ShowMessageError(lblMessage, "Password PIN is invalid! ", true);
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
            if (!Singleton<PACKAGE_TRANSACTION_BC>.Inst.isAllPackageExpire(Singleton<BITCurrentSession>.Inst.SessionMember.CodeId))
            {
                try
                {
                    //get temp object to insert, start date ,end date, expired date will be update after admin confirm transaction
                    PACKAGE_TRANSACTION obj = new PACKAGE_TRANSACTION();
                    obj.CODEID = Singleton<BITCurrentSession>.Inst.SessionMember.CodeId;
                    obj.PACKAGEID = Convert.ToInt32(drPackSelectTion.SelectedValue);
                    obj.START_DATE = DateTime.Now;
                    switch(drTimeInvest.SelectedValue)
                    {
                        case "1":
                            obj.END_DATE = DateTime.Now.AddMonths(1);
                            break;
                        case "2":
                            obj.END_DATE = DateTime.Now.AddMonths(2);
                            break;
                        case "3":
                            obj.END_DATE = DateTime.Now.AddMonths(3);
                            break;
                    }
                    obj.EXPIRED = 0;
                    obj.GH1 = DateTime.Now.AddDays(45);
                    obj.GH2 = DateTime.Now.AddDays(90);
                    obj.STATUS_GH = 0;
                    obj.CREATE_DATE = DateTime.Now;
                    obj.TRANSACTION_PACKAGE = txtTransaction.Text;
                    obj.AMOUNT = Convert.ToDecimal(txtTotalAmount.Text);
                    obj.STATUS_PH = 0;

                    Singleton<PACKAGE_TRANSACTION_BC>.Inst.InsertItem(obj);

                    TNotify.Alerts.Danger(string.Format("Buy Invest Package {0} Completed", drPackSelectTion.SelectedValue), true);
                    Response.Redirect("../Admin/SelectPackInvest.aspx");
                    Session["PackSelect"] = null;
                    Session["MonthSelect"] = null;
                }
                catch
                {

                }
            }
            else
            {
                TNotify.Alerts.Danger(string.Format("You have Invest Package not complete, please check your Invest Package !", drPackSelectTion.SelectedValue), true);
            }
        }

        public void getSpackage()
        {
            List<SPACKAGE> lstPackage = Singleton<SPACKAGE_BC>.Inst.SelectAllItems();

            drPackSelectTion.DataSource = lstPackage;
            drPackSelectTion.DataValueField = "PackageID";
            drPackSelectTion.DataTextField = "PackageID";
            drPackSelectTion.DataBind();
        }

        public void bindDataList()
        {
            List<PACKAGE_TRANSACTION> lstPackage = Singleton<PACKAGE_TRANSACTION_BC>.Inst.SelectAllItemsByCodeID(Singleton<BITCurrentSession>.Inst.SessionMember.CodeId);
            grdListPH.DataSource = lstPackage;
            grdListPH.DataBind();
        }

        protected void drPackSelectTion_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpContext.Current.Session["PackSelect"] = drPackSelectTion.SelectedIndex;
            switch (drPackSelectTion.SelectedValue)
            {
                case "1":
                    txtTotalAmount.Text = (Convert.ToInt32(drPackSelectTion.SelectedValue) + Convert.ToInt32(drTimeInvest.SelectedValue) * 0.2).ToString();
                    break;
                case "2":
                    txtTotalAmount.Text = (Convert.ToInt32(drPackSelectTion.SelectedValue) + Convert.ToInt32(drTimeInvest.SelectedValue) * 0.25).ToString();
                    //extendValue = (decimal)0.25;
                    break;
                case "3":
                    txtTotalAmount.Text = (Convert.ToInt32(drPackSelectTion.SelectedValue) + Convert.ToInt32(drTimeInvest.SelectedValue) * 0.3).ToString();
                    //extendValue = (decimal)0.3;
                    break;
                case "4":
                    txtTotalAmount.Text = (Convert.ToInt32(drPackSelectTion.SelectedValue) + Convert.ToInt32(drTimeInvest.SelectedValue) * 0.3).ToString();
                    //extendValue = (decimal)0.3;
                    break;
                case "5":
                    txtTotalAmount.Text = (Convert.ToInt32(drPackSelectTion.SelectedValue) + Convert.ToInt32(drTimeInvest.SelectedValue) * 0.3).ToString();
                    //extendValue = (decimal)0.3;
                    break;
            }

        }

        protected void drTimeInvest_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpContext.Current.Session["MonthSelect"] = drTimeInvest.SelectedIndex;
            switch (drPackSelectTion.SelectedValue)
            {
                case "1":
                    txtTotalAmount.Text = (Convert.ToInt32(drPackSelectTion.SelectedValue) + Convert.ToInt32(drTimeInvest.SelectedValue) * 0.2).ToString();
                    break;
                case "2":
                    txtTotalAmount.Text = (Convert.ToInt32(drPackSelectTion.SelectedValue) + Convert.ToInt32(drTimeInvest.SelectedValue) * 0.25).ToString();
                    //extendValue = (decimal)0.25;
                    break;
                case "3":
                    txtTotalAmount.Text = (Convert.ToInt32(drPackSelectTion.SelectedValue) + Convert.ToInt32(drTimeInvest.SelectedValue) * 0.3).ToString();
                    //extendValue = (decimal)0.3;
                    break;
                case "4":
                    txtTotalAmount.Text = (Convert.ToInt32(drPackSelectTion.SelectedValue) + Convert.ToInt32(drTimeInvest.SelectedValue) * 0.3).ToString();
                    //extendValue = (decimal)0.3;
                    break;
                case "5":
                    txtTotalAmount.Text = (Convert.ToInt32(drPackSelectTion.SelectedValue) + Convert.ToInt32(drTimeInvest.SelectedValue) * 0.3).ToString();
                    //extendValue = (decimal)0.3;
                    break;
            }
        }


        public string getStatus(object status)
        {
            string restring = string.Empty;
            switch(status.ToString())
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
            return (Convert.ToDateTime(startDate).AddDays(90).DayOfYear - DateTime.Now.DayOfYear).ToString();
        }

        public bool getGH1Enable(object startDate,object statusGH)
        {
            bool gh1 = false;
            if ((Convert.ToDateTime(startDate).AddDays(90).Day - DateTime.Now.Day) >= 45)
            {
                if (statusGH.ToString() != "1")
                {
                    gh1 = true;
                }
            }
            return gh1;
        }
        public bool getGH2Enable(object startDate,object statusGH)
        {
            bool gh2 = false;
            if ((Convert.ToDateTime(startDate).AddDays(90).Day - DateTime.Now.Day) >= 90)
            {
                if(statusGH.ToString() =="2")
                {
                    gh2 = true;
                }
            }
            return gh2;
        }

        protected void btnGH1_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string ID = btn.CommandArgument;

            PACKAGE_TRANSACTION pck = Singleton<PACKAGE_TRANSACTION_BC>.Inst.SelectItem(Convert.ToInt32(ID));
            //update wallet + commission
            pck.STATUS_GH = 1;
            //update package transaction
            Singleton<PACKAGE_TRANSACTION_BC>.Inst.updateGH1(pck);
        }

        protected void btnGH2_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string ID = btn.CommandArgument;
            PACKAGE_TRANSACTION pck = Singleton<PACKAGE_TRANSACTION_BC>.Inst.SelectItem(Convert.ToInt32(ID));
            //update wallet + commission
            pck.STATUS_GH = 2;
            pck.EXPIRED = 1;
            //update package_transaction
            
            Singleton<PACKAGE_TRANSACTION_BC>.Inst.updateGH2(pck);
        }

        public void getAdminWallet()
        {
            string admWallet = Singleton<MEMBERS_BC>.Inst.SelectItem("0").Wallet;
            imgAdminWallet.ImageUrl = string.Format("http://chart.googleapis.com/chart?chs=200x200&cht=qr&chl={0}",admWallet);
            lblAdminWallet.Text = admWallet;
        }
    }
}
