<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WcfTest.aspx.cs" Inherits="WebApp.WcfTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <link href="style/page.css" rel="stylesheet" />
    <link href="style/member.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="ddlist" CssClass="ddlist" runat="server">
                        <asp:ListItem Selected="True" Value="_all">全文</asp:ListItem>
                        <asp:ListItem Value="Enterprise">企业名称</asp:ListItem>
                        <asp:ListItem Value="Products">产品名称</asp:ListItem>
                        <asp:ListItem Value="Memo">备注</asp:ListItem>
                        <asp:ListItem Value="WebName">用户名</asp:ListItem>
                        <asp:ListItem Value="Address">地址</asp:ListItem>
                        <asp:ListItem Value="AdminName">管理员</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="tb1" type="search" runat="server"></asp:TextBox><asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
    </div>
        <div class="nums">找到相关结果约：<asp:Label ID="lbCount" runat="server" Text="0"></asp:Label>条！</div>
        <div>
                <asp:Repeater ID="RpMem" runat="server" EnableViewState="true">
                            <HeaderTemplate>
                                <table class="bordered">
                                    <tr>
                                        <th>企业名称</th>
                                        <th>产品名称</th>
                                        <th>用户名</th>
                                        <th>地址</th>
                                        <th>管理员</th>
                                        <th>备注</th>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("Enterprise") %></td>
                                    <td><%#Eval("Products") %></td>
                                    <td><%#Eval("WebName") %></td>
                                    <td><%#Eval("Address") %></td>
                                    <td><%#Eval("AdminName") %></td>
                                    <td><%#Eval("Memo") %></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>

        </div>
    </form>
</body>
</html>
