<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stadiummanagerregister.aspx.cs" Inherits="sports_platform.registerpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            direction: ltr;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Stadium Manager Registration<br />
            <br />
            Name</div>
        <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
        <br />
        username<br />
        <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
        <br />
        password<br />
        <asp:TextBox ID="TextBox3" runat="server" ></asp:TextBox>
        <br />
        Stadium Name<br />
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="add" OnClick="Addition" />
        <br />
    </form>
</body>
</html>
