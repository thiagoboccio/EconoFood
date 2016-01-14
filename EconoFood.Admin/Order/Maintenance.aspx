<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Maintenance.aspx.cs" Inherits="EconoFood.Admin.Order.Maintenance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" Text="Pedido" Width="150px" /><asp:TextBox ID="txtPedido" runat="server" Width="100" MaxLength="9" />
    <asp:Label runat="server" Text="Situação Pagamento" Width="150px" /><asp:DropDownList runat="server" Width="150" /><br />
    <asp:Label runat="server" Text="Data Início" Width="150px" /><asp:TextBox ID="txtDataInicio" runat="server" Width="100" MaxLength="10" />
    <asp:Label runat="server" Text="Situação Envio" Width="150px" /><asp:DropDownList runat="server" Width="150" /><br />
    <asp:Label runat="server" Text="Data Fim" Width="150px" /><asp:TextBox ID="txtDataFim" runat="server" Width="100" MaxLength="10"/>
    <asp:Label runat="server" Text="Entregador" Width="150px" /><asp:DropDownList runat="server" Width="150" /><br />
    <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" OnClick="btnPesquisar_Click" />
    <asp:GridView runat="server">
    
    </asp:GridView>
</asp:Content>
