<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="CreatePHCommunity.aspx.cs" Inherits="BIT.WebUI.Admin.CreatePHCommunity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Scripts/jquery.validate.min.js"></script>
    <script src="../Scripts/jquery.validate.unobtrusive.min.js"></script>

    <style>
        /* wider than 768px fixed width */
        @media screen and (min-width: 768px) {

            .modal-dialog {
                width: 975px;
            }
        }

        /*less than 768px the modal will fill the width which is then set to auto*/
        .mydialog {
            width: 75%;
        }

        /* can giua cho table tren man hinh */
        .center-table {
            margin: auto 0 auto !important;
            float: none !important;
        }

        .fdb-panel-header-10 {
            color: #fff; /* mau chu */
            background-color: #428bca; /* mau nen */
            border-color: #428bca;
            border-top-left-radius: 4px; /* bo vien tron */
            border-top-right-radius: 4px;
            padding: 10px; /* do cao cua title */
        }

        .fdb-panel-header-15 {
            color: #fff; /* mau chu */
            background-color: #428bca; /* mau nen */
            border-color: #428bca;
            border-top-left-radius: 4px; /* bo vien tron */
            border-top-right-radius: 4px;
            padding: 15px; /* do cao cua title */
        }
    </style>

    <section class="wrapper">
        <br />
        <!---ss PH-->
        <section class="panel">
            <header class="panel-heading">
                <h3>PH - Provide Help Community</h3>
            </header>
            <div class="panel-body">
                <div class="form">
                    <div class="form-group col-lg-12">
                        <div class="col-md-6 col-md-offset-3">
                            <label class="control-label col-lg-7" for="firstname">Available PH Amount: </label>
                            <div class="col-lg-3">
                                <span class="badge">
                                    <asp:Label runat="server" ID="lblRemainAmount"></asp:Label>
                                    BTC
                                </span>

                                &nbsp;<img src="../images/bitplusOrange.png" style="width: 24px; height: 24px;" />
                            </div>


                        </div>

                        <div class="col-md-6 col-md-offset-3 margin-top-05">
                            <label class="control-label col-lg-7">Transaction Pass:</label>
                            <div class="col-lg-5">
                                <asp:TextBox runat="server" ID="txtTransPass" TextMode="Password" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group col-lg-12">
                        <div style="text-align: center;" class="col-lg-12">
                            <asp:Button runat="server" ID="btnCreatePH" class="btn btn-info" Text="Create PH" OnClick="btnCreatePH_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!---End Of ss PH-->
        <!--ss Gridview PH-->
        <section class="panel">
            <div class="form">
                <asp:GridView ID="grdPH" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="30"
                    OnPageIndexChanging="OnPageIndexChanging" CssClass="table table-hover p-table">
                    <Columns>
                        <asp:TemplateField HeaderText="No." ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="PH Time" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblCreateDate" runat="server" Text='<%# Eval("CreateDate" , "{0:dd/MM/yyyy HH:mm:ss}") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Text='<%# StatusToString((int)Eval("Status")) %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="btnDetail" type="submit" class="btn btn-success" Text="Details" OnClick="btnDetail_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </section>
        <!--end of ss Gridview PH-->
    </section>
</asp:Content>
