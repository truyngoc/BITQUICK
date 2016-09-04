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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.IsPostBack)
            //{
            //    if (!Singleton<BITCurrentSession>.Inst.isLoginUser)
            //    {
            //        Response.Redirect("../Admin/Login.aspx");
            //    }
            //    else
            //    {
            //        txtUserName.Attributes.Add("readonly", "readonly");

            //        Load_Category();
            //    }
            //}
        }

        //#region "Load danh muc"

        //public void Load_Category()
        //{
        //    Load_SNUOC();
        //    Load_UpLine(Singleton<BITCurrentSession>.Inst.SessionMember.CodeId);
        //}

        //public void Load_SNUOC()
        //{
        //    SNUOC_BC ctlNuoc = new SNUOC_BC();

        //    var lst = ctlNuoc.SelectAllItems();

        //    ddlCountry.DataSource = lst;
        //    ddlCountry.DataTextField = "NAME";
        //    ddlCountry.DataValueField = "CODE";
        //    ddlCountry.DataBind();

        //    SetDefaultValueDropDownList(ddlCountry);
        //}

        //public void Load_UpLine(string CodeId)
        //{
        //    MEMBERS_BC ctlMember = new MEMBERS_BC();

        //    var lst = ctlMember.SelectUplineOfUserCreate(CodeId);

        //    ddlUpLine.DataSource = lst;
        //    ddlUpLine.DataTextField = "Username";
        //    ddlUpLine.DataValueField = "CodeId";
        //    ddlUpLine.DataBind();

        //    SetDefaultValueDropDownList(ddlUpLine);
        //}

        //public void SetDefaultValueDropDownList(DropDownList ddl, string text = "", string value = "")
        //{
        //    ddl.Items.Insert(0, new ListItem { Text = text, Value = value });
        //}
        //#endregion

        //#region "Get data on form"

        //public MEMBERS GetDataOnForm()
        //{
        //    MEMBERS obj = new MEMBERS();
            
        //    obj.Email = txtEmail.Text.Trim();
        //    obj.Username = txtUserName.Text.Trim();
        //    obj.Password = txtPassword.Text;
        //    obj.Password_PIN = HashPassword.RandomTransactionPassword();
        //    obj.Fullname = txtFullName.Text.Trim();
        //    obj.Wallet = txtWallet.Text;
        //    obj.Phone = txtPhone.Text;
        //    obj.Country = ddlCountry.SelectedValue.ToString();
        //    obj.UpLine = ddlUpLine.SelectedValue.ToString();
        //    obj.CreateDate = DateTime.Today;
        //    obj.CodeId_Sponsor = Singleton<BITCurrentSession>.Inst.SessionMember.CodeId;
        //    obj.Status = (int)Constants.MEMBER_STATUS.WaitActive;

        //    return obj;
        //}

        //#endregion

        //#region "Register"
        //protected void btnRegister_Click(object sender, EventArgs e)
        //{
        //    MEMBERS_BC ctlMember = new MEMBERS_BC();
        //    MEMBERS obj = GetDataOnForm();

        //    try
        //    {               
        //        // check sponsor acc have execute PH success

        //        bool bSponsorPH = true;
        //        if (Singleton<BITCurrentSession>.Inst.SessionMember.IsAdmin == 1)
        //            bSponsorPH = true;
        //        else
        //        {
        //            bSponsorPH = ctlMember.IsExecutionPHSuccess(Singleton<BITCurrentSession>.Inst.SessionMember.CodeId); 
        //        }
        //        // check exist account
        //        bool bExistAcc = ctlMember.IsExistsItem(obj.Username);

        //        if (bSponsorPH)
        //        {
        //            if (!bExistAcc)
        //            {
        //                // check sponsor PIN balance
        //                WALLET_BC ctlWallet = new WALLET_BC();
        //                var sponsor_wallet = ctlWallet.SelectItemByCodeId(obj.CodeId_Sponsor);
        //                if (sponsor_wallet.PIN_Wallet > Constants.PIN_MINIMUM_FOR_CREATE_ACCOUNT)
        //                {
        //                    // create account
        //                    ctlMember.InsertItem(obj);

        //                    SendMailToRegisterUser(obj.Username, obj.Fullname, obj.Password_PIN, obj.Email);

        //                    lblMessage.Visible = false;
        //                    Response.Redirect("../Admin/Dashboard.aspx");
        //                }
        //                else
        //                {
        //                    lblMessage.Text = "You not enough PIN for create account";
        //                    lblMessage.Visible = true;
        //                }
        //            }
        //            else
        //            {
        //                lblMessage.Text = "Username is already taken";
        //                lblMessage.Visible = true;
        //            }
        //        }
        //        else
        //        {
        //            lblMessage.Text = "You can't create account member, please execute PH transaction!";
        //            lblMessage.Visible = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
            
        //}

        //#endregion

        //#region "Mail"

        //public void SendMailToRegisterUser(string username, string fullname, string passwordPIN, string mailto)
        //{
        //    string sSubject = "VIRGINBTC INFORMATON ACCOUNT";

        //    StringBuilder strBuilder = new StringBuilder();

        //    strBuilder.Append("<html>");
        //    strBuilder.Append("<head></head>");
        //    strBuilder.Append("<body>");
        //    strBuilder.Append("<table>");
        //    strBuilder.AppendLine("<tr><td><b>Hello  " + fullname + "</b><br/></td></tr>");
        //    strBuilder.AppendLine("<tr><td><b>Welcome to VIRGINBTC family. </b><br/></td></tr></td></tr>");
        //    strBuilder.AppendLine("<tr><td><b>Your username is: " + username + "</b><br/></td></tr>");
        //    strBuilder.AppendLine("<tr><td><b>Your transaction password: " + passwordPIN + " </b><br/></td></tr>");
        //    strBuilder.AppendLine("<tr><td><b>Please change the transaction password after first login of you to secure your account. </b><br/></td></tr>");
        //    strBuilder.AppendLine("<tr><td><b>Please contact to your upline or  VIRGINBTC's support to support you everything. </b><br/></td></tr>");
        //    strBuilder.AppendLine("<tr><td><b><br/><br/><br/>Thanks & Best regards</b><br/></td></tr>");
        //    strBuilder.AppendLine("<tr><td><b><br/>VIRGINBTC</b><br/></td></tr>");
        //    strBuilder.Append("</table>");
        //    strBuilder.Append("</body>");
        //    strBuilder.Append("</html>");

        //    Mail.Send(mailto, sSubject, strBuilder.ToString());
        //}

        //#endregion
    }
}