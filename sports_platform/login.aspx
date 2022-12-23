<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="sports_platform.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        Please Login<asp:Button ID="returnIndexBtn" runat="server" Text="Return To Index" style='float:right' OnClick="returnIndexBtn_Click"/>
        <p>
            Username:</p>
        <asp:TextBox ID="username" runat="server"></asp:TextBox>
        <p>
            Password:</p>
        <asp:TextBox ID="password" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="loginBtn" runat="server" Text="Login" OnClick="loginBtn_Click" />

    </form>
</body>
</html>
