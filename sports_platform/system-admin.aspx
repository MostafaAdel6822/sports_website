<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="system-admin.aspx.cs" Inherits="sports_platform.system_admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div>System Admin</div>
    <div>Name of user</div>
    <form id="form1" runat="server">
        <p>Add Club:</p>
        <div>
            <span style="padding:1.4em;">club name</span> <span style="padding:0.5em;">club location</span>
        </div>
        <asp:TextBox ID="club_name_SA_add" runat="server"></asp:TextBox>
        <asp:TextBox ID="club_location_SA_add" runat="server"></asp:TextBox>
        <asp:Button ID="add_club_SA_btn" runat="server" Text="Add" OnClick="add_club_SA_btn_Click" />
        <br/>
        <br/>
        <p>Delete Club:</p>
        <span style="padding:1.4em;">club name</span>
        <br />
        <asp:TextBox ID="club_name_SA_del" runat="server"></asp:TextBox>
        <asp:Button ID="delete_club_SA_btn" runat="server" Text="Delete" OnClick="delete_club_SA_btn_Click" />
        <br/>
        <br/>
        <p>Add Stadium:</p>
        <span style="padding:1.4em;">stadium name</span> <span style="padding:0.5em;">stadium location</span> <span style="padding-left:2.3em;">stadium capacity</span>
        <br/>
        <asp:TextBox ID="stadium_name_SA_add" runat="server"></asp:TextBox>
        <asp:TextBox ID="stadium_location_SA_add" runat="server"></asp:TextBox>
        <asp:TextBox ID="stadium_capacity_SA_add" runat="server"></asp:TextBox>
        <asp:Button ID="add_stadium_SA_btn" runat="server" Text="Add" OnClick="add_stadium_SA_btn_Click" />
        <br/>
        <br/>
        <p>Delete Stadium:</p>
        <span style="padding:1.4em;">stadium name</span>
        <br />
        <asp:TextBox ID="stadium_name_SA_del" runat="server"></asp:TextBox>
        <asp:Button ID="delete_stadium_SA_btn" runat="server" Text="Delete" OnClick="delete_stadium_SA_btn_Click" />
        <br/>
        <br/>
        <p>Block Fan:</p>
        <span style="padding:1.4em;">national ID</span>
        <br />
        <asp:TextBox ID="block_fan_SA" runat="server"></asp:TextBox>
        <asp:Button ID="block_fan_SA_btn" runat="server" Text="Block" OnClick="block_fan_SA_btn_Click" />

    </form>
</body>
</html>
