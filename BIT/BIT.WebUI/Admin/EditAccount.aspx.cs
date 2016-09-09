﻿using System;
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
    public partial class EditAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!Singleton<BITCurrentSession>.Inst.isLoginUser)
                {
                    Response.Redirect("~/Admin/Login.aspx");
                }
                else
                {
                    LoadUserInfor();

                    txtEmail.Attributes.Add("readonly", "readonly");
                    txtFullName.Attributes.Add("readonly", "readonly");
                    txtPhone.Attributes.Add("readonly", "readonly");
                    txtWallet.Attributes.Add("readonly", "readonly");
                }
            }
        }

        public void LoadUserInfor()
        {
            int Id;
            if (HttpContext.Current.Session["BIT_MemberID_Edit"] != null)
            {
                Id = Convert.ToInt32(HttpContext.Current.Session["BIT_MemberID_Edit"]);
            }
            else
            {
                Id = Singleton<BITCurrentSession>.Inst.SessionMember.ID;
            }

            MEMBERS_BC ctlMember = new MEMBERS_BC();
            MEMBERS obj = ctlMember.SelectItemByID(Id);

            txtUserName.Text = obj.Username;
            txtEmail.Text = obj.Email;
            txtFullName.Text = obj.Fullname;
            txtPhone.Text = obj.Phone;
            txtWallet.Text = obj.Wallet;
            //txtSysWallet.Text = obj.Sys_Wallet;

            hidCodeId.Value = obj.CodeId;
        }

        public MEMBERS GetDataOnForm()
        {
            MEMBERS obj = new MEMBERS();

            obj.CodeId = hidCodeId.Value;
            obj.Fullname = txtFullName.Text.Trim();
            obj.Phone = txtPhone.Text.Trim();
            obj.Wallet = txtWallet.Text.Trim();
            return obj;
        }

        //public void UpdateProfile()
        //{
        //    MEMBERS_BC ctlMember = new MEMBERS_BC();

        //    MEMBERS obj = GetDataOnForm();

        //    //Tung: Them doan check Password 2
        //    if (obj.Password_PIN == Singleton<BITCurrentSession>.Inst.SessionMember.Password_PIN)
        //    {
        //        ctlMember.UpdateItem(obj);
        //        ShowMessageError(lblMessage, "Update profile member successful", true);
        //    }
        //    else
        //    {
        //        ShowMessageError(lblMessage, "Password PIN is invalid! ", true);
        //    }



        //}

        public void ReloadSeasion()
        {
            var login_info = Singleton<MEMBERS_BC>.Inst.SelectItemByUserName(txtUserName.Text);

            if (login_info != null)
            {
                Singleton<BITCurrentSession>.Inst.SessionMember = login_info;
            }
        }

        public void ShowMessageError(Label lblMsgErr, string sMsgErr = "", bool bVisible = false)
        {
            lblMsgErr.Text = sMsgErr;
            lblMsgErr.Visible = bVisible;
        }

        protected void btnDetail_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (btnUpdate.Text == "Order Update Information (0.1BTC)")
                    {
                        txtEmail.Attributes.Remove("readonly");
                        txtFullName.Attributes.Remove("readonly");
                        txtPhone.Attributes.Remove("readonly");
                        txtWallet.Attributes.Remove("readonly");
                        btnUpdate.Text = "Update";
                    }
                    else
                    {
                        txtEmail.Attributes.Add("readonly", "readonly");
                        txtFullName.Attributes.Add("readonly", "readonly");
                        txtPhone.Attributes.Add("readonly", "readonly");
                        txtWallet.Attributes.Add("readonly", "readonly");
                        btnUpdate.Text = "Order Update Information (0.1BTC)";

                    }
                }
                catch (Exception ex)
                {
                    ShowMessageError(lblMessage, ex.ToString(), true);
                }
            }
        }
    }
}