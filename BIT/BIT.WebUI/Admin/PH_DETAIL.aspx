<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="PH_DETAIL.aspx.cs" Inherits="BIT.WebUI.Admin.PH_DETAIL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="wrapper">
        <br />
        <!---ss PH-->
        <section class="panel">
            <header class="panel-heading">
                <h3>PH - Provide Help Community</h3>
            </header>
            <div class="panel-body">
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
                                <asp:LinkButton runat="server" ID="btnConfirm" type="submit" class="btn btn-success" Text="Confirm PH" OnClick="btnConfirm_Click" />

                            </td>
                        </tr>
                        <%--</ItemTemplate>
                <FooterTemplate>--%>
                    </table>
                    <%-- </FooterTemplate>
            </asp:DataList>--%>
                </div>
            </div>
        </section>
    </section>
</asp:Content>
