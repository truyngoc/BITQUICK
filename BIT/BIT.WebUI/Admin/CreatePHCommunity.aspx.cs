using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIT.Objects;
using BIT.Controller;
using BIT.Common;

namespace BIT.WebUI.Admin
{
    public partial class CreatePHCommunity : System.Web.UI.Page
    {
        private PACKAGE_TRANSACTION_BC ctlPack = new PACKAGE_TRANSACTION_BC();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string codeId = Singleton<BITCurrentSession>.Inst.SessionMember.CodeId;
                // load so BIT toi da cua thang nay theo goi dang ky (lay goi dk gan nhat)
                // neu chua dang ky goi thi thong bao
                if (ctlPack.IsPackageExpire(codeId))
                {
                    var package = ctlPack.SelectItemByCodeId(codeId);

                    lblRemainAmount.Text = package.PACKAGEID.ToString();
                }
                else
                {
                    // thong bao het han hoac chua dang ky goi
                    TNotify.Alerts.Warning("Package is not register or account is expired",true);
                }
            }            
        }

        protected void btnDetail_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(uplnModalContent, uplnModalContent.GetType(), "show_bootstrap_modal", "$(function () { $('#" + pnlModalContent.ClientID + "').modal('show'); });", true);
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConfirmPH");
        }

        protected void btnCreatePH_Click(object sender, EventArgs e)
        {
            var ctlPH = new PH_BC();
            var ctlMember = new MEMBERS_BC();

            string codeId = Singleton<BITCurrentSession>.Inst.SessionMember.CodeId;
            string passwordPIN = Singleton<BITCurrentSession>.Inst.SessionMember.Password_PIN;

            // check xem goi dang ky da het han chua
            if (ctlPack.IsPackageExpire(codeId))
            {
                // check quota
                if (ctlPH.GetNumberPH(codeId) < 0)
                {
                    // tao lenh PH
                    // check transaction pass co dung ko
                    if (ctlMember.CheckPasswordPIN(codeId,passwordPIN))
                    {
                        // Insert PH

                        TNotify.Toastr.Success("Create PH successfull", "Create PH", TNotify.NotifyPositions.toast_top_full_width, true);
                    }
                    else
                    {
                        // thong bao password pin ko dung
                        TNotify.Alerts.Warning("Password PIN is not valid", true);
                    }
                }
                else
                { 
                    // thong bao het quota PH trong ngay
                    TNotify.Alerts.Warning("Only have PH once perday", true);
                }
            }
            else
            { 
                // thong bao het han hoac chua dang ky goi
                TNotify.Alerts.Warning("Package is not register or account is expired", true);
            }
        }

        private PH GetPH()
        {
            var oPH = new PH();

            oPH.CodeId = Singleton<BITCurrentSession>.Inst.SessionMember.CodeId;;
            oPH.Amount = Convert.ToDecimal(lblRemainAmount.Text);
            oPH.CreateDate = DateTime.Now;
            oPH.Status = (int)Constants.PH_STATUS.Waiting;

            return oPH;
        }
    }
}