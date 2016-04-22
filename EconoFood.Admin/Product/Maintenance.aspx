<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Maintenance.aspx.cs" Inherits="EconoFood.Admin.Product.Maintenance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/jquery-1.11.3.js" type="text/javascript"></script>
    <script>
        function UploadFile(fileUpload)
        {
            if (fileUpload.value != '') {
                document.getElementById("<%=btnAdicionarImagem.ClientID %>").click();
        }
    }
    </script>
            <div><br />
                <p>
                    <span>Produto</span><asp:TextBox runat="server" ID="txtPesquisaProduto"></asp:TextBox>
                    <asp:Button CssClass="btn btn-lg" runat="server" Text="Pesquisar" id="btnPesquisarProduto" OnClick="btnPesquisarProduto_Click" />                    
                </p>                
            </div>
    <br />
            <div>
                <asp:GridView ID="gvPesquisaProdutos" runat="server" Width="100%" AutoGenerateColumns="False" OnRowCommand="gvPesquisaProdutos_RowCommand" OnRowDataBound="gvPesquisaProdutos_RowDataBound">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <%--<asp:TemplateField HeaderText="Id">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdProduto") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Produto">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Nome") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Status") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgBtnManutencao" Width="20px" Height="20px" runat="server" ImageUrl="~/Content/Img/1450846683_Working_Tools_2.png" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdProduto") %>' CommandName="Manutencao" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle BackColor="#666666" ForeColor="White" />
        </asp:GridView>
                <br /><asp:Button CssClass="btn btn-lg" runat="server" Text="Novo" id="btnNovoProduto" OnClick="btnNovoProduto_Click" />
            </div>     
    <div id="divManutencao" runat="server" visible="false">
        <h3>Cadastro</h3>
        <p>
            <asp:Label ID="lblProduto" runat="server" Text="Produto" Width="150"/><asp:TextBox runat="server" ID="txtProduto" ToolTip="Nome do Produto"></asp:TextBox><br />
        </p>
        <p>
            <asp:Label ID="lblStatus" runat="server" Text="Status" Width="150"/>
            <asp:DropDownList runat="server" ID="ddlStatus" ToolTip="Status do Produto">
            <asp:ListItem Selected="True" Value="-1">SELECIONE</asp:ListItem>
            <asp:ListItem Value="1">Ativo</asp:ListItem>
            <asp:ListItem Value="0">Inativo</asp:ListItem>
            </asp:DropDownList>        
        </p>        
        <p>
            <asp:Label ID="lblTipoProduto" runat="server" Text="Tipo Produto" Width="150"/>
            <asp:DropDownList runat="server" ID="ddlTipoProduto" ToolTip="Tipo do Produto" DataTextField="Descricao" DataValueField="Id">            
            </asp:DropDownList>        
        </p>
        <p>
            <asp:Label ID="lblDescricao" runat="server" Text="Descrição do Produto" Width="150"/>
            <asp:TextBox TextMode="MultiLine" runat="server" Width="300px" Height="50px" MaxLength="200"></asp:TextBox>
        </p>
        <span>Imagens</span>
        <asp:FileUpload ID="fuImagens" runat="server" ToolTip="Adicione uma foto do produto"/>
        <asp:Button ID="btnAdicionarImagem" Text="Adicionar Imagem" runat="server" OnClick="btnAdicionarImagem_Click" Style="display:none;" />
        <%--<asp:ImageButton ID="imgbtnUpLoader" runat="server" ImageUrl="~/Content/Img/1451865573_Add.png"/>--%>                
        <table id="Imagens" runat="server">
            <tr>
                <td><asp:Image runat="server" ID="imgProduto1" ImageUrl="~/Content/Img/1450850589_Photographer_2.png" Width="128" Height="128" Visible="false"/></td>
                <td><asp:Image runat="server" ID="imgProduto2" ImageUrl="~/Content/Img/1450850589_Photographer_2.png" Width="128" Height="128" Visible="false"/></td>
                <td><asp:Image runat="server" ID="imgProduto3" ImageUrl="~/Content/Img/1450850589_Photographer_2.png" Width="128" Height="128" Visible="false"/></td>
            </tr>
            <tr>
                <td align="center"><asp:ImageButton ImageUrl="~/Content/Img/1451978009_remove-circle-outline.png" runat="server" ID="imgRemoveImagem1" Visible="false" OnClick="imgRemoveImagem1_Click"/></td>
                <td align="center"><asp:ImageButton ImageUrl="~/Content/Img/1451978009_remove-circle-outline.png" runat="server" ID="imgRemoveImagem2" Visible="false" OnClick="imgRemoveImagem2_Click"/></td>
                <td align="center"><asp:ImageButton ImageUrl="~/Content/Img/1451978009_remove-circle-outline.png" runat="server" ID="imgRemoveImagem3" Visible="false" OnClick="imgRemoveImagem3_Click"/></td>
            </tr>
        </table><br />
        <div>
            <asp:Button ID="btnGravar" CssClass="btn btn-lg" Text="Gravar" runat="server" OnClick="btnGravar_Click" />
        </div>
    </div>                
    
</asp:Content>
