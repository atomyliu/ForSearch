<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TXL.aspx.cs" Inherits="WebApiClient.TXL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="css/bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link href="css/bootstrap/bootstrap-theme.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding: 50px 50px 10px;">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">webapi客户端测试</h3>
                </div>
                <div class="panel-body">
                    <div class="container">
                        <div class="input-group input-group-sm">
                            <span class="input-group-addon">关键字</span>
                            <asp:TextBox ID="tburl" runat="server" class="form-control" Text="侯安全"></asp:TextBox>
                            <span class="input-group-btn">
                                <asp:Button ID="btnurl" runat="server" Text="Submit" class="btn " OnClick="btnurl_Click" />
                            </span>
                        </div>
                        <br />
                        <div class="input-group input-group-sm">
                            <span class="input-group-addon">测试rul</span>
                            <asp:TextBox ID="tbcurl" runat="server" class="form-control"></asp:TextBox>
                            <span class="input-group-btn">
                                <asp:Button ID="btncurl" runat="server" Text="Submit" class="btn " OnClick="btncurl_Click"/>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
                        <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">返回结果列表</h3>
                </div>
                <div class="panel-body">
                    <table class="table table-striped">
                        <asp:Repeater ID="rplist" runat="server" EnableViewState="true">
                            <HeaderTemplate>
                                <thead>
                                    <tr>
                                        <th>EID</th>
                                        <th>LFT</th>
                                        <th>排序ID</th>
                                        <th>姓名</th>
                                        <th>部门</th>
                                        <th>职务</th>
                                    </tr>
                                </thead>
                                <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("eid") %></td>
                                    <td><%#Eval("lft") %></td>
                                    <td><%#Eval("orderid") %></td>
                                    <td><%#Eval("realname") %></td>
                                    <td><%#Eval("departmentstr") %></td>
                                    <td><%#Eval("jobname") %></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                            </FooterTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>

        </div>
    </form>
    <script src="js/jquery/jquery-1.11.3.min.js"></script>
    <script src="js/bootstrap/bootstrap.min.js"></script>
</body>
</html>
