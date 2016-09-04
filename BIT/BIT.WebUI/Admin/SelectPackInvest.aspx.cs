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
                if (!Singleton<BITCurrentSession>.Inst.isLoginUser)
                {
                    Response.Redirect("~/Admin/Login");
                }
                else
                {

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

        }

        public void getSpackage()
        {
            List<SPACKAGE> lstPackage = Singleton<SPACKAGE_BC>.Inst.SelectAllItems();

            drPackSelectTion.DataSource = lstPackage;
            drPackSelectTion.DataValueField = "PackageID";
            drPackSelectTion.DataTextField = "PINAmount";
            drPackSelectTion.DataBind();
        }

    }
}
