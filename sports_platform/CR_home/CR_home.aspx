﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CR_home.aspx.cs" Inherits="sports_platform.ClubRepresentative.CR_home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div>
         <br />

     <asp:GridView ID="GridView1" runat="server"> </asp:GridView>
     <br />

     <asp:GridView ID="GridView3" runat="server"></asp:GridView>
    <br />
    <asp:Label runat="server" Text="Club"></asp:Label>   
    <br />
    <asp:TextBox ID="Club" runat="server"></asp:TextBox>
    <br />
    <asp:Label runat="server" Text="Stadium"></asp:Label>
    <br />
    <asp:TextBox ID="Stadium" runat="server"></asp:TextBox>
    <br />

    <asp:Label runat="server" Text="Start Time"></asp:Label>
    <br />
    <asp:TextBox ID="StartTime" runat="server"></asp:TextBox>
    <asp:Button ID="sendReq" runat="server" Text="Send Request " OnClick="Send_Request" />
    <br />
   
    <asp:Label runat="server" Text="Date"></asp:Label>
    <br />
    <asp:TextBox ID="searchDate" runat="server"></asp:TextBox>
    <asp:Button ID="search" runat="server" Text="View Available Stadiums" OnClick="View_Available_Stadiums" />

     <asp:GridView ID="GridView2" runat="server"></asp:GridView>



        </div>
    </form>
</body>
</html>

