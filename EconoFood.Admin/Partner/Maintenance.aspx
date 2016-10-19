<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Maintenance.aspx.cs" Inherits="EconoFood.Admin.Partner.Maintenance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    Nome:<asp:TextBox ID="txtNome" runat="server"></asp:TextBox><br />
    Status:<asp:DropDownList runat="server" ID="ddlStatus"></asp:DropDownList><br />
    URL para consulta de produtos:<asp:TextBox ID="txtURLConsulta" runat="server"></asp:TextBox><br />
    URL filiada:<asp:TextBox ID="txtURLFiliada" runat="server"></asp:TextBox><br />
    Logotipo:<asp:FileUpload ID="uploadLogotipo" runat="server" CssClass="direita" /><br />
    <asp:Button ID="btnGravar" runat="server" Text="Gravar" CssClass="btn btn-lg" OnClick="btnGravar_Click" />
</asp:Content>
