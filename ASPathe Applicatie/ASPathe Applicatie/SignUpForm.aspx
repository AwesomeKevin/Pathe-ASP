<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUpForm.aspx.cs" Inherits="ASPathe_Applicatie.SignUpForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblSignUp" runat="server" Text="Sign Up"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblID" runat="server" Text="ID: "></asp:Label>
        <asp:TextBox ID="tbID" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblVoornaam" runat="server" Text="Voornaam: "></asp:Label>
        <asp:TextBox ID="tbVoornaam" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblTussenvoegsel" runat="server" Text="Tussenvoegsel: "></asp:Label>
        <asp:TextBox ID="tbTussenvoegsel" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblAchternaam" runat="server" Text="Achternaam: "></asp:Label>
        <asp:TextBox ID="tbAchternaam" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblGeboortedatum" runat="server" Text="Geboortedatum: "></asp:Label>
        <asp:TextBox ID="tbGeboortedatum" runat="server"></asp:TextBox>
        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        <br />
        <asp:Label ID="lblGebruikersnaam" runat="server" Text="Gebruikersnaam: "></asp:Label>
        <asp:TextBox ID="tbGebruikersnaam" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblWachtwoord" runat="server" Text="Wachtwoord: "></asp:Label>
        <asp:TextBox ID="tbWachtwoord" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblEmail" runat="server" Text="E-mail: "></asp:Label>
        <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" OnClick="btnSignUp_Click" />
    
    &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAnnuleer" runat="server" OnClick="btnAnnuleer_Click" Text="Annuleer" />
    
    </div>
    </form>
</body>
</html>
