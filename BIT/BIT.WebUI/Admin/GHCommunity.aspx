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
                <h3>PH - Provide Help Community</h3>
            </header>
            <div class="panel-body">
                
        <!--ss Gridview GH-->
        <section class="panel">
            <div class="table-responsive">
                <%--<asp:DataList ID="grdListPH" runat="server" class="table table-hover p-table">
                <HeaderTemplate>--%>
                <table class="table table-hover p-table table-responsive">
                    <tr>
                        <th>No.</th>
                        <th>GH Time</th>
                        <th>Amount</th>
                        <th>Status</th>
                        <th></th>
                    </tr>
                    <%--</HeaderTemplate>
                <ItemTemplate>--%>
                    <tr>
                        <td>1
                        </td>
                        <td>02/09/2016
                            <%--<asp:Label runat="server" ID="lblPHTime" Text=' <%#Eval("Date_Send")%>'></asp:Label>--%>
                        </td>
                        <td>3
                            <%--<asp:Label runat="server" ID="lblAmount" Text=' <%#Eval("Amount")%>'></asp:Label>--%>
                        </td>
                        <td>
                            <span class="label label-primary">Pending
                                <%--<asp:Label runat="server" ID="lblStatus" Text='<%# getStatus(Eval("Status").ToString())%> '></asp:Label>--%>
                            </span>
                        </td>
                        <td>
                            <a href="#">
                                <asp:LinkButton runat="server" ID="btnDetail" type="submit" class="btn btn-success" Text="Details" OnClick="btnDetail_Click" />
                                <%--<asp:LinkButton runat="server" ID="btnReceive" Visible='<%# enableGH(Eval("Date_send"),Eval("Status")) %>' OnClick="btnReceive_Click" CommandArgument='<%# Eval("ID") %>' type="submit" class="btn btn-success" Text="Receive" />--%>
                            </a>
                        </td>
                    </tr>
                    <%--</ItemTemplate>
                <FooterTemplate>--%>
                </table>
                <%-- </FooterTemplate>
            </asp:DataList>--%>
            </div>
        </section>
        <!--end of ss Gridview GH-->
        <div class="pagination"></div>
                </div>
    </section>








    <!-- PH community details -->
    <asp:Panel ID="pnlModalContent" runat="server" CssClass="modal fade in" TabIndex="-1" role="dialog" aria-labelledby="myLabel">
        <div class="modal-dialog mydialog" role="document">
            <div class="modal-content">

                <asp:UpdatePanel ID="uplnModalContent" runat="server">
                    <ContentTemplate>
                        <div class="modal-header fdb-panel-header-10">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title" id=" myLabel ">List command for this GH</h4>
                        </div>
                        <div class="modal-body">
                            <div class="table-responsive">
                                <%--<asp:DataList ID="grdListPH" runat="server" class="table table-hover p-table">
                <HeaderTemplate>--%>
                                <table class="table">
                                    <tr>
                                        <th>No.</th>
                                        <th>DateCreated</th>
                                        <th>Amount</th>
                                        <th>Receiver</th>
                                        <th>Time remaining (hours)</th>
                                        <th>Transaction</th>
                                        <th>Status</th>
                                        <th></th>
                                    </tr>
                                    <%--</HeaderTemplate>
                <ItemTemplate>--%>
                                    <tr>
                                        <td>1
                                        </td>
                                        <td>02/09/2016
                            <%--<asp:Label runat="server" ID="lblPHTime" Text=' <%#Eval("Date_Send")%>'></asp:Label>--%>
                                        </td>
                                        <td>3
                            <%--<asp:Label runat="server" ID="lblAmount" Text=' <%#Eval("Amount")%>'></asp:Label>--%>
                                        </td>
                                        <td>AMDIN/0974747709
                                        </td>
                                        <td>10
                                        </td>
                                        <td>
                                            <%--<asp:TextBox ID="txtTransaction" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ErrorMessage="Enter transaction" ControlToValidate="txtTransaction" runat="server" ForeColor="#cc0066" Text="Enter transaction" Display="Dynamic" ValidationGroup="detailPH" />--%>
                                            <asp:HyperLink ID="linkTransaction" runat="server" NavigateUrl="https://blockchain.info/tx/7c2c5e046783d5cae6140b25569529bba4c3a36802db20af7ea860b9c07a5656" Text="view"></asp:HyperLink>
                                        </td>
                                        <td>
                                            <span class="label label-primary">Pending
                                <%--<asp:Label runat="server" ID="lblStatus" Text='<%# getStatus(Eval("Status").ToString())%> '></asp:Label>--%>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:LinkButton runat="server" ID="btnConfirm" type="submit" class="btn btn-success" Text="Confirm GH" OnClick="btnConfirm_Click" />

                                        </td>
                                    </tr>
                                    <%--</ItemTemplate>
                <FooterTemplate>--%>
                                </table>
                                <%-- </FooterTemplate>
            </asp:DataList>--%>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button class="btn" data-dismiss="modal">Close</button>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnConfirm" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
