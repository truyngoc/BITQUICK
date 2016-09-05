using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIT.WebUI.Admin
{
    public partial class CreatePHCommunity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDetail_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(uplnModalContent, uplnModalContent.GetType(), "show_bootstrap_modal", "$(function () { $('#" + pnlModalContent.ClientID + "').modal('show'); });", true);
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            
        }
    }
}