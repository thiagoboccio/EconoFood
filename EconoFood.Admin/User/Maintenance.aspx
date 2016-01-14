<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Maintenance.aspx.cs" Inherits="EconoFood.Admin.User.Maintenance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">    
    <p>Usuário <asp:Button CssClass="btn btn-lg" runat="server" Text="Pesquisar" id="btnPesquisarProduto" OnClick="btnPesquisarProduto_Click" /></p>        
    <div>
        <asp:GridView ID="gvUsuario" runat="server"></asp:GridView>
        <asp:Button ID="btnCadastrar" runat="server" Text="Novo" />
    </div>
    <div>
        <p><asp:Label Width="150px" runat="server" Text="Nome" /><asp:TextBox ID="txtNome" runat="server"></asp:TextBox></p>
        <p><asp:Label Width="150px" runat="server" Text="E-mail" /> <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></p>
        <p><asp:Label Width="150px" runat="server" Text="Perfil" /> <asp:DropDownList ID="ddlPerfil" runat="server"></asp:DropDownList></p>
    </div>
    
</asp:Content>
