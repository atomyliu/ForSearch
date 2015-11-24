<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Content.aspx.cs" Inherits="WebApp.news.Content" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="dataRepeater" runat="server" EnableViewState="true">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <b><%#Eval("title") %></b>&nbsp;ID：<%#Eval("newsid") %>&nbsp;&nbsp;&nbsp;DATE：<%#Eval("createon") %>
                        <br />
                        <%#Eval("content") %>
                    </li>
                    <hr />
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
