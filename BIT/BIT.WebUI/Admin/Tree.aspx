<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="Tree.aspx.cs" Inherits="BIT.WebUI.Admin.Tree" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<script src="../Scripts/Admin/jquery.js"></script>--%>
    <script type="text/javascript" src="../Scripts/loader.js"></script>
    <script type="text/javascript" src="../Scripts/smart.resize.js"></script>
    <section class="wrapper">
        <style type="text/css">
            .center-table {
                margin: 0 auto !important;
                float: none !important;
            }


            .ghichu {
                float: left;
                padding: 5px;
            }

            .mychart .title {
                color: #3CA936;
                font-size: large;
                float: left;
                margin-right: 10px;
            }

            .mychart .zoom {
                float: right;
            }

                .mychart .zoom .in, .mychart .zoom .out {
                    cursor: pointer;
                    float: left;
                    font-size: 20px;
                    font-weight: bold;
                    line-height: 30px;
                    -webkit-border-radius: 15px;
                    -moz-border-radius: 15px;
                    border-radius: 15px;
                    text-decoration: none;
                    width: 30px;
                    height: 30px;
                    color: #fff;
                    background-color: #428BCA;
                    text-align: center;
                }

            img {
                width: auto !important;
            }

            .image_tree {
                width: 24px;
                height: 24px;
            }
        </style>
        <!-- BEGIN PAGE CONTENT-->
        <div class="row">
            <br />
            <div class="col-md-12">
                <div class="panel">
                    <div class="panel-heading">
                        <h3>Tree</h3>
                    </div>
                    <div class="panel-body">


                        <div class="life_better_tree">
                            <div>

                                <script type="text/javascript">
                                    var currZoom = 1;

                                    $(document).ready(function () {
                                        $("#ZoomIn").click(function () {
                                            var w = $("#chart_div").width();
                                            var w_chart = $("table.google-visualization-orgchart-table").width();

                                            currZoom += 0.1;
                                            $(".chart_div").css({
                                                'zoom': currZoom
                                            }
                                            );
                                        });
                                        $("#ZoomOut").click(function () {
                                            currZoom -= 0.1;
                                            $(".chart_div").css({
                                                'zoom': currZoom
                                            }
                                            );
                                        });
                                    });
                                </script>



                                <script type="text/javascript">

                                    $(document).ready(function () {
                                        ShowTree();
                                    });

                                    function ShowTree() {
                                        google.charts.load('current', { packages: ["orgchart"] });
                                        google.charts.setOnLoadCallback(drawChart1);
                                    }

                                    function drawChart1() {
                                        $.ajax({
                                            type: "POST",
                                            url: "Tree.aspx/GetChartData",
                                            //data: '{}',
                                            data: '{username: "' + $("#<%=hidUserName.ClientID%>")[0].value + '" }',
                                            contentType: "application/json; charset=utf-8",
                                            dataType: "json",
                                            success: function (r) {
                                                var data = new google.visualization.DataTable();
                                                data.addColumn('string', 'Entity');
                                                data.addColumn('string', 'ParentEntity');
                                                data.addColumn('string', 'ToolTip');

                                                for (var i = 0; i < r.d.length; i++) {
                                                    var ma_cay = r.d[i][2].toString();
                                                    var ma_kh = r.d[i][1] != null ? r.d[i][1].toString() : 'Trống';
                                                    var memberName = r.d[i][8] != null ? r.d[i][8].toString() : '';
                                                    var ma_cay_tt = r.d[i][4] != null ? r.d[i][4].toString() : '';
                                                    var level = r.d[i][7];

                                                    data.addRows([[{
                                                        v: ma_cay,
                                                        f: memberName
                                                            + '<div>(<span style="color:red">'
                                                            + ma_kh
                                                            + '</span>)<div><img src = "../images/' + level + '.png" class="image_tree" /></div>'
                                                    }, ma_cay_tt, memberName]]);
                                                }
                                                var chart = new google.visualization.OrgChart($("#chart_div")[0]);

                                                var options = {
                                                    allowHtml: true,
                                                    nodeClass: 'blf-orgchart-node',
                                                    allowCollapse: true
                                                };

                                                chart.draw(data, options);


                                                // chinh zoom cua cayf
                                                var cur_zoom;
                                                var w = $("#chart_div").width();
                                                var w_chart = $("table.google-visualization-orgchart-table").width();
                                                cur_zoom = w / w_chart;

                                                if (cur_zoom > 1) cur_zoom = 1;
                                                currZoom = cur_zoom;

                                                $(".chart_div").css({
                                                    'zoom': cur_zoom
                                                });
                                            },
                                            failure: function (r) {
                                                //alert(r.d);
                                            },
                                            error: function (r) {
                                                //alert(r.d);
                                            }
                                        });
                                    }

                                </script>
                                <div class="mychart">

                                    <div class="row">
                                        <%--<div class="title" style="color: black">&nbsp;&nbsp;&nbsp;Username</div>
                                        <asp:TextBox runat="server" ID="txtUsername" Text="0" class="form-control" Style="width: 100px;"></asp:TextBox>--%>
                                        <asp:HiddenField ID="hidUserName" runat="server" />
                                        
                                    </div>
                                    <div class="ghichu">
                                        <img src="../images/0.png" height="24" width="24" />
                                        Empty-No level &nbsp;&nbsp;
                                                <img src="../images/V1.png" height="24" width="24" />
                                        V1  &nbsp;&nbsp;
                                                <img src="../images/V2.png" height="24" width="24" />
                                        V2  &nbsp;&nbsp;
                                                <img src="../images/V3.png" height="24" width="24" />
                                        V3  &nbsp;&nbsp;
                                                <img src="../images/V4.png" height="24" width="24" />
                                        V4  &nbsp;&nbsp;
                                                <img src="../images/V5.png" height="24" width="24" />
                                        V5

                                        <img src="../images/BRONZE.png" height="24" width="24" />
                                        BRONZE
                                        <img src="../images/SILVER.png" height="24" width="24" />
                                        SILVER
                                        <img src="../images/GOLDEN.png" height="24" width="24" />
                                        GOLDEN
                                        <img src="../images/DIAMOND.png" height="24" width="24" />
                                        DIAMOND
                                    </div>
                                    <div class="zoom">
                                        <p id="ZoomIn" class="in" title="Phóng to">
                                            + 
                                        </p>
                                        <p id="ZoomOut" class="out" title="Thu nhỏ">
                                            -
                                        </p>
                                    </div>




                                </div>


                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <div class="row panel">
            <div class="center-table panel-body">
                <div id="chart_div" class="chart_div">
                </div>
            </div>
        </div>
    </section>
  
</asp:Content>
