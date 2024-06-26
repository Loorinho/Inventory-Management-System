using InentorySystem.ProductReference;
using System;

namespace InentorySystem
{
    public partial class Status : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnCheckStatus_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtProduct.Text.Trim();


                ProductServiceSoapClient apiClient = new ProductServiceSoapClient();


                string result = apiClient.GetStatus(name);

                //result
                lblStatus.Text = result;
            }
            catch (Exception ex)
            {
                lblStatus.Text = "An error occurred: " + ex.Message;

            }
        }
    }
}