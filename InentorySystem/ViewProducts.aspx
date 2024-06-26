<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewProducts.aspx.cs" Inherits="InentorySystem.ViewProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h3 class="text-center py-4">Your products </h3>

        <asp:PlaceHolder ID="phProducts" runat="server"></asp:PlaceHolder>



    </main>
</asp:Content>
