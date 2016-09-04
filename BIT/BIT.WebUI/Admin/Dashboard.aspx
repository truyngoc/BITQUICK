<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="BIT.WebUI.Admin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="clear: both;"></div>
    <div class="label_b">
        <div class="row state-overview">
            <div class="col-lg-3 col-sm-6">
                <div class="flip">
                    <section class="panel front">
                        <div class="symbol">
                            <img src="../images/earn.png" />
                        </div>
                        <div class="value">
                            <p>B Wallet</p>
                            <h1 class="count">
                                <asp:Label ID="lblB_Wallet" runat="server"></asp:Label>
                                BTC
                            </h1>
                        </div>
                    </section>
                </div>
            </div>
            <div class="col-lg-3 col-sm-6">
                <div class="flip">
                    <section class="panel front">
                        <div class="symbol">
                            <img src="../images/c.png" />
                        </div>
                        <div class="value" >
                            <p>C Wallet</p>
                            <h1 class="count">
                                <asp:Label ID="lblC_Wallet" runat="server" />
                                BTC
                            </h1>

                        </div>
                    </section>
                </div>
            </div>
            <div class="col-lg-3 col-sm-6">
                <div class="flip">
                    <section class="panel front">
                        <div class="symbol">
                            <img src="../images/r.png" />
                        </div>
                        <div class="value">
                            <p>R Wallet</p>
                            <h1 class="count">
                                <asp:Label ID="lblR_Wallet" runat="server" />
                                BTC
                            </h1>

                        </div>
                    </section>
                </div>
            </div>
            <div class="col-lg-3 col-sm-6">
                <div class="flip">
                    <section class="panel front">
                        <div class="symbol">
                            <img src="../images/pin.png" />
                        </div>
                        <div class="value">
                            <p>Pin</p>
                            <h1 class="count">
                                <asp:Label ID="lblPIN_Wallet" runat="server" />
                            </h1>

                        </div>
                    </section>
                </div>
            </div>
        </div>
        <!--state overview end-->

        <!--state overview start-->
        <div class="row state-overview">
            <div class="col-lg-3 col-sm-6">
                <div class="flip">
                    <section class="panel front">
                        <div class="symbol">
                            <img src="../images/direct.png" />
                        </div>
                        <div class="value">
                            <p>Direct Downline</p>
                            <h1 class="count">
                                <asp:Label ID="lblDirectDownline" runat="server" />
                            </h1>

                        </div>
                    </section>
                </div>
            </div>
            <div class="col-lg-3 col-sm-6">
                <div class="flip">
                    <section class="panel front">
                        <div class="symbol">
                            <img src="../images/total.png" />
                        </div>
                        <div class="value">
                            <p>Total Downline</p>
                            <h1 class="count">
                                <asp:Label ID="lblTotalDownline" runat="server" />
                            </h1>
                        </div>
                    </section>
                </div>
            </div>
            <div class="col-lg-3 col-sm-6">
                <div class="flip">
                    <section class="panel front">
                        <div class="symbol">
                            <img src="../images/PD.png" />
                        </div>
                        <div class="value">
                            <p>Total PH</p>
                            <h1 class="count">
                                <asp:Label ID="lblTotalPH" runat="server" />
                            </h1>

                        </div>
                    </section>
                </div>
            </div>
            <div class="col-lg-3 col-sm-6">
                <div class="flip">
                    <section class="panel front">
                        <div class="symbol">
                            <img src="../images/GD.png" />
                        </div>
                        <div class="value">
                            <p>Total GH</p>
                            <h1 class="count">
                                <asp:Label ID="lblTotalGH" runat="server" />
                            </h1>
                        </div>
                    </section>
                </div>
            </div>
        </div>


        <!--state overview start-->
        <div class="row state-overview infor_b col-centered">
            <div class="col-sm-6 col-lg-3 ">
                <section class="panel front">
                    <div class="panel-heading" style="background-color:#2d3fda">
                        <strong style="color: #ffffff;">TOTAL DOWNLINE</strong>
                    </div>
                    <div class="panel-body" style="padding: 0 15px;">
                        <div class="col-sm-6" style="border-right: 1px solid #35567A">
                            <p style="color: #E73538; font-weight: bold;">
                                Left:
                                    <asp:Label ID="lblDownline_Left" runat="server" />
                            </p>
                        </div>
                        <div class="col-sm-6">
                            <p style="color: #E73538; font-weight: bold;">
                                Right:
                                    <asp:Label ID="lblDownline_Right" runat="server" />
                            </p>
                        </div>
                    </div>
                </section>
            </div>
            <div class="col-sm-6 col-lg-3 ">
                <section class="panel front">
                    <div class="panel-heading" style="background-color:#2d3fda">
                        <strong style="color: #ffffff;" >TOTAL DOWNLINE BTC</strong>
                    </div>
                    <div class="panel-body" style="padding: 0 15px;">
                        <div class="col-sm-6" style="border-right: 1px solid #35567A">
                            <p style="color: #E73538; font-weight: bold;">
                                Left:
                                    <asp:Label ID="lblDownline_BTC_Left" runat="server" />
                            </p>
                        </div>
                        <div class="col-sm-6">
                            <p style="color: #E73538; font-weight: bold;">
                                Right:
                                    <asp:Label ID="lblDownline_BTC_Right" runat="server" />
                            </p>
                        </div>
                    </div>
                </section>
            </div>
        </div>
        <!--state overview End-->
    </div>
</asp:Content>
