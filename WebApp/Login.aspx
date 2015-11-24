<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>用户登录</title>
    <link href="style/bootstrap.min.css" rel="stylesheet" />
    <link href="style/signin.css" rel="stylesheet" />
    <link href="style/bootstrap-theme.min.css" rel="stylesheet" />
</head>
<body>
    
    <div class="container">
        <form id="form1" runat="server" class="form-signin">
        <h3 class="form-signin-heading">请登录</h3>
        <label for="tbuser" class="sr-only">用户名</label>
        <asp:TextBox ID="tbuser" runat="server" class="form-control" placeholder="用户名" required autofocus></asp:TextBox>
        <label for="tbpwd" class="sr-only">密码</label>
        <asp:TextBox ID="tbpwd" runat="server" class="form-control" placeholder="密码" TextMode="Password" required></asp:TextBox>
        <asp:Button ID="btn" runat="server" Text="登录" class="btn btn-lg btn-primary btn-block" OnClick="btn_Click"/>
        </form>
    </div>
    
    <script src="js/jquery-1.11.3.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
