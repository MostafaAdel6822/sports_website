<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fan.aspx.cs" Inherits="sports_platform.fan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div>
            Fan</div>
        <div>Name of user</div>
    <form id="form1" runat="server">
    <p>View Available Matches Starting From:</p>
        <asp:TextBox ID="starting_time" runat="server"></asp:TextBox>
        <asp:Button ID="starting_time_Btn" runat="server" Text="View" OnClick="starting_time_Btn_Click" />
        <br/>
        <p>Available Matches:</p>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br/>
        <br/>
        <p>Purchase A Ticket</p>
        <p>Match Info:</p>
        <div>
        <span style="padding:1.4em;">host club name</span> <span style="padding:0.5em;">guest club name</span> <span style="padding-left:2.3em;">start time</span></div>
        <div>
        <asp:TextBox ID="host_name_Fan_purchase" runat="server"></asp:TextBox>
        <asp:TextBox ID="guest_name_Fan_purchase" runat="server"></asp:TextBox>
        <asp:TextBox ID="start_time_Fan_purchase" runat="server"></asp:TextBox>
            <asp:Button ID="purchaseTicket_btn" runat="server" Text="Purchase" OnClick="purchaseTicket_btn_Click" />
           </div>
    </form>
</body>
</html>
