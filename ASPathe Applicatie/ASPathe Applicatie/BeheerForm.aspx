<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BeheerForm.aspx.cs" Inherits="ASPathe_Applicatie.BeheerForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblFilmAanmaken" runat="server" Text="Film Aanmaken"></asp:Label>
        <br />
        <br />
        <asp:DropDownList ID="ddlFilms" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblTitel" runat="server" Text="Titel: "></asp:Label>
        <asp:TextBox ID="tbTitel" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblGenre" runat="server" Text="Genre: "></asp:Label>
        <asp:TextBox ID="tbGenre" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblTijdsduur" runat="server" Text="Tijdsduur: "></asp:Label>
        <asp:TextBox ID="tbTijdsduur" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblRegisseur" runat="server" Text="Regisseur: "></asp:Label>
        <asp:TextBox ID="tbRegisseur" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblTaalversie" runat="server" Text="Taalversie: "></asp:Label>
        <asp:TextBox ID="tbTaalversie" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblOndertiteling" runat="server" Text="Ondertiteling: "></asp:Label>
        <asp:TextBox ID="tbOndertiteling" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnMaakFilmAan" runat="server" Text="Maak Aan" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnPasFilmAan" runat="server" Text="Pas Aan" />
        <br />
        <br />
        <asp:ListBox ID="lbFilms" runat="server" Height="100px" Width="300px"></asp:ListBox>
        <br />
        <br />
        <br />
        <asp:Label ID="lblActeurAanmaken" runat="server" Text="Acteur Aanmaken"></asp:Label>
        <br />
        <br />
        <asp:DropDownList ID="ddlActeurs" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblVoornaam" runat="server" Text="Voornaam: "></asp:Label>
        <asp:TextBox ID="tbVoornaam" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblAchternaam" runat="server" Text="Achternaam: "></asp:Label>
        <asp:TextBox ID="tbAchternaam" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblGeboortedatum" runat="server" Text="Geboortedatum: "></asp:Label>
        <asp:TextBox ID="tbGeboortedatum" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnMaakActeurAan" runat="server" Text="Maak Aan" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnPasActeurAan" runat="server" Text="Pas Aan" />
        <br />
        <br />
        <asp:ListBox ID="lbActeurs" runat="server" Height="100px" Width="300px"></asp:ListBox>
        <br />
        <br />
        <br />
        <asp:Label ID="lblBioscoopAanmaken" runat="server" Text="Bioscoop Aanmaken"></asp:Label>
        <br />
        <br />
        <asp:DropDownList ID="ddlBioscopen" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblBioscoopnaam" runat="server" Text="Bioscoopnaam: "></asp:Label>
        <asp:TextBox ID="tbBioscoopnaam" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblGenre0" runat="server" Text="Plaats: "></asp:Label>
        <asp:TextBox ID="tbPlaats" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblTijdsduur0" runat="server" Text="Adres: "></asp:Label>
        <asp:TextBox ID="tbAdres" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblRegisseur0" runat="server" Text="Postcode: "></asp:Label>
        <asp:TextBox ID="tbPostcode" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnMaakBioscoopAan" runat="server" Text="Maak Aan" OnClick="btnMaakBioscoopAan_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnPasBioscoopAan" runat="server" Text="Pas Aan" />
        <br />
        <br />
        <asp:ListBox ID="lbBioscopen" runat="server" Height="100px" Width="300px"></asp:ListBox>
    
    </div>
    </form>
</body>
</html>
