<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="sports_platform.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"> 
    <style >        .center {
            position: absolute;
            top:50%;
            left:50%;
            transform: translate(-50%,-50%);

        }
</style>
    <title></title>
</head>
<body style="background-color:#f5ecc1;" class="center">

    <form id="form1" runat="server">
        
        <div >
       
            <p>Please Login</p>
                    <p>
            Username:</p>
        <asp:TextBox ID="username" runat="server"></asp:TextBox>
        <p>
            Password:</p>
        <asp:TextBox ID="password" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="loginBtn" runat="server" Text="Login" OnClick="loginBtn_Click"/>
            <br/>
            <br/>
            <br/>
            Register As</div>
        <br/>
        <asp:Button ID="register_SAM" runat="server" Text="Sports Association Manager" OnClick="register_SAM_Click"/>
        <br />
        <asp:Button ID="register_CR" runat="server" Text="Club Representative" OnClick="register_CR_Click"/>
        <br />
        <asp:Button ID="register_SM" runat="server" Text="Stadium Manager" OnClick="register_SM_Click"/>
        <br />
        <asp:Button ID="register_fan" runat="server" Text="Fan" OnClick="register_fan_Click"/>
        <br/>
    </form>
</body>

</html>
