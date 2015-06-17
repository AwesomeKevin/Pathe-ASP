<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KoppelForm.aspx.cs" Inherits="ASPathe_Applicatie.KoppelForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblKoppelActeur" runat="server" Text="Koppel Acteur"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblActeur" runat="server" Text="Acteur: "></asp:Label>
        <asp:DropDownList ID="ddlActeur" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblFilm" runat="server" Text="Film: "></asp:Label>
        <asp:DropDownList ID="ddlFilm" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btnKoppelActeur" runat="server" Text="Koppel" />
        <br />
        <br />
        <br />
        <asp:Label ID="lblKoppelZaal" runat="server" Text="Koppel Zaal"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblBioscoop" runat="server" Text="Bioscoop: "></asp:Label>
        <asp:DropDownList ID="ddlBioscoop" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblZaalnummer" runat="server" Text="Zaalnummer: "></asp:Label>
        <asp:TextBox ID="tbZaalnummer" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblAantalStoelen" runat="server" Text="Aantal Stoelen: "></asp:Label>
        <asp:TextBox ID="tbAantalStoelen" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnKoppelZaal" runat="server" Text="Koppel" />
        <br />
        <br />
        <br />
        <asp:Label ID="lblKoppelTarief" runat="server" Text="Koppel Tarief"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblBioscoop2" runat="server" Text="Bioscoop: "></asp:Label>
        <asp:DropDownList ID="ddlBioscoop2" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblTariefNormaal" runat="server" Text="Tarief Normaal: "></asp:Label>
        <asp:TextBox ID="tbTariefNormaal" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblTariefIMAX" runat="server" Text="Tarief IMAX: "></asp:Label>
        <asp:TextBox ID="tbTariefIMAX" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnKoppelTarief" runat="server" Text="Koppel" />
        <br />
        <br />
        <br />
        <asp:Label ID="lblVoordeelticket" runat="server" Text="Koppel Voordeelticket"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblBioscoop3" runat="server" Text="Bioscoop: "></asp:Label>
        <asp:DropDownList ID="ddlBioscoop3" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblVoordeelticketNaam" runat="server" Text="Voordeelticket Naam: "></asp:Label>
        <asp:TextBox ID="tbVoordeelticketNaam" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblVoordeelticketPrijs" runat="server" Text="Voordeelticket Prijs: "></asp:Label>
        <asp:TextBox ID="tbVoordeelticketPrijs" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnKoppelVoordeelticket" runat="server" Text="Koppel" />
    
    </div>
    </form>
</body>
</html>
