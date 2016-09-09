<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="GHCommunity.aspx.cs" Inherits="BIT.WebUI.Admin.GHCommunity" %>

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
        <header class="panel-heading">
            <h3>GH - Get Help Community</h3>
        </header>
        <div class="panel-body">
            <!--ss Gridview GH-->
            <section class="panel">
                <div class="table-responsive">
                    <asp:GridView ID="grdGH" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="50" OnRowCommand="grdGH_OnRowCommand"
                        OnPageIndexChanging="OnPageIndexChanging" CssClass="table table-hover p-table" UseAccessibleHeader="true" GridLines="None">
                        <Columns>
                            <asp:TemplateField HeaderText="No." ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="GH Time" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreateDate" runat="server" Text='<%# Eval("CreateDate" , "{0:dd/MM/yyyy HH:mm:ss}") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# StatusToString((int)Eval("Status")) %>' CssClass='<%# CssStatus((int)Eval("Status")) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="btnDetail" type="submit" class="btn btn-success" Text="Details" CommandArgument='<%# Eval("ID") %>' CommandName="CmdDetail" Visible='<%# VisibleDetailButton((int)Eval("ID")) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </section>
            <!--end of ss Gridview GH-->
        </div>
    </section>

</asp:Content>
