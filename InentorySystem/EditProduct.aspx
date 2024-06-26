<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="InentorySystem.EditProduct" EnableEventValidation="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <section class="row">
            <h1 id="aspnetTitle">Edit product details </h1>
        </section>


        <form method="post" class="w-50">

            <div class="row">
                <asp:TextBox ID="productId" runat="server" CssClass="form-control" />

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
                    <asp:Button ID="btnSaveChanges" runat="server" Text="Save Changes" CssClass="btn btn-primary mt-2" OnClick="btnSaveChanges_Click" />
                </div>
                <div class="form-group">
                    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
                </div>

            </div>
        </form>

    </main>
</asp:Content>
