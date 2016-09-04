<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="Tree.aspx.cs" Inherits="BIT.WebUI.Admin.Tree" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="../Content/Tree/Styles/jquery-treeview/jquery.treeview.css" rel="stylesheet" />
   <%-- <script src="../Scripts/WebForms/TreeView.js"></script>--%>
   <%-- <script src="../Scripts/jquery-1.10.2.js"></script>
    <script src="../Scripts/jquery-1.10.2.min.js"></script>--%>
    <script src="../Scripts/jquery-treeview/jquery.treeview.js"></script>
   <%-- <script src="../Scripts/ace-extra.min.js"></script>--%>
    
    <%--<link href="../Content/ace.min.css" rel="stylesheet" />--%>

     <script type="text/javascript">

         $(document).ready(function () {
             //jQuery.noConflict();

             alert('abc');
             $("#navigation").treeview({
                 persist: "location",
                 collapsed: true,
                 animated: "medium"
             });

             alert('abcd');

             $("#navarea").css("display", "");

         });

    </script>


    <style type="text/css">
        .tree .tree-item, .tree .tree-folder {
            border: none !important;
        }

            .tree .tree-folder .tree-folder-header:hover {
                background-color: #9599A9;
                border-radius: 4px;
                -webkit-border-radius: 4px;
            }
    </style>

    <section class="wrapper">
        <br />
        <section class="panel">
            <header class="panel-heading">
                <h3>Tree</h3>
            </header>
            <div class="panel-body">
                <%--<div class="page-header">
                    <h1>Account
			<small>
                <i class="ace-icon fa fa-angle-double-right"></i>
                Tree
            </small>
                    </h1>
                </div>--%>
                <!-- BEGIN PAGE CONTENT-->
                <div class="row">
                    <div class="col-md-12">
                        <div class="panel">

                            <div class="panel-body">
                                <div id="navarea" >

                                    <ul id="navigation" class="treeview">
                                        <asp:Literal runat="server" ID="ltrTree"></asp:Literal>

                                    </ul>
                                </div>

                            </div>
                        </div>
                    </div>

                </div>
            </div>


        </section>
    </section>




</asp:Content>
