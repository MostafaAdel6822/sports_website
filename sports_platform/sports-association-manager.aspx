<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sports-association-manager.aspx.cs" Inherits="sports_platform.sports_association_manager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
 
        <div>
            Sports Association Manager</div>
        <div>Name of user</div>
    <form id="form1" runat="server">
        <br/> 
        <p>
            Add Match</p>
        <div>
            <span style="padding:1.4em;">host club name</span> <span style="padding:0.5em;">guest club name</span> <span style="padding-left:2.3em;">start time</span> <span style="padding-left:5em;">end time</span></div>
        <asp:TextBox ID="host_name_SAM_add" runat="server"></asp:TextBox>
        <asp:TextBox ID="guest_name_SAM_add" runat="server"></asp:TextBox>
        <asp:TextBox ID="start_time_SAM_add" runat="server"></asp:TextBox>
        <asp:TextBox ID="end_time_SAM_add" runat="server"></asp:TextBox>
        <asp:Button ID="add_match_btn" runat="server" Text="Add" OnClick="add_match_btn_Click" style="width: 80px;margin-left:35px;" />
    <br/>
        <br/>
    <p>
        Delete Match</p>
            <div>
            <span style="padding:1.4em;">host club name</span> <span style="padding:0.5em;">guest club name</span> <span style="padding-left:2.3em;">start time</span> <span style="padding-left:5em;">end time</span></div>
        <asp:TextBox ID="host_name_SAM_del" runat="server"></asp:TextBox>
        <asp:TextBox ID="guest_name_SAM_del" runat="server"></asp:TextBox>
        <asp:TextBox ID="start_time_SAM_del" runat="server"></asp:TextBox>
        <asp:TextBox ID="end_time_SAM_del" runat="server"></asp:TextBox>
        <asp:Button ID="delete_match_btn" runat="server" Text="Delete" OnClick="delete_match_btn_Click" style="width: 80px;margin-left:35px;" />
    <p>
        &nbsp;</p>
        <br/>
        <p>
            Upcoming Matches</p>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br/>
        <p>Already Played Matches</p>
        <asp:GridView ID="GridView2" runat="server">
        </asp:GridView>
        <br/>
        <p>Clubs Never Scheduled to Play Together</p>
        <asp:GridView ID="GridView3" runat="server">
        </asp:GridView>
    </form>
    </body>
</html>
