<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Maintenance.aspx.cs" Inherits="EconoFood.Admin.User.Maintenance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">    
    <p>Usuário</p><br />
    <div>
        <asp:GridView ID="gvUsuario" runat="server" OnPageIndexChanging="gvUsuario_PageIndexChanging" PageSize="15" AutoGenerateColumns="False" Width="800px" OnRowCommand="gvUsuario_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="Nome" DataField="Nome" />
                <asp:BoundField HeaderText="E-mail" DataField="Email" />
                <asp:BoundField HeaderText="Perfil" DataField="Perfil" />
                <asp:BoundField HeaderText="Status" DataField="Status" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Editar" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id") %>' ImageUrl="~/Content/Img/1450846683_Working_Tools_2.png" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button CssClass="btn btn-lg" ID="btnCadastrar" runat="server" Text="Novo" />
    </div><br />
    <div>
        <p><asp:Label Width="154px" runat="server" Text="Nome" /><asp:TextBox ID="txtNome" runat="server" ToolTip="Nome Usuário"></asp:TextBox></p>
        <p><asp:Label Width="150px" runat="server" Text="E-mail" /> <asp:TextBox ID="txtEmail" runat="server" ToolTip="E-mail"></asp:TextBox></p>
        <p><asp:Label Width="150px" runat="server" Text="Senha" /> <asp:TextBox ID="txtSenha" runat="server" ToolTip="Senha"></asp:TextBox></p>
        <p><asp:Label Width="150px" runat="server" Text="Nascimento" /> <asp:TextBox ID="txtDataNascimento" runat="server" ToolTip="Nascimento"></asp:TextBox></p>
        <p><asp:Label Width="150px" runat="server" Text="CPF" /> <asp:TextBox ID="txtCpf" runat="server" ToolTip="Cpf"></asp:TextBox></p>
        <p><asp:Label Width="150px" runat="server" Text="Perfil" /> <asp:DropDownList ID="ddlPerfil" runat="server" DataTextField="Id" DataValueField="Descricao" ToolTip="Perfil"></asp:DropDownList></p>
        <p><asp:Label Width="150px" runat="server" Text="Status" /> <asp:DropDownList ID="ddlStatus" runat="server" ToolTip="Status"></asp:DropDownList></p>
    </div>
    <p><asp:Button CssClass="btn btn-lg" runat="server" Text="Gravar" id="btnGravar" OnClick="btnGravar_Click" /></p>        
</asp:Content>
