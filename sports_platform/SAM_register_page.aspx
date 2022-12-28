<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SAM_register_page.aspx.cs" Inherits="sports_platform.SAM_register_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Name
            <br />
            <asp:TextBox ID="sam_name" runat="server"></asp:TextBox>
            <br />
            Username
            <br />
            <asp:TextBox ID="sam_username" runat="server"></asp:TextBox>
            <br />
            Password
            <br />
            <asp:TextBox ID="sam_password" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="addSAM" Text="Register" />
            


        </div>
    </form>
</body>
</html>
