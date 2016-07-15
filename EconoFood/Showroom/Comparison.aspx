<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comparison.aspx.cs" Inherits="EconoFood.Showroom.Comparison" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%@ MasterType
        virtualpath="~/Site.Master" 
    %>
    <asp:GridView ID="gv1" runat="server"></asp:GridView>
    <asp:GridView ID="gv2" runat="server"></asp:GridView>
    <asp:GridView ID="gv3" runat="server"></asp:GridView>
</asp:Content>
