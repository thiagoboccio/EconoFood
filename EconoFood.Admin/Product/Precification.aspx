<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Precification.aspx.cs" Inherits="EconoFood.Admin.Product.Precification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Precificação</h3>
    <p>
        <asp:Label ID="lblPrecificacao" runat="server" Text="Produto" Width="150"/>
        <asp:DropDownList runat="server" ID="ddlProduto" ToolTip="Produto" DataTextField="Nome" DataValueField="IdProduto" OnSelectedIndexChanged="ddlProduto_SelectedIndexChanged">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="lblValorCompra" runat="server" Text="Valor de Compra" Width="150"/><asp:TextBox runat="server" ID="txtValorCompra" ToolTip="Valor de Compra"></asp:TextBox><br />
    </p>
    <p>
        <asp:Label ID="lblValorVenda" runat="server" Text="Valor Venda" Width="150"/><asp:TextBox runat="server" ID="txtValorVenda" ToolTip="Valor de Venda"></asp:TextBox><br />
    </p>
    <p>
        <asp:Label ID="lblPercentualAplicado" runat="server" Text="Percentual Aplicado" Width="150"/><asp:TextBox runat="server" ID="txtPercentualAplicado" ToolTip="Percentual Aplicado"></asp:TextBox><br />
    </p>
    <p>
        <asp:Label ID="lblDataInicio" runat="server" Text="Data Início" Width="150"/><asp:TextBox runat="server" ID="txtDataInicio" ToolTip="Nome do Produto"></asp:TextBox><br />
    </p>
    <p>
        <asp:Button ID="btnGravar" CssClass="btn btn-lg" Text="Gravar" runat="server" OnClick="btnGravar_Click" />
    </p>
    <asp:GridView runat="server" ID="gvPrecificacao"></asp:GridView>    
</asp:Content>
