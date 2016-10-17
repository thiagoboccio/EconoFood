<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comparison.aspx.cs" Inherits="EconoFood.Showroom.Comparison" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%@ MasterType
        virtualpath="~/Site.Master" 
    %>
    <div>
        <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="Produto">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Nome") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Valor">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Detalhe.ValorVenda") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>                
            </Columns>
        </asp:GridView>
        <div class="direita">
            Frete:<asp:label runat="server" ID="lblFrete1"></asp:label>
            Total:<asp:label runat="server" ID="lblTotal1"></asp:label>
            <asp:Button ID="btnComprar1" runat="server" Text="IR À LOJA" />
        </div>
    </div> 
    <div>
        <asp:GridView ID="gv2" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="Produto">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Nome") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Valor">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Detalhe.ValorVenda") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>                
            </Columns>
        </asp:GridView>
        <div class="direita">
        Frete:<asp:label runat="server" ID="lblFrete2"></asp:label>
        Total:<asp:label runat="server" ID="lblTotal2"></asp:label>
        <asp:Button ID="btnComprar2" runat="server" Text="IR À LOJA" />
        </div>
    </div>
    <div>
        <asp:GridView ID="gv3" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="Produto">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Nome") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Valor">
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Detalhe.ValorVenda") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>                
            </Columns>
        </asp:GridView>
        <div class="direita">
        Frete:<asp:label runat="server" ID="lblFrete3"></asp:label>
        Total:<asp:label runat="server" ID="lblTotal3"></asp:label>
        <asp:Button ID="btnComprar3" runat="server" Text="IR À LOJA" />
        </div>
    </div>
</asp:Content>
