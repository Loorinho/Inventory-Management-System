<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="InentorySystem.Reports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <h2 class="text-center py-4">Your Inventory Report</h2>
   <p ID="productsCount"></p>

   
   <div>
       <span>Total number of products :  </span>
           <asp:Label ID="TotalProducts" runat="server" />  
   </div>
    <div>
    <span>Total quantity in inventory :  </span>
        <asp:Label ID="TotalQuantity" runat="server" />  
</div>
    <div>
    <span>Inventory Value : </span>
        <asp:Label ID="TotalValue" runat="server" />  
</div>
  
</asp:Content>
