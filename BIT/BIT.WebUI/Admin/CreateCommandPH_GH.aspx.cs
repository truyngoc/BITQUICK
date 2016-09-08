using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Transactions;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using BIT.Objects;
using BIT.Controller;
using BIT.Common;

namespace BIT.WebUI.Admin
{
    public partial class CreateCommandPH_GH : System.Web.UI.Page
    {
        #region "property"
        public List<PH_Info> ListPH
        {
            get
            {
                if (HttpContext.Current.Session["CreateCommandPH_GH_LIST_PH"] != null)
                {
                    return HttpContext.Current.Session["CreateCommandPH_GH_LIST_PH"] as List<PH_Info>;
                }
                return null;
            }
            set { HttpContext.Current.Session["CreateCommandPH_GH_LIST_PH"] = value; }
        }

        public List<GH_Info> ListGH
        {
            get
            {
                if (HttpContext.Current.Session["CreateCommandPH_GH_LIST_GH"] != null)
                {
                    return HttpContext.Current.Session["CreateCommandPH_GH_LIST_GH"] as List<GH_Info>;
                }
                return null;
            }
            set { HttpContext.Current.Session["CreateCommandPH_GH_LIST_GH"] = value; }
        }

        public List<GH_Info> ListAdminGH
        {
            get
            {
                if (HttpContext.Current.Session["CreateCommandPH_GH_LIST_ADMIN_GH"] != null)
                {
                    return HttpContext.Current.Session["CreateCommandPH_GH_LIST_ADMIN_GH"] as List<GH_Info>;
                }
                return null;
            }
            set { HttpContext.Current.Session["CreateCommandPH_GH_LIST_ADMIN_GH"] = value; }
        }

        public List<GH_Info> ListAdminGH_Selected
        {
            get
            {
                if (HttpContext.Current.Session["CreateCommandPH_GH_LIST_ADMIN_GH_SELECTED"] != null)
                {
                    return HttpContext.Current.Session["CreateCommandPH_GH_LIST_ADMIN_GH_SELECTED"] as List<GH_Info>;
                }
                return null;
            }
            set { HttpContext.Current.Session["CreateCommandPH_GH_LIST_ADMIN_GH_SELECTED"] = value; }
        }

        public List<GH_Info> ListAdminGH_FINAL
        {
            get
            {
                if (HttpContext.Current.Session["CreateCommandPH_GH_LIST_ADMIN_GH_FINAL"] != null)
                {
                    return HttpContext.Current.Session["CreateCommandPH_GH_LIST_ADMIN_GH_FINAL"] as List<GH_Info>;
                }
                return null;
            }
            set { HttpContext.Current.Session["CreateCommandPH_GH_LIST_ADMIN_GH_FINAL"] = value; }
        }

        public COMMAND COMMAND
        {
            get
            {
                if (HttpContext.Current.Session["CreateCommandPH_COMMAND"] != null)
                {
                    return HttpContext.Current.Session["CreateCommandPH_COMMAND"] as COMMAND;
                }
                return null;
            }
            set { HttpContext.Current.Session["CreateCommandPH_COMMAND"] = value; }
        }

        public List<COMMAND_DETAIL> LIST_COMMAND_DETAIL
        {
            get
            {
                if (HttpContext.Current.Session["CreateCommandPH_LIST_COMMAND_DETAIL"] != null)
                {
                    return HttpContext.Current.Session["CreateCommandPH_LIST_COMMAND_DETAIL"] as List<COMMAND_DETAIL>;
                }
                return null;
            }
            set { HttpContext.Current.Session["CreateCommandPH_LIST_COMMAND_DETAIL"] = value; }
        }
        #endregion

