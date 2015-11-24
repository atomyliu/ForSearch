<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.admin.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>系统管理</title>
    <link href="../style/bootstrap.min.css" rel="stylesheet" />
    <link href="../style/dashboard.css" rel="stylesheet" />
</head>
<body>
    <%--控制台顶部--%>
    <nav class="navbar navbar-inverse navbar-fixed-top">
        <div class="container-fluid">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#">系统管理控制台</a>
            </div>
            <div id="navbar" class="navbar-collapse collapse">
                <ul class="nav navbar-nav navbar-right">
                    <li><a href="#">管理员</a></li>
                    <li><a href="#">帮助</a></li>
                </ul>
                <form class="navbar-form navbar-right">
                    <input type="text" class="form-control" placeholder="Search..." />
                </form>
            </div>
        </div>
    </nav>
    <%--控制台主体--%>
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-3 col-md-2 sidebar">
                <ul class="nav nav-sidebar">
                    <li class="active"><a href="#">用户搜索跟踪</a></li>
                    <li>...</li>
                </ul>
            </div>
            <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
                <h1 class="page-header">跟踪信息</h1>
                <div class="table-responsive">
                    <table class="table table-striped">
                        <asp:Repeater ID="rpTrack" runat="server" EnableViewState="true">
                            <HeaderTemplate>
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>用户名</th>
                                        <th>登录IP</th>
                                        <th>登录时间</th>
                                        <th>搜索关键字</th>
                                        <th>动作</th>
                                    </tr>
                                </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tbody>
                                    <tr>
                                        <td><%#Eval("ID") %></td>
                                        <td><%#Eval("UserName") %></td>
                                        <td><%#Eval("IPAdress") %></td>
                                        <td><%#Eval("LoginTime") %></td>
                                        <td><%#Eval("Keyword") %></td>
                                        <td><%#oper((int)Eval("Operation")) %></td>
                                    </tr>
                                </tbody>
                            </ItemTemplate>
                            <FooterTemplate>
                            </FooterTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <script src="../js/jquery-1.11.3.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
</body>
</html>
