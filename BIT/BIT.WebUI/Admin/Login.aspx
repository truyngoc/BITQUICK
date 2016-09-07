<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BIT.WebUI.Admin.Login" %>

<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="" />
    <meta name="author" content="Mosaddek" />
    <meta name="keyword" content="FlatLab, Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina" />
    <link rel="shortcut icon" href="favicon.png" />
    <title>BitQuick24 Login</title>
    <meta name="csrf-token" content="AvJsvFUkFTxZxtYHOn19V6YN6zqQExtwl6k0WVSd" />
    <script src="../Scripts/jquery-1.10.2.js"></script>
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.validate.unobtrusive.js"></script>
    <!-- Bootstrap core CSS -->
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/bootstrap-reset.css" rel="stylesheet" />
    <link href="../Content/font-awesome.css" rel="stylesheet" />
    <link href="../Content/jquery.easy-pie-chart.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Content/owl.carousel.css" type="text/css" rel="stylesheet" />
    <link href="../Content/slidebars.css" rel="stylesheet" />
    <link href="../Content/AdminStyle.css" rel="stylesheet" />
    <link href="../Content/style-responsive.css" rel="stylesheet" />
    <style>
        .btn-login {
            padding: 10px 20px;
            font-weight: bold;
            text-transform: uppercase;
            background: #375A7F;
        }
    </style>
</head>
<body style="background-color: #E6E7E8;">
    <div class="container">
        <div style="text-align: center; margin: 60px auto 0; padding: 15px;" class="logo-login">
            <a href="/" class="logo_login">
                <img src="../images/logo_BitQuick.png" />
            </a>
        </div>
        <form style="margin-top: 20px;" class="form-signin" runat="server">
            <br />
            <div class="text-center">
                <asp:Label runat="server" ID="lblMessage" ForeColor="#cc0066" Text="*Username or Password is not valid" Visible="false"></asp:Label>
            </div>

            <div class="login-wrap">
                <asp:TextBox ID="txtUserName" runat="server" class="form-control" Style="height: 41px;" placeholder="Username" />
                <asp:RequiredFieldValidator ErrorMessage="Enter your username" ControlToValidate="txtUserName" runat="server" ForeColor="#cc0066" Text="Enter your username" Display="Dynamic" />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control" Style="height: 41px;" placeholder="Password" />
                <div style="padding: 5px 0;">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" class="btn btn-info btn-login" OnClick="btnLogin_Click" />
                    <asp:Button ID="btnRegister" runat="server" Text="Register" class="btn btn-info btn-login" />
                    <span class="pull-right"><a style="color: #000;" href="#">Forgot Password ?</a></span>
                </div>
               
            </div>
        </form>
    </div>
</body>
</html>
