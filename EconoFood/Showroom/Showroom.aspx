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
            <asp:BoundField DataField="Descricao" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    Monte a sua lista de compras:<br />
    produto 1 - produto 2<br />
    produto 1 - produto 2<br />
    produto 1 - produto 2<br />
    produto 1 - produto 2<br />
    produto 1 - produto 2<br /><br />
    Lista de compra:<br />
    produto 1(2) - produto 2(3)<br />
    produto 1(1) - produto 2(1)<br /><br />
    Buscar melhores preços<br />
    Melhor preço: R$150 - EXTRA Supermercados<br />
    R$165 - Sonda | R$168 - Mambo | R$170 - Pão de Açucar<br />
    Os valores são aproximados, dependem de cadastro no site do fornecedor para confirmação. Frete não incluso.
</asp:Content>
