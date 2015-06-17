<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KeuzeForm.aspx.cs" Inherits="ASPathe_Applicatie.KeuzeForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblInfo" runat="server" Text="Kies hier het systeem dat u wilt gebruiken"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnBeheren" runat="server" Text="Beheren" />
        <br />
        <br />
        <asp:Button ID="btnKoppelen" runat="server" Text="Koppelen" />
        <br />
        <br />
        <asp:Button ID="btnOverzicht" runat="server" Text="Overzicht" />
        <br />
    
    </div>
    </form>
</body>
</html>
