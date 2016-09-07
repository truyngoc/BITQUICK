<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="ConfirmPH.aspx.cs" Inherits="BIT.WebUI.Admin.ConfirmPH" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="wrapper">
        <br />
        <section class="panel">
            <header class="panel-heading">
                <h3>Confirm PH </h3>
            </header>
            <div class="panel-body">
                <div class="container center_div">
                    <asp:HiddenField ID="hidCodeId" runat="server" />
                    <div class="form-group col-lg-12">
                        <label class="control-label col-lg-3">Address to PH</label>
                            <div class="col-lg-5">
                                <span class="badge">
                                    <asp:Image ID="imgGHWallet" ImageUrl="http://chart.googleapis.com/chart?chs=200x200&cht=qr&chl=3MNyn34uN1cCBmwvcswfTaeiFAkdqtaMA2" Width="200" Height="200" runat="server" />
                                </span>
                                <br />
                                <asp:Label runat="server" ID="lblGHWallet" Text="Address: 3MNyn34uN1cCBmwvcswfTaeiFAkdqtaMA2"></asp:Label>
                            </div>
                    </div>
                    
                    
                    <div class="form-group col-lg-12">
                        <label class="control-label col-lg-3">Total Amount</label>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtTotalAmount" CssClass="form-control" readonly="true">3.3</asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group col-lg-12">
                        <label class="control-label col-lg-3">Transaction</label>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtTransaction" CssClass="form-control" placeholder="a3cd4f936a39ac25106e77d9e2433d99c759325ea38408494be30f36c1652617"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group col-lg-12">
                        <label class="control-label col-lg-3">Password PIN*</label>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtPasswordPIN" CssClass="form-control" placeholder="Input Password PIN to confirm PH" type="password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group col-lg-12">
                        <div class="col-lg-3"></div>
                        <div class="col-lg-6">
                            <asp:Button runat="server" ID="btnConfirmPH" class="btn btn-info" Text="CONFIRM" OnClick="btnConfirmPH_Click"  />
                        </div>
                    </div>
                </div>
            </div>
        </section>
        
    </section>
</asp:Content>
