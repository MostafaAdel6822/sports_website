<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fan.aspx.cs" Inherits="sports_platform.fan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div>
            Fan</div>

    <form id="form1" runat="server">
   <p>View Available Matches Starting From:</p>
        <asp:TextBox ID="starting_time" placeholder="yyyy/MM//dd"  runat="server"></asp:TextBox>
        <asp:Button ID="starting_time_Btn" runat="server" Text="View" OnClick="starting_time_Btn_Click" />
        <br/>
        <p>Available Matches:</p>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br/>
        <br/>
        <p>Purchase A Ticket:</p>
        <p>Match Info:</p>
        <div>host club name</div>
        <asp:TextBox ID="host_name_Fan_purchase" runat="server"></asp:TextBox>
        <div>guest club name</div>
        <asp:TextBox ID="guest_name_Fan_purchase" runat="server"></asp:TextBox>
        <div>start time</div>
        <asp:TextBox ID="start_time_Fan_purchase" placeholder="yyyy/MM/dd hh:mm:ss" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="purchaseTicket_btn" runat="server" Text="Purchase" OnClick="purchaseTicket_btn_Click" />
    </form>
</body>
</html>
