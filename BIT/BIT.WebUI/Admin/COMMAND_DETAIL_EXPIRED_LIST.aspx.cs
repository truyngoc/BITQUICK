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
    public partial class COMMAND_DETAIL_EXPIRED_LIST : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LIST_MEMBERS = null;

                LoadListMember();
                LoadCommandDetails();
            }
        }

        #region "Utils"              

        public List<MEMBERS> LIST_MEMBERS
        {
            get
            {
                if (HttpContext.Current.Session["COMMAND_DETAIL_EXPIRED_LIST"] != null)
                {
                    return HttpContext.Current.Session["COMMAND_DETAIL_EXPIRED_LIST"] as List<MEMBERS>;
                }
                return null;
            }
            set { HttpContext.Current.Session["COMMAND_DETAIL_EXPIRED_LIST"] = value; }
        }

        public void LoadListMember()
        {
            if (this.LIST_MEMBERS == null)
            {
                this.LIST_MEMBERS = Singleton<MEMBERS_BC>.Inst.SelectAllItems();
            }
        }

        public void LoadCommandDetails()
        {
            var ctlCmdDetail = new COMMAND_DETAIL_BC();
            var lstDetail = ctlCmdDetail.SelectItemsExpired();

            if (lstDetail != null && lstDetail.Count > 0)
            {
                grdCommandDetails.DataSource = lstDetail;
                grdCommandDetails.DataBind();
            }
            else
            {
                grdCommandDetails.DataSource = null;
                grdCommandDetails.DataBind();
            }
        }
       
        public string StatusToString(int status)
        {
            switch (status)
            {
                case (int)Constants.COMMAND_STATUS.Pending:
                    return Constants.COMMAND_STATUS.Pending.ToString();
                case (int)Constants.COMMAND_STATUS.PH_Success:
                    return Constants.COMMAND_STATUS.PH_Success.ToString();
                case (int)Constants.COMMAND_STATUS.Success:
                    return Constants.COMMAND_STATUS.Success.ToString();
                case (int)Constants.COMMAND_STATUS.Expired:
                    return Constants.COMMAND_STATUS.Expired.ToString();
                default:
                    return string.Empty;
            }
        }

        public string CssStatus(int status)
        {
            switch (status)
            {
                case (int)Constants.COMMAND_STATUS.Pending:
                    return "label label-primary";
                case (int)Constants.COMMAND_STATUS.PH_Success:
                    return "label label-info";
                case (int)Constants.COMMAND_STATUS.Success:
                    return "label label-danger";
                case (int)Constants.COMMAND_STATUS.Expired:
                    return "label label-warning";
                default:
                    return "label label-primary";
            }
        }

        public string AccountBriefInfoByCodeId(string CodeId)
        {
            var user = LIST_MEMBERS.Where(m => m.CodeId == CodeId).SingleOrDefault();
            string briefInfo = user.Username + "/" + user.Phone;

            return briefInfo;
        }
        #endregion

        protected void grdCommandDetails_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            grdCommandDetails.PageIndex = e.NewPageIndex;
            LoadCommandDetails();

        }
       
    }
}