<%@ Page Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="SelectPackInvest.aspx.cs" Inherits="BIT.WebUI.Admin.SelectPackInvest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="wrapper">
        <br />
        <section class="panel">
            <header class="panel-heading">
                <h3>Select Pack Invest </h3>
            </header>
            <div class="panel-body">
                <div class="form">
                    <asp:HiddenField ID="hidCodeId" runat="server" />
                    <div class="form-group col-lg-12">
                        <label class="control-label col-lg-3">Send Bit to</label>
                        <div class="col-lg-6">
                        </div>
                    </div>
                    <div class="form-group col-lg-12">
                        <label class="control-label col-lg-3">Select Pack</label>
                        <div class="col-lg-6">
                            <asp:DropDownList runat="server" ID="drPackSelectTion">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group col-lg-12">
                        <label class="control-label col-lg-3">Select invest time </label>
                        <div class="col-lg-6">
                            <asp:DropDownList runat="server" ID="drTimeInvest">
                                <asp:ListItem Text="1" Value="1" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="2" Value="1"></asp:ListItem>
                                <asp:ListItem Text="3" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group col-lg-12">
                        <label class="control-label col-lg-3">Transaction</label>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtTransaction" CssClass="form-control" placeholder="Ex a3cd4f936a39ac25106e77d9e2433d99c759325ea38408494be30f36c1652617"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter your phone number" ControlToValidate="txtTransaction" runat="server" ForeColor="#cc0066" Text="Enter transaction string" Display="Dynamic" />
                        </div>
                    </div>

                    <div class="form-group col-lg-12">
                        <label class="control-label col-lg-3">Password PIN*</label>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtPasswordPIN" CssClass="form-control" placeholder="Confirm Password PIN to update your information" type="password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group col-lg-12">
                        <div style="text-align: center;" class="col-lg-12">
                            <asp:Button runat="server" ID="btnUpdate" class="btn btn-info" Text="Buy Pack" OnClick="btnUpdate_Click1" />
                        </div>
                    </div>

                    <div class="form-group col-lg-12">
                        <asp:Label runat="server" ID="lblMessage" Visible="false" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
            </div>
        </section>
        <section class="panel">
            <header class="panel-heading">
                <h3>Invest History</h3>
            </header>
            <div class="panel-body">
                <div class="form">
                    <asp:DataList ID="grdListPH" runat="server" class="table table-hover p-table">
                        <HeaderTemplate>
                            <table class="table table-hover p-table">
                                <tr>
                                    <th>Create Time</th>
                                    <th>Pack Name</th>
                                    <th>Expire Date</th>
                                    <th>Date Count</th>
                                    <th>Status</th>
                                    <th></th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblPHTime" Text=''></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblAmount" Text=' '></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblDateCount" Text='' />
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblFull" Text=''></asp:Label>
                                </td>
                                <td>
                                    <span class="label label-primary">
                                        <asp:Label runat="server" ID="lblStatus" Text=''></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <a href="#">
                                        <asp:LinkButton runat="server" ID="btnGH1" Visible='true' OnClick="" CommandArgument='' type="submit" class="btn btn-success" Text="GH1" />
                                        <asp:LinkButton runat="server" ID="btnGH2" Visible='true' OnClick="" CommandArgument='' type="submit" class="btn btn-success" Text="GH1" />
                                    </a>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:DataList>
                </div>
            </div>
        </section>
    </section>
</asp:Content>
