<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OverzichtForm.aspx.cs" Inherits="ASPathe_Applicatie.OverzichtForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblBioscopen" runat="server" Text="Bioscopen"></asp:Label>
        <br />
        <asp:ListBox ID="lbBioscopen" runat="server" Height="200px" Width="450px"></asp:ListBox>
        <br />
        <br />
        <br />
        <asp:Label ID="lblActeurs" runat="server" Text="Acteurs"></asp:Label>
        <br />
        <asp:ListBox ID="lbActeurs" runat="server" Height="200px" Width="450px"></asp:ListBox>
        <br />
        <br />
        <br />
        <asp:Label ID="lblFilms" runat="server" Text="Films"></asp:Label>
        <br />
        <asp:ListBox ID="lbFilms" runat="server" Height="200px" Width="450px"></asp:ListBox>
    
    </div>
    </form>
</body>
</html>
