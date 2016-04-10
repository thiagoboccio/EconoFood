<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Deliveryman.aspx.cs" Inherits="EconoFood.Admin.User.Deliveryman" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>Entregadores</p><br />
    <asp:GridView ID="gvEntregador" runat="server" PageSize="15"></asp:GridView><br />
    <asp:Label Width="150px" runat="server" Text="Usuários" /><asp:DropDownList ID="ddlUsuario" runat="server"></asp:DropDownList><asp:Button CssClass="btn btn-lg" runat="server" Text="Cadastrar" id="btnCadastrar" OnClick="btnCadastrar_Click" />
</asp:Content>
