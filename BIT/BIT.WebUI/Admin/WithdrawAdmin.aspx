<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master"
    AutoEventWireup="true" CodeBehind="WithdrawAdmin.aspx.cs" Inherits="BIT.WebUI.Admin.WithdrawAdmin" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="wrapper">
        <br />
        <section class="panel">
            <header class="panel-heading">
                <h3>Withdraw Manager</h3>
            </header>
            <div class="form">
                <form enctype="multipart/form-data" class="cmxform form-horizontal tasi-form">
                    <div class="form-group col-lg-12">
                        <div class="col-md-6 col-md-offset-3">
                            <asp:Label ID="lblIDCode" runat="server" Visible ="false"></asp:Label>
                            <label class="control-label col-lg-5" for="firstname">Scan QR code or insert wallet address below</label>
                            <div class="col-lg-5">
                                <span class="badge">
                                    <asp:Image ID="imgQRCode" Width="200" Height="200" runat="server" />
                                </span>
                                <asp:Label runat="server" ID="lblSyswallet"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-6 col-md-offset-3">
                            <label class="control-label col-lg-5" for="firstname">Amount </label>
                            <div class="col-lg-5">
                                <asp:TextBox runat="server" ID="txtAmount" TextMode="Number"></asp:TextBox>
                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtAmount" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>--%>
                            </div>
                        </div>
                        <div class="col-md-6 col-md-offset-3">
                            <label class="control-label col-lg-5" for="firstname">Transaction BlockChain</label>
                            <div class="col-lg-5">
                                <asp:TextBox runat="server" ID="txtTrans"></asp:TextBox><asp:LinkButton class="fa fa-search" runat="server" ID="lnkCheckTrans" OnClick="lnkCheckTrans_Click"></asp:LinkButton>
                            </div>
                        </div>
                        <div class="col-md-6 col-md-offset-3">
                            <asp:Label runat="server" ID="lblError" class="control-label col-lg-12" for="firstname" ForeColor="Red"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group col-lg-12">
                        <div style="text-align: center;" class="col-lg-12">
                            <asp:Button runat="server" ID="btnSave" class="btn btn-info" Text="Save" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </form>
            </div>
            <label></label>
        </section>
        <section class="panel">
            <header class="panel-heading">
                <h3>ReCharge List</h3>
            </header>
            <asp:DataList runat="server" ID="dtlRecharge" class="table table-hover p-table">
                <HeaderTemplate>
                    <table class="table table-hover p-table">
                        <thead>
                            <tr>
                                <td>ID</td>
                                <td>Create Date</td>
                                <td>Username</td>
                                <td>Receive Wallet</td>
                                <td>Amount</td>
                                <td>Transaction</td>
                                <td>Status</td>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                            <td><%# Eval("ID") %>
                            </td>
                            <td>
                                <%# Eval("Date_Create") %>                          
                            </td>
                            <td>
                                <%# Eval("Username") %>  
                            </td>

                            <td>
                                <asp:LinkButton ID="lnkBlockchain" runat="server" OnClick="lnkBlockchain_Click" CommandArgument='<%#Eval("Wallet") %>' Text='<%#Eval("Wallet").ToString().Substring(0,4) + "........" + Eval("Wallet").ToString().Substring(Eval("Wallet").ToString().Length-4,4) %>' Font-Bold="true" ForeColor="#2d3fda"></asp:LinkButton>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblAm" Text='<%# Eval("Amount").ToString().Substring(0,Eval("Amount").ToString().Length -4) %>' Font-Bold="true" ForeColor="Red"></asp:Label>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkTransaction" runat="server" OnClick="lnkTransaction_Click" CommandArgument='<%# Eval("TransactionID") %>' Text='<%#Eval("TransactionId").ToString().Substring(0,4) + "........" + Eval("TransactionId").ToString().Substring(Eval("TransactionId").ToString().Length-4,4) %>' Font-Bold="true" ForeColor="#2d3fda"></asp:LinkButton>
                            </td>
                            <td><span class="label label-primary">
                                <%# getStatus(Eval("Status")) %>
                            </span>
                                </td>
                            <td>
                                <asp:LinkButton ID="lbkBtnConfirm" runat="server" Visible='<%# getConfirmVisible(Eval("Status")) %>' Text="Select" CommandArgument='<%# Eval("ID") %>' class="btn btn-info" OnClick="lbkBtnConfirm_Click" ></asp:LinkButton>
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:DataList>
        </section>
        <div class="pagination"></div>
    </section>
</asp:Content>
