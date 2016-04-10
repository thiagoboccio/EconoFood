<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Maintenance.aspx.cs" Inherits="EconoFood.Admin.Order.Maintenance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Pedidos</h2>
    <asp:Label runat="server" Text="Pedido" Width="150px" /><asp:TextBox ID="txtPedido" runat="server" Width="100" MaxLength="9" />
    <asp:Label runat="server" Text="Situação Pagamento" Width="150px" /><asp:DropDownList ID="ddlSituacaoPagamento" runat="server" Width="150" /><br />
    <asp:Label runat="server" Text="Data Início" Width="150px" /><asp:TextBox ID="txtDataInicio" runat="server" Width="100" MaxLength="10" />
    <asp:Label runat="server" Text="Situação Envio" Width="150px" /><asp:DropDownList ID="ddlSituacaoEnvio" runat="server" Width="150" /><br />
    <asp:Label runat="server" Text="Data Fim" Width="150px" /><asp:TextBox ID="txtDataFim" runat="server" Width="100" MaxLength="10"/>
    <asp:Label runat="server" Text="Entregador" Width="150px" /><asp:DropDownList ID="ddlEntregador" runat="server" Width="150" /><br /><br />
    <asp:Button ID="btnPesquisar" CssClass="btn btn-lg" runat="server" Text="Pesquisar" OnClick="btnPesquisar_Click" />
    <asp:Button ID="btnDespachar" CssClass="btn btn-lg" runat="server" Text="Despachar" OnClick="btnDespachar_Click" OnClientClick="window.open('dispatch.aspx', 'Teste', 'width=800, heigth=800')" Enabled="False" /><br /><br />
    <br /><br />
    <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="false" Width="800px">
        <Columns>
            <asp:TemplateField HeaderText="Pedido">
                <ItemTemplate>
                    <asp:Label ID="lblIdProduto" runat="server"><%# DataBinder.Eval(Container.DataItem, "IdPedido") %></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Data Pedido">
                <ItemTemplate>
                    <asp:Label ID="lblDataPedido" runat="server"><%# DataBinder.Eval(Container.DataItem, "DataPedido") %></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pagamento">
                <ItemTemplate>
                    <asp:Label ID="lblPagamento" runat="server"><%# DataBinder.Eval(Container.DataItem, "StatusPagamento") %></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Envio">
                <ItemTemplate>
                    <asp:Label ID="lblEnvio" runat="server"><%# DataBinder.Eval(Container.DataItem, "StatusPedido") %></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Data Envio">
                <ItemTemplate>
                    <asp:Label ID="lblDataEnvio" runat="server"><%# DataBinder.Eval(Container.DataItem, "DataRecebimento") %></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Entregador">
                <ItemTemplate>
                    <asp:Label ID="lblEntregador" runat="server"><%# DataBinder.Eval(Container.DataItem, "NomeEntregador") %></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cliente">
                <ItemTemplate>
                    <asp:Label ID="lblNomeCliente" runat="server"><%# DataBinder.Eval(Container.DataItem, "NomeCliente") %></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>            
        </Columns>    
    </asp:GridView>
</asp:Content>
