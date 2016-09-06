<%@ Page Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="EditAccount.aspx.cs" Inherits="BIT.WebUI.Admin.EditAccount" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="wrapper">
        <br />
        <section class="panel">
            <header class="panel-heading">
                <h3>Edit account </h3>
            </header>
            <div class="panel-body">
                <div class="form">
                    <asp:HiddenField ID="hidCodeId" runat="server" />
                    <div class="form-group col-lg-12">
                        <label class="control-label col-lg-3">Username*</label>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control username_user" placeholder="Username" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group col-lg-12">
                        <label class="control-label col-lg-3">Email*</label>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control email_user" placeholder="Email"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group col-lg-12">
                        <label class="control-label col-lg-3">Fullname*</label>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtFullName" CssClass="form-control" placeholder="Fullname"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter your fullname" ControlToValidate="txtFullName" runat="server" ForeColor="#cc0066" Text="Enter your fullname" Display="Dynamic" />
                        </div>
                    </div>

                    <div class="form-group col-lg-12">
                        <label class="control-label col-lg-3">Phone number*</label>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtPhone" CssClass="form-control" placeholder="Phone number"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter your phone number" ControlToValidate="txtPhone" runat="server" ForeColor="#cc0066" Text="Enter your phone number" Display="Dynamic" />
                        </div>
                    </div>

                    <div class="form-group col-lg-12">
                        <label class="control-label col-lg-3">Wallet*</label>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtWallet" CssClass="form-control" placeholder="Wallet" ReadOnly></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter your wallet" ControlToValidate="txtWallet" runat="server" ForeColor="#cc0066" Text="Enter your wallet" Display="Dynamic" />
                        </div>
                    </div>

                    <div class="form-group col-lg-12">
                        <div style="text-align: center;" class="col-lg-12">
                            <asp:Button runat="server" ID="btnUpdate" class="btn btn-info" Text="Order Update Information" OnClick="btnUpdate_Click" />
                        </div>
                    </div>

                    <div class="form-group col-lg-12">
                        <asp:Label runat="server" ID="lblMessage" Visible="false" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
            </div>
        </section>
    </section>
</asp:Content>
