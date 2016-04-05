<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Maintenance.aspx.cs" Inherits="EconoFood.Admin.User.Maintenance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">    
    <p>Usuário</p><br />
    <div>
        <asp:GridView ID="gvUsuario" runat="server" OnPageIndexChanging="gvUsuario_PageIndexChanging" PageSize="15"></asp:GridView>
        <br />
        <asp:Button CssClass="btn btn-lg" ID="btnCadastrar" runat="server" Text="Novo" />
    </div><br />
    <div>
        <p><asp:Label Width="150px" runat="server" Text="Nome" /><asp:TextBox ID="txtNome" runat="server"></asp:TextBox></p>
        <p><asp:Label Width="150px" runat="server" Text="E-mail" /> <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></p>
        <p><asp:Label Width="150px" runat="server" Text="Senha" /> <asp:TextBox ID="txtSenha" runat="server"></asp:TextBox></p>
        <p><asp:Label Width="150px" runat="server" Text="Perfil" /> <asp:DropDownList ID="ddlPerfil" runat="server" DataTextField="Id" DataValueField="Descricao"></asp:DropDownList></p>
        <p><asp:Label Width="150px" runat="server" Text="Status" /> <asp:DropDownList ID="ddlStatus" runat="server"></asp:DropDownList></p>
    </div>
    <p><asp:Button CssClass="btn btn-lg" runat="server" Text="Gravar" id="btnGravar" OnClick="btnGravar_Click" /></p>        
</asp:Content>
