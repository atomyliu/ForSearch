<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="WebApp.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="style/jquery-ui.css" rel="stylesheet" />
    <link href="style/jquery-ui.theme.css" rel="stylesheet" />
    <style>
        .ui-autocomplete {
            font-size:14px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="tbSearch" runat="server"></asp:TextBox>
        </div>

    </form>
    <script src="js/jquery-1.11.3.min.js"></script>
    <script src="js/jquery-ui.js"></script>
    <script src="js/jquery.ui.autocomplete.html.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#tbSearch").autocomplete({
                html:true,
                source: "ashx/AutoKeyWordHandler.ashx",
                minLength: 2
            });
        });
    </script>

</body>
</html>
