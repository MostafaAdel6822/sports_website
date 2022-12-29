<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StadiumManager.aspx.cs" Inherits="sports_platform.StadiumManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="direction: ltr">
            Logged in as a Stadium Manager
            <br />
            Stadium Information
            <br />
            <asp:GridView ID="GridView1" runat="server" style="margin-left: 0px" Width="278px">
            </asp:GridView>
            <br />
            All Received Requests<br />
            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>
            <br />
            Host Club Name
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            Guest Club Name
            <br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            Match Start Time       
            <br />
            <asp:TextBox ID="TextBox3" placeholder="yyyy/MM/dd hh:mm:ss" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="acceptrequest" runat="server" OnClick="Accept_Request" Text="Accept Request" Width="168px" />
            <br />
            <asp:Button ID="rejectrequest" runat="server" OnClick="Reject_Request" Text="Reject Request" />
            <br />
        </div>
    </form>
</body>
</html>