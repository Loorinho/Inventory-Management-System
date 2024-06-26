using ProductLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InentorySystem
{
    public partial class Reports : System.Web.UI.Page
    {
        private static string connectionString = "Server=;Database=deruzims;User Id=sa; Password=.inhotesT1234.;";
        protected void Page_Load(object sender, EventArgs e)
        {

            Dictionary<string, string> reportData = GenerateReport();

            TotalProducts.Text = reportData["TotalProducts"];
            TotalQuantity.Text = reportData["TotalQuantity"];
            TotalValue.Text = reportData["TotalValue"];

        }

        public Dictionary<string, string> GenerateReport()
        {
            ProductDatabase productsRepository = new ProductDatabase(connectionString);
            return productsRepository.GetReportDetails();

        }
    }
}