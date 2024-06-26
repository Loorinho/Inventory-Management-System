<%@ Page Title="Status" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Status.aspx.cs" Inherits="InentorySystem.Status" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Status</h2>
        <div>
            <asp:label for="txtProduct">Product name:</asp:label>
            <asp:TextBox ID="txtProduct" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnCheckStatus" CssClass="btn btn-primary my-2 btn-sm" runat="server" Text="Check Status" OnClick="btnCheckStatus_Click" />
        </div>
        <div>
            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>