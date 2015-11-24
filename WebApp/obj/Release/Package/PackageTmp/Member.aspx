<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="WebApp.Member" %>

<%@ Register Src="~/ascx/memPager.ascx" TagPrefix="uc1" TagName="memPager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="style/page.css" rel="stylesheet" />
    <link href="style/member.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
            <div id="search">
                <div id="logo"></div>
                <div id="smain">
                    <asp:DropDownList ID="ddlist" CssClass="ddlist" runat="server">
                        <asp:ListItem Selected="True" Value="_all">全文</asp:ListItem>
                        <asp:ListItem Value="_ep">企业名称</asp:ListItem>
                        <asp:ListItem Value="_pd">产品名称</asp:ListItem>
                        <asp:ListItem Value="_memo">备注</asp:ListItem>
                        <asp:ListItem Value="_wn">用户名</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="tb1" type="search" runat="server"></asp:TextBox><asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                </div>
            </div>
            <div class="menu"></div>
            <div class="nums">卓创为您找到相关结果约：<asp:Label ID="lbCount" runat="server" Text="0"></asp:Label>条！</div>
            <div id="content">
                <div id="content_left">
                    <div id="rem" class="basicDataList">
                        <asp:Repeater ID="RpMem" runat="server" EnableViewState="true">
                            <HeaderTemplate>
                                <table class="bordered">
                                    <tr>
                                        <th>企业名称</th>
                                        <th>产品名称</th>
                                        <th>备注</th>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("Enterprise") %></td>
                                    <td><%#Eval("Products") %></td>
                                    <td><%#Eval("Memo") %></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="paget">
                        <uc1:memPager runat="server" ID="memPager" />
                    </div>
                </div>
                <div id="content_right">
                </div>
            </div>
        </div>
    </form>
    <script src="js/jquery-1.11.3.min.js"></script>

</body>
</html>
