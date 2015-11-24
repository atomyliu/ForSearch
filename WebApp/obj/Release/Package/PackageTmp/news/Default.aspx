<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.news.Default" %>

<%@ Register Src="~/ascx/pager.ascx" TagPrefix="uc1" TagName="pager" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../style/page.css" rel="stylesheet" />
    <link href="../style/jquery-ui.css" rel="stylesheet" />
    <link href="../style/jquery-ui.theme.css" rel="stylesheet" />
    <style>
        .ui-autocomplete {
            font-size:14px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
        <div id="search">
            <div id="logo"></div>
            <div id="smain">
                <asp:TextBox ID="tbSearch" runat="server" type="search" placeholder="Search"></asp:TextBox><asp:Button ID="btnSearch" runat="server" Text="搜一下" OnClick="btnSearch_Click"  />
            </div>
        </div>
        <div class="menu">
            <asp:RadioButton ID="rb1" runat="server" GroupName="rblist" ValidationGroup="rblist" Text="搜新闻全文" Checked="True" />
            <asp:RadioButton ID="rb2" runat="server" GroupName="rblist" ValidationGroup="rblist" Text="搜新闻标题" />
        </div>
        <div class="nums">卓创为您找到相关结果约：<asp:Label ID="lbCount" runat="server" Text="0"></asp:Label>个！</div>
        <div id="content">
            <div id="content_left">
                <div id="news" class="basicDataList">
                    <asp:Repeater ID="RpNews" runat="server" EnableViewState="true">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="c-content">
                                <h3 class="t"><a class="lb" onclick="openwin(<%#Eval("Newsid") %>);this.style.color='#551A8B'"><%#Eval("Title") %></a></h3>
                                <div class="c-abstract">
                                    <span class="ctime">-发布时间：<%#subtime(Eval("Createon")) %></span>
                                    <%#substr(Eval("Content").ToString()) %>
                                </div>
                                <div class="c-url">
                                    <span class="g"><%=Request.Url.Host.ToString()+"/Content.aspx?_id=" %><%#Eval("Newsid") %></span>
                                </div>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <div class="paget">
                    <uc1:pager runat="server" ID="pager" />
                </div>
            </div>
            <div id="content_right">
                <div class="cr-title">
                    <span title="相关搜索">相关产品</span>
                </div>
            </div>
                    
        </div>
        <div id="foot">
        </div>
            </div>
        <script src="../js/jquery-1.11.3.min.js"></script>
        <script src="../js/highlight.js"></script>
         <script src="../js/jquery-ui.js"></script>
        <script src="../js/jquery.ui.autocomplete.html.js"></script>
        <script type="text/javascript">
            $(document).ready(function () {
                $('#tbSearch').autocomplete({
                    html: true,
                    source: "../ashx/AutoKeyWordHandler.ashx",
                    minLength: 2
                });
            });
        </script>
        <script type="text/javascript">
            function openwin(id) {
                window.open("Content.aspx?_id=" + id, "newwindow", "height=600, width=600, toolbar =no, menubar=no, scrollbars=no, resizable=no, location=no, status=no") //写成一行
            }
        </script>
        <%--jquery高亮--%>
        <script type="text/javascript">
            $(function hei() {
                var searchTerm = $(this).val();
                var str = $('#tbSearch').val();
                // remove any old highlighted terms
                $("#news").removeHighlight();

                // disable highlighting if empty
                if (str) {
                    // highlight the new term
                    $("#news").highlight(str);
                }
            });
            $(function () {
                $('#tbSearch').bind('keyup change', function (ev) {
                    // pull in the new value
                    var searchTerm = $(this).val();
                    // remove any old highlighted terms
                    $("#news").removeHighlight();

                    // disable highlighting if empty
                    if ($.trim(searchTerm)) {
                        // highlight the new term
                        $("#news").highlight(searchTerm);

                    }
                });
            });
        </script>
    </form>
</body>
</html>
