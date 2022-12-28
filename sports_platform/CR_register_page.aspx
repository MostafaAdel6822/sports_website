<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CR_register_page.aspx.cs" Inherits="sports_platform.CR_register_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Name
            <br/>
            <asp:TextBox ID="cr_name" runat="server"></asp:TextBox>
            <br />
            Username
            <br />
            <asp:TextBox ID="cr_username" runat="server"></asp:TextBox>
            <br />
            Password
            <br />
            <asp:TextBox ID="cr_password" runat="server"></asp:TextBox>
            <br />
            Club Name
            <br />
            <asp:TextBox ID="cr_cub_name" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="addCR" Text="Register" />
        </div>
    </form>
</body>
</html>
