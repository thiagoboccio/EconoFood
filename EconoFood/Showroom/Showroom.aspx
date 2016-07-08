<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Showroom.aspx.cs" Inherits="EconoFood.Showroom.Showroom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%@ MasterType
        virtualpath="~/Site.Master" 
    %>
    <div style="margin-top:100px">
    <asp:ListView ID="lstViewProduto" runat="server" OnItemDataBound="lstViewProduto_ItemDataBound" GroupItemCount="3" GroupPlaceholderID="groupPlaceholder" ItemPlaceholderID="itemPlaceholder" OnItemCommand="lstViewProduto_ItemCommand">
        <LayoutTemplate>
            <table>
                 <tr ID="groupPlaceholder" runat="server">
                 </tr>
            </table>
        </LayoutTemplate>
        <GroupTemplate>
            <tr>
                <td ID="itemPlaceholder" runat="server">
                            
                </td>
            </tr>
        </GroupTemplate>
        <ItemTemplate>            
            <td align="center">                            
                <asp:ImageButton ID="imgProduto" runat="server" /><br />
                <a href="../Product/Detail.aspx?id=<%# DataBinder.Eval(Container.DataItem, "IdProduto") %>">
                    <%# DataBinder.Eval(Container.DataItem, "Nome") %>
                </a><br />
                <%--<span>
                    <b>Preço: </b><%# String.Format("{0:c}", DataBinder.Eval(Container.DataItem, "Detalhe.ValorVenda")) %>
                </span>--%>                            
                <asp:LinkButton runat="server" ID="lk" Text="Adicionar ao carrinho" CommandName="Add" Font-Bold="true" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdProduto") %>'></asp:LinkButton>
                <%--<asp:LinkButton ID="lkAddToCart" Font-Bold="true" runat="server" Text="Adicionar ao carrinho" CommandName="add" CommandArgument="<%# DataBinder.Eval(Container.DataItem, "Produto.IdProduto") %>" />--%>
            </td>
        </ItemTemplate>
        <GroupSeparatorTemplate>
              <tr runat="server">
                <td colspan="3"><hr /></td>
              </tr>
        </GroupSeparatorTemplate>        
    </asp:ListView>        
    </div>
</asp:Content>