        private PH_BC ctlPH = new PH_BC();
        private GH_BC ctlGH = new GH_BC();
        public COMMAND command;
        public List<COMMAND_DETAIL> _ListCommand;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadListPH();
                LoadListGH();
                LoadListAdminGH();
            }
        }

        #region "Load list"
        public List<PH_Info> GetListPH()
        {
            var numberPH = txtNumberPH.Text == string.Empty ? 0 : Convert.ToInt32(txtNumberPH.Text);
            var lstPH = ctlPH.SelectItemsByNumber(numberPH);

            return lstPH;
        }

        public void LoadListPH()
        {
            if (this.ListPH == null)
            {
                var numberPH = txtNumberPH.Text == string.Empty ? 0 : Convert.ToInt32(txtNumberPH.Text);
                this.ListPH = ctlPH.SelectItemsByNumber(numberPH);
            }


            lblTotalAmountPH.Text = ListPH.Sum(m => m.Amount).Value.ToString();

            grdPH.DataSource = ListPH;
            grdPH.DataBind();

        }

        public void LoadListGH()
        {
            if (this.ListGH == null)
            {
                this.ListGH = ctlGH.SelectWaitingGH();
            }

            lblTotalAmountGH.Text = ListGH.Sum(m => m.Amount).Value.ToString();

            grdGH.DataSource = ListGH;
            grdGH.DataBind();
        }

        public void LoadListAdminGH()
        {
            if (this.ListAdminGH == null)
            {
                this.ListAdminGH = ctlGH.SelectAdminMemberGH();
            }

            grdAdminList.DataSource = ListAdminGH;
            grdAdminList.DataBind();
        }


        public List<GH_Info> GetListAdminSelectedForGH()
        {
            var lst = new List<GH_Info>();

            foreach (GridViewRow row in grdAdminList.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chk = (row.Cells[4].FindControl("chkIsSelected") as CheckBox);

                    if (chk.Checked)
                    {
                        var oGHInfo = new GH_Info();
                        Label username = row.Cells[1].FindControl("lblUserName") as Label;
                        Label createdate = row.Cells[2].FindControl("lblCreateDate") as Label;
                        TextBox amount = row.Cells[3].FindControl("txtAmount") as TextBox;
                        HiddenField codeid = row.Cells[5].FindControl("hidCodeId") as HiddenField;

                        //oGHInfo.CreateDate = DateTime.ParseExact(row.Cells[2].Text, "dd/MM/yyyy HH:mm:ss", null);                        

                        oGHInfo.CodeId = codeid.Value;
                        oGHInfo.CreateDate = DateTime.ParseExact(createdate.Text, "dd/MM/yyyy HH:mm:ss", null);
                        oGHInfo.Username = username.Text;
                        oGHInfo.Amount = (amount.Text == string.Empty ? 0 : Convert.ToDecimal(amount.Text));
                        oGHInfo.CurrentAmount = 0;
                        oGHInfo.Status = 0;

                        lst.Add(oGHInfo);
                    }
                }
            }

            return lst;
        }

        public void TranferAdminToGH()
        {
            if (this.ListAdminGH_Selected == null)
            {
                ListAdminGH_Selected = GetListAdminSelectedForGH();
            }

            // dua len GH
            foreach (var o in ListAdminGH_Selected)
            {
                ListGH.Add(o);

                // xoa duoi list admin gh
                var oFind = ListAdminGH.Where(m => m.CodeId == o.CodeId).FirstOrDefault();
                if (oFind != null)
                {
                    ListAdminGH.Remove(oFind);
                }
            }

            // bind lai 2 list
            LoadListGH();

            LoadListAdminGH();

            // reset selected list
            ListAdminGH_Selected = null;
        }

        public void ResetAllSessionList()
        {
            this.ListPH = null;
            this.ListGH = null;
            this.ListAdminGH = null;
            this.ListAdminGH_Selected = null;
            this.ListAdminGH_FINAL = null;
            this.COMMAND = null;
            this.LIST_COMMAND_DETAIL = null;
            
            LoadListPH();
            LoadListGH();
            LoadListAdminGH();
            ResetCommandList();
        }

        public void ResetCommandList()
        {
            grdCommandDetails.DataSource = null;
            grdCommandDetails.DataBind();
        }

        public void BindCommand(List<COMMAND_DETAIL> lstDetail)
        {
            grdCommandDetails.DataSource = lstDetail;
            grdCommandDetails.DataBind();
        }
        #endregion


        #region "Paging gridview"
        protected void grdPH_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPH.PageIndex = e.NewPageIndex;
            LoadListPH();
        }

        protected void grdGH_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPH.PageIndex = e.NewPageIndex;
            LoadListGH();
        }

        protected void grdAdminList_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAdminList.PageIndex = e.NewPageIndex;
            LoadListAdminGH();
        }

        protected void grdCommandDetails_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //if (_ListCommand != null)
            //{
            //    grdCommandDetails.PageIndex = e.NewPageIndex;
            //    BindCommand(_ListCommand);
            //}            
        }
        #endregion

        #region "Utils"
        public T DeepCopy<T>(T other)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, other);
                ms.Position = 0;
                return (T)formatter.Deserialize(ms);
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
                default:
                    return "label label-primary";
            }
        }

        #endregion

        #region "button click"
        protected void btnLoadPHbyNumber_Click(object sender, EventArgs e)
        {
            // reset list PH
            ListPH = null;

            // load lai theo so luong PH nhap
            LoadListPH();
        }

        protected void btnTranferToGHList_Click(object sender, EventArgs e)
        {
            TranferAdminToGH();
        }

        protected void btnResetAllList_Click(object sender, EventArgs e)
        {
            ResetAllSessionList();
        }

        protected void btnCreateCommand_Click(object sender, EventArgs e)
        {
            // lay danh sach admin GH
            var _listGH_Admin = ListGH.Where(m => System.Text.RegularExpressions.Regex.IsMatch(m.CodeId, "99.*")).ToList();
            this.ListAdminGH_FINAL = _listGH_Admin;

            // danh sach PH - GH
            var _listPH = DeepCopy<List<PH_Info>>(ListPH);
            var _listGH = DeepCopy<List<GH_Info>>(ListGH);

            this.command = new COMMAND();
            this._ListCommand = new List<COMMAND_DETAIL>();

            // kiem tra danh sach PH, GH 
            if (_listPH.Count > 0 && _listGH.Count > 0)
            {
                XepLenh(_listPH, _listGH, ref command, ref _ListCommand);

                BindCommand(_ListCommand);

                // gan session
                this.COMMAND = command;
                this.LIST_COMMAND_DETAIL = _ListCommand;

            }
            else
            {
                // ko co thi dua ra thong bao
                TNotify.Alerts.Danger("List GH or PH is empty", true);
            }
        }
        protected void btnSaveCommand_Click(object sender, EventArgs e)
        {
            try
            {

                var ctlCommand = new COMMAND_BC();

                if (this.COMMAND != null && this.LIST_COMMAND_DETAIL.Count > 0)
                {
                    ctlCommand.InsertWithTransaction(COMMAND, LIST_COMMAND_DETAIL, ListAdminGH_FINAL);

                    ResetAllSessionList();

                    TNotify.Toastr.Success("Create command PH - GH successfull", "Create command PH - GH", TNotify.NotifyPositions.toast_top_full_width, true);
                }
                else
                {
                    throw new Exception("Not have command detail");
                }

            }
            catch (Exception ex)
            {
                TNotify.Alerts.Danger(ex.Message, true);
            }

        }
        #endregion

        public void XepLenh(List<PH_Info> _ListPH, List<GH_Info> _ListGH, ref COMMAND command, ref List<COMMAND_DETAIL> _ListCommand)
        {
            var username = Singleton<BITCurrentSession>.Inst.SessionMember.Username;
            DateTime _datecreate = DateTime.Now;

            // tao lenh master
            command = new COMMAND { DateCreate = _datecreate, UserCreate = username, CommandCode = DateTime.Today.ToShortDateString().Replace(@"/", "_") };

            // tao lenh child
            COMMAND_DETAIL cmd_detail;

            foreach (var p in _ListPH)
            {
                // kiem tra con GH de cho nua ko -> neu ko con thi dung lai
                int iGH_remaining = _ListGH.Where(g => g.Amount != g.CurrentAmount).Count();
                // lap den khi PH cho di het (currentAmount = 0)
                while (p.CurrentAmount != 0 && iGH_remaining > 0)
                {
                    foreach (var g in _ListGH)
                    {
                        // chi duyet tren nhung thang GH chua nhan du                       
                        if (g.Amount != g.CurrentAmount)
                        {
                            if (g.CurrentAmount == 0)
                            {
                                // duyet lan dau
                                if (p.CurrentAmount - g.Amount <= 0)
                                {
                                    // TH: PH thieu cho GH                                                                      
                                    // ----------------- //
                                    cmd_detail = new COMMAND_DETAIL
                                    {
                                        CodeId_From = p.CodeId
                                        ,
                                        CodeId_To = g.CodeId
                                        ,
                                        DateCreate = _datecreate
                                        ,
                                        Amount = p.CurrentAmount
                                        ,
                                        Status = (int)Constants.COMMAND_STATUS.Pending
                                        ,
                                        PH_ID = p.ID
                                        ,
                                        GH_ID = g.ID
                                    };
                                    // ----------------- //                                    
                                    _ListCommand.Add(cmd_detail);


                                    if (g.CurrentAmount == 0)
                                    {
                                        if (g.Amount - p.CurrentAmount != 0)
                                        {
                                            g.CurrentAmount = g.Amount - p.CurrentAmount;   // neu PH voi 1 GH moi
                                        }
                                        else
                                        {
                                            g.CurrentAmount = g.Amount;
                                        }
                                    }
                                    else
                                        g.CurrentAmount = g.Amount - p.Amount;  // neu PH het luon 1 lan

                                    p.CurrentAmount = 0;

                                    break;

                                }
                                else
                                {
                                    // TH: PH thua cho GH
                                    // ----------------- //
                                    cmd_detail = new COMMAND_DETAIL
                                    {
                                        CodeId_From = p.CodeId
                                        ,
                                        CodeId_To = g.CodeId
                                        ,
                                        DateCreate = _datecreate
                                        ,
                                        Amount = g.Amount
                                        ,
                                        Status = (int)Constants.COMMAND_STATUS.Pending
                                        ,
                                        PH_ID = p.ID
                                        ,
                                        GH_ID = g.ID
                                    };
                                    // ----------------- //                                    
                                    _ListCommand.Add(cmd_detail);


                                    g.CurrentAmount = g.Amount;

                                    if (p.CurrentAmount != p.Amount)
                                        p.CurrentAmount = p.CurrentAmount - g.Amount;   // neu da PH roi thi lay current - g.amount
                                    else
                                        p.CurrentAmount = p.Amount - g.Amount;  // neu chua PH
                                }
                            }
                            else
                            {
                                // duyet tiep neu chua gh du?
                                if (p.CurrentAmount - g.CurrentAmount <= 0)
                                {
                                    // van chua du
                                    // ----------------- //
                                    cmd_detail = new COMMAND_DETAIL
                                    {
                                        CodeId_From = p.CodeId
                                        ,
                                        CodeId_To = g.CodeId
                                        ,
                                        DateCreate = _datecreate
                                        ,
                                        Amount = p.CurrentAmount
                                        ,
                                        Status = (int)Constants.COMMAND_STATUS.Pending
                                        ,
                                        PH_ID = p.ID
                                        ,
                                        GH_ID = g.ID
                                    };
                                    // ----------------- //
                                    _ListCommand.Add(cmd_detail);

                                    p.CurrentAmount = 0;
                                    g.CurrentAmount = g.CurrentAmount - p.Amount;

                                    break;
                                }
                                else
                                {
                                    // du roi
                                    // ----------------- //
                                    cmd_detail = new COMMAND_DETAIL
                                    {
                                        CodeId_From = p.CodeId
                                        ,
                                        CodeId_To = g.CodeId
                                        ,
                                        DateCreate = _datecreate
                                        ,
                                        Amount = g.CurrentAmount
                                        ,
                                        Status = (int)Constants.COMMAND_STATUS.Pending
                                        ,
                                        PH_ID = p.ID
                                        ,
                                        GH_ID = g.ID
                                    };
                                    // ----------------- //
                                    _ListCommand.Add(cmd_detail);

                                    p.CurrentAmount = p.Amount - g.CurrentAmount;
                                    g.CurrentAmount = g.Amount;

                                    break;
                                }
                            }
                        }
                    }
                    iGH_remaining = _ListGH.Where(g => g.Amount != g.CurrentAmount).Count();
                }

            }
        }

    }
}