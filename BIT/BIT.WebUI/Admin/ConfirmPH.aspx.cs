﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIT.Objects;
using BIT.Common;
using BIT.Controller;

namespace BIT.WebUI.Admin
{
    public partial class ConfirmPH : System.Web.UI.Page
    {        
        public int COMMAND_DETAIL_ID
        {
            get
            {
                return (int)ViewState["COMMAND_DETAIL_ID"];
            }
            set
            {
                ViewState["COMMAND_DETAIL_ID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["PH_DETAIL_COMMAND_DETAIL_ID"] != null)
                {
                    LoadDataToForm();
                    Session["PH_DETAIL_COMMAND_DETAIL_ID"] = null;
                }
                else
                {
                    //Response.Redirect("PH_DETAIL");
                    btnConfirmPH.Enabled = false;
                    TNotify.Toastr.Information("Your session working is expired, back to PH detail for continue", "Notify", TNotify.NotifyPositions.toast_top_full_width, true);
                }

            }
        }

        public void LoadDataToForm()
        {
            if (Session["PH_DETAIL_COMMAND_DETAIL_ID"] != null)
            {
                var ctlCmdDetail = new COMMAND_DETAIL_BC();
                var ctlMem = new MEMBERS_BC();
                int CMD_DETAIL_ID = Convert.ToInt32(Session["PH_DETAIL_COMMAND_DETAIL_ID"]);

                this.COMMAND_DETAIL_ID = CMD_DETAIL_ID;
                // lay command detail ID
                COMMAND_DETAIL cmdDetail = ctlCmdDetail.SelectItem(CMD_DETAIL_ID);
                MEMBERS member = ctlMem.SelectItem(cmdDetail.CodeId_To);

                imgGHWallet.ImageUrl = string.Format("http://chart.googleapis.com/chart?chs=200x200&cht=qr&chl={0}", member.Wallet);
                lblGHWallet.Text = "Address: " + member.Wallet;
                txtTotalAmount.Text = cmdDetail.Amount.ToString();                
            }
        }

        protected void btnConfirmPH_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var ctlMember = new MEMBERS_BC();

                string codeId = Singleton<BITCurrentSession>.Inst.SessionMember.CodeId;

                string passPIN = txtPasswordPIN.Text;
                if (ctlMember.CheckPasswordPIN(codeId, passPIN))
                {
                    var ctlCommandDetail = new COMMAND_DETAIL_BC();
                    try
                    {
                        ctlCommandDetail.ConfirmPH(new COMMAND_DETAIL { ID = COMMAND_DETAIL_ID, TransactionId = txtTransaction.Text, ConfirmPH = true, DateConfirmPH = DateTime.Now, Status = (int)Constants.COMMAND_STATUS.PH_Success });

                        TNotify.Toastr.Success("Confirm PH successfull", "Confirm PH", TNotify.NotifyPositions.toast_top_full_width, true);

                        Response.Redirect("PH_DETAIL");
                    }
                    catch (System.Threading.ThreadAbortException ex)
                    {
                        // C2: catch exception nay khi redirect
                    }
                    catch (Exception ex)
                    {
                        TNotify.Alerts.Danger(ex.ToString(), true);
                    }
                }
                else
                {
                    // thong bao password pin ko dung
                    TNotify.Alerts.Warning("Password PIN is not valid", true);
                }
                
            }            
        }
    }
}