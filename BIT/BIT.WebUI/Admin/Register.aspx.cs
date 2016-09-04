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
        bool newRegist = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Parameter"] != null)
            {
                newRegist = (Server.UrlDecode(Request.QueryString["Parameter"].ToString()) == "0");
            }
            if (!this.IsPostBack)
            {
                if (newRegist)
                {
                    txtUserName.Attributes.Add("readonly", "readonly");

                    Load_Category();
                }
                else
                {
                    if (!Singleton<BITCurrentSession>.Inst.isLoginUser)
                    {
                        Response.Redirect("../Account/Login.aspx");
                    }
                    else
                    {
                        txtUserName.Attributes.Add("readonly", "readonly");

                        Load_Category();
                    }
                }
            }
        }

        #region "Load danh muc"

        public void Load_Category()
        {
            if (newRegist)
            {
                Load_SNUOC();
            }
            else
            {
                
                Load_SNUOC();
                Load_UpLine(Singleton<BITCurrentSession>.Inst.SessionMember.CodeId);
            }
        }

        public void Load_SNUOC()
        {
            SNUOC_BC ctlNuoc = new SNUOC_BC();

            var lst = ctlNuoc.SelectAllItems();

            ddlCountry.DataSource = lst;
            ddlCountry.DataTextField = "NAME";
            ddlCountry.DataValueField = "CODE";
            ddlCountry.DataBind();

            SetDefaultValueDropDownList(ddlCountry);
        }

        public void Load_UpLine(string CodeId)
        {
            MEMBERS_BC ctlMember = new MEMBERS_BC();

            var lst = ctlMember.SelectUplineOfUserCreate(CodeId);

            //ddlUpLine.DataSource = lst;
            //ddlUpLine.DataTextField = "Username";
            //ddlUpLine.DataValueField = "CodeId";
            //ddlUpLine.DataBind();

            //SetDefaultValueDropDownList(ddlUpLine);
        }

        public void SetDefaultValueDropDownList(DropDownList ddl, string text = "", string value = "")
        {
            ddl.Items.Insert(0, new ListItem { Text = text, Value = value });
        }
        #endregion

        #region "Get data on form"

        public MEMBERS GetDataOnForm()
        {
            MEMBERS obj = new MEMBERS();

            ////obj.CodeId,// @CodeId varchar(250)
            //obj.Username,//@Username	varchar(50)
            //obj.Password ,//@Password	varchar(50)
            //obj.CodeId_Sponsor,//@CodeId_Sponsor	varchar(250)
            //obj.Password_PIN, //@Password_PIN varchar(50)
            //obj.Fullname, //@Fullname	nvarchar(250)
            //obj.Phone,//@Phone	varchar(50)
            //obj.Email,//@Email	varchar(100)
            //obj.Wallet, //@Wallet	nvarchar(250)
            //obj.CreateDate, //@CreateDate	datetime
            //obj.Level ,//@Level  varchar(50)
            //obj.ExistsChild, //@ExistsChild bit
            //obj.Status, //@Status	int
            //obj.Country, //@Country	nvarchar(250)
            //obj.ActiveDate , //@ActiveDate datetime
            //obj.ExpiredDate, //@ExpiredDate datetime
            //obj.IsLock, //@IsLock int
            //obj.Upline //@UpLine varchar(250)


            obj.Username = txtUserName.Text.Trim();
            obj.Password = txtPassword.Text;
            
            if(newRegist)
            {
                obj.CodeId_Sponsor = "0";
                obj.Upline = "BITQUICK24";

            }
            else 
            { 
                obj.CodeId_Sponsor = Singleton<BITCurrentSession>.Inst.SessionMember.CodeId;
                obj.Upline = Singleton<BITCurrentSession>.Inst.SessionMember.Username;
            }

            obj.Password_PIN = txtPassword_PIN.Text;
            obj.Fullname = txtFullName.Text.Trim();
            
            obj.Phone = txtPhone.Text;
            obj.Email = txtEmail.Text.Trim();
            obj.Wallet = txtWallet.Text;
            obj.CreateDate = DateTime.Today;
            obj.Level = "0";
            obj.ExistsChild = false;
            obj.Status = (int)Constants.MEMBER_STATUS.WaitActive;
            obj.Country = ddlCountry.SelectedValue.ToString();
            //obj.ActiveDate = DBNull.Value; //@ActiveDate datetime
            //obj.ExpiredDate = DateTime.Now.AddMonths(1); //@ExpiredDate datetime
            obj.IsLock = 0;

            return obj;
        }

        #endregion

        #region "Register"
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            MEMBERS_BC ctlMember = new MEMBERS_BC();
            MEMBERS obj = GetDataOnForm();

            try
            {
                // check sponsor acc have execute PH success

                bool bSponsorPH = true;
                //if (Singleton<BITQUICKCurrentSession>.Inst.SessionMember.IsAdmin == 1)
                //    bSponsorPH = true;
                //else
                //{
                //    bSponsorPH = ctlMember.IsExecutionPHSuccess(Singleton<BITQUICKCurrentSession>.Inst.SessionMember.CodeId);
                //}
                // check exist account
                bool bExistAcc = ctlMember.IsExistsItem(obj.Username);

                if (bSponsorPH)
                {
                    if (!bExistAcc)
                    {
                        // check sponsor PIN balance
                        //WALLET_BC ctlWallet = new WALLET_BC();
                        //var sponsor_wallet = ctlWallet.SelectItemByCodeId(obj.CodeId_Sponsor);
                        //if (sponsor_wallet.PIN_Wallet > Constants.PIN_MINIMUM_FOR_CREATE_ACCOUNT)
                        //{
                        //    // create account
                        ctlMember.InsertItem(obj);

                        SendMailToRegisterUser(obj.Username, obj.Fullname, obj.Password_PIN, obj.Email);

                        lblMessage.Visible = false;
                        Response.Redirect("../Admin/Dashboard.aspx");
                        //}
                        //else
                        //{
                        //    lblMessage.Text = "You not enough PIN for create account";
                        //    lblMessage.Visible = true;
                        //}
                    }
                    else
                    {
                        lblMessage.Text = "Username is already taken";
                        lblMessage.Visible = true;
                    }
                }
                else
                {
                    lblMessage.Text = "You can't create account member, please execute PH transaction!";
                    lblMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        #region "Mail"

        public void SendMailToRegisterUser(string username, string fullname, string passwordPIN, string mailto)
        {
            string sSubject = "BITQUICK24 INFORMATON ACCOUNT";

            StringBuilder strBuilder = new StringBuilder();

            strBuilder.Append("<html>");
            strBuilder.Append("<head></head>");
            strBuilder.Append("<body>");
            strBuilder.Append("<table>");
            strBuilder.AppendLine("<tr><td><b>Hello  " + fullname + "</b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b>Welcome to VIRGINBTC family. </b><br/></td></tr></td></tr>");
            strBuilder.AppendLine("<tr><td><b>Your username is: " + username + "</b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b>Your transaction password: " + passwordPIN + " </b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b>Please change the transaction password after first login of you to secure your account. </b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b>Please contact to your upline or  BITQUICK24's support to support you everything. </b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b><br/><br/><br/>Thanks & Best regards</b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b><br/>VIRGINBTC</b><br/></td></tr>");
            strBuilder.Append("</table>");
            strBuilder.Append("</body>");
            strBuilder.Append("</html>");

            Mail.Send(mailto, sSubject, strBuilder.ToString());
        }

        #endregion
    }
}