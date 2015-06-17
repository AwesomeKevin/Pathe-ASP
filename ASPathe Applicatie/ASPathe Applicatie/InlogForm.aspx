<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InlogForm.aspx.cs" Inherits="ASPathe_Applicatie.InlogForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblGebruikersnaam" runat="server" Text="Gebruikersnaam: "></asp:Label>
        <asp:TextBox ID="tbGebruikersnaam" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblWachtwoord" runat="server" Text="Wachtwoord: "></asp:Label>
        <asp:TextBox ID="tbWachtwoord" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnLogIn" runat="server" Text="Log In" OnClick="btnLogIn_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" OnClick="btnSignUp_Click" />
    
    </div>
    </form>
</body>
</html>
