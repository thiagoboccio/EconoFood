<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dispatch.aspx.cs" Inherits="EconoFood.Admin.Order.Dispatch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnPrint" CssClass="btn btn-lg" runat="server" Text="Imprimir" OnClientClick="javascript:window.print();"/><br />        
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
    </div>
    </form>
</body>
</html>
