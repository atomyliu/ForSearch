<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Elasticsearch_Finger.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Content/pagestyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-inverse" role="navigation" >
            <div class="navbar-header">
                <img src="images/logo-elastic-noword.png" class="img_logo"/>
            </div>
            <div class="navbar-header">
                <a class="navbar-brand" href="#">Elasticsearch-Finger</a>
            </div>
            <div>
            <ul id="myTab" class="nav navbar-nav">
                <li class="active"><a href="#home" data-toggle="tab">概述</a>
                </li>
                <li><a href="#data" data-toggle="tab">数据浏览</a></li>
                <li><a href="#search" data-toggle="tab">数据查询</a></li>
            </ul>
            </div>
            <div>
                <ul class="nav navbar-nav navbar-right" style="margin-right: 5px;">
                    <li><a style="color:#fff">集群名：<asp:Label ID="lbcluster" runat="server" Text=""></asp:Label></a></li>
                    <li><a style="color:#fff">健康值：<asp:Label ID="lbhealth" runat="server" Text=""></asp:Label></a></li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">信息 <b class="caret"></b>
                        </a>
                        <ul class="dropdown-menu">
                            <li><a href="#">刷新时间：<asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem>5s</asp:ListItem>
                            </asp:DropDownList></a></li>
                            <li class="divider"></li>
                            <li><a href="#">连接服务器</a></li>
                            <li><a>
                                <asp:TextBox ID="tbip" runat="server"></asp:TextBox>
                            </a></li>
                        </ul>
                    </li>
                </ul>
            </div>
        </nav>
        <div id="myTabContent" class="tab-content mytab" style="height:inherit;">
            <div class="tab-pane fade in active" id="home" style="margin: 0 10px 0 10px">
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th></th>
                            <asp:Repeater ID="rpindex" runat="server">
                                <ItemTemplate>
                                    <th><%#Eval("Index")%> </br> docs:<%#Eval("DocsCount") %> | size:<%#Eval("PrimaryStoreSize") %>(<%#Eval("StoreSize") %>)</th>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tr>
                       <%-- <tr>
                            <%=THunassign() %>
                            <asp:Repeater ID="rpunassinged" runat="server">
                                <ItemTemplate>
                                    <%#TDsunassign()%>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tr>--%>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpnodes" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <th>
                                        <h4><%#getMaster(Eval("Master").ToString()) %><%#Eval("Name") %></h4>
                                        <%#Eval("Host") %></br>Heap:<%#Eval("HeapPercent") %>% | Ram:<%#Eval("RamPercent") %>%</th>
                                    <%#TDs(Eval("Name").ToString()) %>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                    </tbody>
                </table>
            </div>
            <div class="tab-pane fade" id="data" style="margin: 0 10px 0 10px">
            </div>
            <div class="tab-pane fade" id="search" style="height:inherit">
                <iframe src="sense/index.html" style=" width:100%; height:100%;"> </iframe>
            </div>
        </div>
        <script>
            $(function () {
                $('#myTab li:eq(1) a').tab('show');
            });
        </script>
    </form>
    <script src="Scripts/jquery-1.11.3.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
