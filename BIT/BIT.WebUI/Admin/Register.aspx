<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BIT.WebUI.Admin.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <section class="wrapper">
        <asp:Label runat="server" ID="lblMessage" ForeColor="#cc0066" Text="*Username or Password is not valid" Visible="false"></asp:Label>
        <br />

        <section class="panel">
            <header class="panel-heading">
                <h3>REGISTER</h3>
            </header>
            <div class="panel-body">
                <div class="form">
                    <div class="form-group col-lg-12">
                        <label for="username" class="control-label col-lg-3">Email*</label>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control email_user" placeholder="Email" ></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter your email" ControlToValidate="txtEmail" runat="server" ForeColor="#cc0066" Text="Enter your email" Display="Dynamic" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email is not valid" ControlToValidate="txtEmail" ForeColor="#cc0066" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"></asp:RegularExpressionValidator>
                        </div>
                    </div>

                    <div class="form-group col-lg-12">
                        <label for="firstname" class="control-label col-lg-3">Username*</label>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control username_user" placeholder="Username"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter your username" ControlToValidate="txtUserName" runat="server" ForeColor="#cc0066" Text="Enter your username" Display="Dynamic" />
                        </div>
                    </div>

                    <div class="form-group col-lg-12">
                        <label for="password" class="control-label col-lg-3">Password*</label>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" placeholder="Password" type="password"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter your password" ControlToValidate="txtPassword" runat="server" ForeColor="#cc0066" Text="Enter your password" Display="Dynamic" />
                        </div>
                    </div>

                    <div class="form-group col-lg-12">
                        <label for="confirm_password" class="control-label col-lg-3">Password Confirm* </label>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtConfirmPassword" CssClass="form-control" placeholder="Password Confirm" type="password"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter your password confirm" ControlToValidate="txtConfirmPassword" runat="server" ForeColor="#cc0066" Text="Enter your password confirm" Display="Dynamic" />
                            <asp:CompareValidator ID="CompareValidator1" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" runat="server" ForeColor="#cc0066" ErrorMessage="Password confirm is not valid"></asp:CompareValidator>
                        </div>
                    </div>

                    <%--<div class="form-group col-lg-12">
                        <label for="password" class="control-label col-lg-3">Password PIN*</label>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtPassword_PIN" CssClass="form-control" placeholder="Password PIN" type="password"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter your password PIN" ControlToValidate="txtPassword_PIN" runat="server" ForeColor="#cc0066" Text="Enter your password PIN" Display="Dynamic" />
                        </div>
                    </div>

                    <div class="form-group col-lg-12">
                        <label for="confirm_password" class="control-label col-lg-3">Password PIN Confirm* </label>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtConfirmPassword_PIN" CssClass="form-control" placeholder="Password PIN Confirm" type="password"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter your password PIN confirm" ControlToValidate="txtConfirmPassword_PIN" runat="server" ForeColor="#cc0066" Text="Enter your password PIN confirm" Display="Dynamic" />
                            <asp:CompareValidator ID="CompareValidator2" ControlToCompare="txtPassword_PIN" ControlToValidate="txtConfirmPassword_PIN" runat="server" ForeColor="#cc0066" ErrorMessage="Password PIN confirm is not valid"></asp:CompareValidator>
                        </div>
                    </div>--%>

                    <div class="form-group col-lg-12">
                        <label for="firstname" class="control-label col-lg-3">Fullname*</label>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtFullName" CssClass="form-control" placeholder="Fullname"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter your fullname" ControlToValidate="txtFullName" runat="server" ForeColor="#cc0066" Text="Enter your fullname" Display="Dynamic" />
                        </div>
                    </div>

                    <div class="form-group col-lg-12">
                        <label for="username" class="control-label col-lg-3">Wallet*</label>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtWallet" CssClass="form-control" placeholder="Wallet"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter your wallet" ControlToValidate="txtWallet" runat="server" ForeColor="#cc0066" Text="Enter your wallet" Display="Dynamic" />
                        </div>
                    </div>

                    <div class="form-group col-lg-12">
                        <label for="phone" class="control-label col-lg-3">Phone number*</label>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtPhone" CssClass="form-control" placeholder="Phone number"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter your phone number" ControlToValidate="txtPhone" runat="server" ForeColor="#cc0066" Text="Enter your phone number" Display="Dynamic" />
                        </div>
                    </div>

                    <div class="form-group col-lg-12">
                        <label for="country" class="control-label col-lg-3">Country*</label>
                        <div class="col-lg-6">
                            <asp:DropDownList runat="server" ID="ddlCountry" CssClass="form-control">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ErrorMessage="Enter your country" ControlToValidate="ddlCountry" runat="server" ForeColor="#cc0066" Text="Enter your country" Display="Dynamic" />
                        </div>
                    </div>

                    <div class="form-group col-lg-12">
                        <div class="col-lg-12" style="text-align: center;">
                            <asp:Button runat="server" ID="btnRegister" CssClass="btn btn-info" Text="Register" OnClick="btnRegister_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </section>


    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">
        $(".email_user").change(function () {
            var email = $(this).val();
            var name = email.substring(0, email.lastIndexOf("@"));

            $('.username_user').val(name);
        });

        function getUsername() {
            
        };

    </script>
</asp:Content>
