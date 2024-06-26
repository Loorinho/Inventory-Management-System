using InentorySystem.ProductReference;
using System;

namespace InentorySystem
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                // Get user input from form controls
                string product = txtProductName.Text.Trim();
                int quantity = Convert.ToInt32(txtQuantity.Text.Trim());
                decimal price = Convert.ToDecimal(txtPrice.Text.Trim());
                

                // Create an instance of the API service client
                ProductServiceSoapClient apiClient = new ProductServiceSoapClient();


                string result = apiClient.AddProduct(product, quantity, price);


                lblMessage.Text = result;
            }
            catch (Exception ex)
            {
                lblMessage.Text = "An error occurred: " + ex.Message;

            }
        }
    }
}