<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="CreateCommandPH_GH.aspx.cs" Inherits="BIT.WebUI.Admin.CreateCommandPH_GH" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="wrapper">
        <br />
        <header class="panel-heading">
            <h3>Create command PH - GH</h3>
        </header>
        <div class="panel-body">

            <div class="row">
                <div class="col-md-6">
                    <h4>PH list</h4>
                    <!--ss Gridview PH-->
                    <section class="panel">
                        <%--<asp:DataList ID="grdListPH" runat="server" class="table table-hover p-table">
                <HeaderTemplate>--%>
                        <table class="table table-hover p-table table-responsive">
                            <tr>
                                <th>No.</th>
                                <th>Sender</th>
                                <th>PH Time</th>
                                <th>Amount</th>
                            </tr>
                            <%--</HeaderTemplate>
                <ItemTemplate>--%>
                            <tr>
                                <td>1
                                </td>
                                <td>AMDIN/0974747709
                                </td>
                                <td>02/09/2016
                            <%--<asp:Label runat="server" ID="lblPHTime" Text=' <%#Eval("Date_Send")%>'></asp:Label>--%>
                                </td>
                                <td>3
                            <%--<asp:Label runat="server" ID="lblAmount" Text=' <%#Eval("Amount")%>'></asp:Label>--%>
                                </td>
                            </tr>
                            <%--</ItemTemplate>
                <FooterTemplate>--%>
                        </table>
                        <%-- </FooterTemplate>
            </asp:DataList>--%>
                    </section>
                    <!--end of ss Gridview PH-->
                </div>

                <div class="col-md-6">
                    <h4>GH list</h4>
                    <!--ss Gridview GH-->
                    <section class="panel">
                        <div class="table-responsive">
                            <%--<asp:DataList ID="grdListPH" runat="server" class="table table-hover p-table">
                <HeaderTemplate>--%>
                            <table class="table table-hover p-table table-responsive">
                                <tr>
                                    <th>No.</th>
                                    <th>Receiver</th>
                                    <th>GH Time</th>
                                    <th>Amount</th>
                                </tr>
                                <%--</HeaderTemplate>
                <ItemTemplate>--%>
                                <tr>
                                    <td>1
                                    </td>
                                    <td>AMDIN/0974747709
                                    </td>
                                    <td>02/09/2016
                            <%--<asp:Label runat="server" ID="lblPHTime" Text=' <%#Eval("Date_Send")%>'></asp:Label>--%>
                                    </td>
                                    <td>3
                            <%--<asp:Label runat="server" ID="lblAmount" Text=' <%#Eval("Amount")%>'></asp:Label>--%>
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
                </div>
            </div>

            <div>
                <asp:Button ID="btnCreateCommand" runat="server" Text="CREATE COMMAND" CssClass="btn btn-primary" />
            </div>

            <div class="row">
                <div class="col-md-12">
                    <h4>Command list</h4>
                    <!--ss Gridview GH-->
                    <section class="panel">
                        <div class="table-responsive">
                            <%--<asp:DataList ID="grdListPH" runat="server" class="table table-hover p-table">
                <HeaderTemplate>--%>
                            <table class="table table-hover p-table table-responsive">
                                <tr>
                                    <th>No.</th>
                                    <th>Sender</th>
                                    <th>Receiver</th>
                                    <th>CreateDate</th>
                                    <th>Amount</th>
                                    <th>Time remaining (hours)</th>
                                    <th>Status</th>
                                </tr>
                                <%--</HeaderTemplate>
                <ItemTemplate>--%>
                                <tr>
                                    <td>1
                                    </td>
                                    <td>AMDIN/0974747709
                                    </td>
                                    <td>BIRAIN/098297983
                                    </td>
                                    <td>02/09/2016
                            <%--<asp:Label runat="server" ID="lblPHTime" Text=' <%#Eval("Date_Send")%>'></asp:Label>--%>
                                    </td>
                                    <td>3
                            <%--<asp:Label runat="server" ID="lblAmount" Text=' <%#Eval("Amount")%>'></asp:Label>--%>
                                    </td>
                                    <td>12</td>
                                    <td>
                                        <span class="label label-primary">Pending
                                <%--<asp:Label runat="server" ID="lblStatus" Text='<%# getStatus(Eval("Status").ToString())%> '></asp:Label>--%>
                                        </span>
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
                </div>
            </div>
        </div>

    </section>
</asp:Content>
