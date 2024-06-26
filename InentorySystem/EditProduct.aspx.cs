using InentorySystem.ProductReference;
using ProductLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace InentorySystem
{
    public partial class EditProduct : System.Web.UI.Page
    {
        private static string connectionString = "Server=;Database=deruzims;User Id=sa; Password=.inhotesT1234.;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string value = Request.QueryString["id"];

                // Check if the value is null or empty
                if (!string.IsNullOrEmpty(value))
                {

                    Product p = LoadProductDetails(Convert.ToInt32(value));

                    txtProductName.Text = p.Name;
                    txtQuantity.Text = p.Quantity.ToString();
                    txtPrice.Text = p.Price.ToString();

                    productId.Text = p.Id.ToString();
                    productId.Style.Add("display", "none");               
                }                
            }
        }

        private Product LoadProductDetails(int id)
        {
            Product product = new Product();
            ProductDatabase productDatabase = new ProductDatabase(connectionString);
            product = productDatabase.GetProductById(id);
            return product;
        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                // Get user input from form controls

                string value = Request.QueryString["id"];

                Product product = new Product();
                product.Id = Convert.ToInt32(value);
                product.Name = txtProductName.Text.Trim();
                product.Quantity = Convert.ToInt32(txtQuantity.Text.Trim());
                product.Price = Convert.ToDecimal(txtPrice.Text.Trim());

                string script = $"console.log({{ id: {product.Id}, name: '{product.Name}', quantity: '{product.Quantity}', price: '{product.Price}' }});";
                ClientScript.RegisterStartupScript(this.GetType(), "LogProduct", script, true);


                ProductDatabase productDatabase = new ProductDatabase(connectionString);

               productDatabase.UpdateProduct(product);

               Response.Redirect("ViewProducts.aspx");
            }
            catch (Exception ex)
            {
                lblMessage.Text = "An error occurred: " + ex.Message;

            }
        }
    }
}