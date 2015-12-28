<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EconoFood._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:TextBox runat="server" ID="txtPesquisaProduto" ></asp:TextBox>
        <asp:Button CssClass="btn btn-primary btn-lg" runat="server" Text="Pesquisar" id="btnPesquisarProduto" OnClick="btnPesquisarProduto_Click" />
    </div>
    <div class="jumbotron">
        <asp:GridView ID="gvPesquisaProdutos" runat="server" Width="100%" AutoGenerateColumns="true" OnRowDataBound="gvPesquisaProdutos_RowDataBound"></asp:GridView>
    </div>

</asp:Content>
