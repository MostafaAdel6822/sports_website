<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="system-admin.aspx.cs" Inherits="sports_platform.system_admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div>System Admin</div>

    <form id="form1" runat="server">
        <p>Add Club:</p>
        <div>club name</div>
        <asp:TextBox ID="club_name_SA_add" runat="server"></asp:TextBox>
        <div>club location</div>
        <asp:TextBox ID="club_location_SA_add" runat="server"></asp:TextBox>
     <br />

        <asp:Button ID="add_club_SA_btn" runat="server" Text="Add" OnClick="add_club_SA_btn_Click" />
        <br/>
        <br/>
        <p>Delete Club:</p>
        <div>club name</div>
        <asp:TextBox ID="club_name_SA_del" runat="server"></asp:TextBox>
        <br/>
        <asp:Button ID="delete_club_SA_btn" runat="server" Text="Delete" OnClick="delete_club_SA_btn_Click" />
        <br/>
        <br/>
        <p>Add Stadium:</p>
        <div>stadium name</div>
        <asp:TextBox ID="stadium_name_SA_add" runat="server"></asp:TextBox>
        <div>stadium location</div>
        <asp:TextBox ID="stadium_location_SA_add" runat="server"></asp:TextBox>
        <div>stadium capacity</div>
        <asp:TextBox ID="stadium_capacity_SA_add" runat="server"></asp:TextBox>
        <br/>
        <asp:Button ID="add_stadium_SA_btn" runat="server" Text="Add" OnClick="add_stadium_SA_btn_Click" />
        <br/>
        <br/>
        <p>Delete Stadium:</p>
        <div>stadium name</div>
        <asp:TextBox ID="stadium_name_SA_del" runat="server"></asp:TextBox>
        <br/>
        <asp:Button ID="delete_stadium_SA_btn" runat="server" Text="Delete" OnClick="delete_stadium_SA_btn_Click" />
        <br/>
        <br/>
        <p>Block Fan:</p>
        <div>national ID</div>
        <asp:TextBox ID="block_fan_SA" runat="server"></asp:TextBox>
        <br/>
        <asp:Button ID="block_fan_SA_btn" runat="server" Text="Block" OnClick="block_fan_SA_btn_Click" />
    </form>
</body>
</html>
