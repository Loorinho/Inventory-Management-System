<%@ Page Title="Register Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="InentorySystem.Register" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <section class="row">
            <h1 id="aspnetTitle">Registration Form</h1>
        </section>

        <div class="row">
            <section class="col-md-6">
                <div class="form-group">
                    <label for="txtProductName">Product Name:</label>
                    <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtQuantity">Quantity:</label>
                    <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtPrice">Price:</label>
                    <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
               
               
                <div class="form-group">
                    <asp:Button ID="btnRegister" runat="server" Text="Save" CssClass="btn btn-primary mt-2" OnClick="btnRegister_Click" />
                </div>
                <div class="form-group">
                    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
                </div>
            </section>
        </div>
    </main>
</asp:Content>