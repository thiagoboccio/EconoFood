<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Showroom.aspx.cs" Inherits="EconoFood.Showroom.Showroom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:GridView runat="server" ID="gvProduto" AutoGenerateColumns="False" ShowHeader="False">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton2" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Nome" />
            <asp:BoundField DataField="" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <asp:Repeater ID="rptProdutos" runat="server">
        <ItemTemplate>
            <div style="float:left;">
                <asp:Image runat="server" ID="imgProduto" /><br />
                <asp:Label runat="server" ID="lblNome" Text=<%# DataBinder.Eval(Container.DataItem, "Nome") %> /><br />
                <asp:Label runat="server" ID="lblPreco" Text=<%# DataBinder.Eval(Container.DataItem, "Preco") %> /><br />
                <asp:Label runat="server" ID="lblDescricao" Text=<%# DataBinder.Eval(Container.DataItem, "Descricao") %> /><br />
                <asp:Button runat="server" Text="Adicionar à lista" />
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
