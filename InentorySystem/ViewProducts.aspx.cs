using ProductLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InentorySystem
{
    public partial class ViewProducts : System.Web.UI.Page
    {
        private static string connectionString = "Server=;Database=deruzims;User Id=sa; Password=.inhotesT1234.;";

        //public List<Product> products;
       
        protected void Page_Load(object sender, EventArgs e)
        {

            List<Product> products = GetAllProducts();


            Table table = new Table();
            table.CssClass = "table table-striped table-bordered";

            TableRow headerRow = new TableRow();
            headerRow.CssClass = "bg-gray text-white";
            headerRow.Cells.Add(new TableCell { Text = "Name" });
            headerRow.Cells.Add(new TableCell { Text = "UnitPrice" });
            headerRow.Cells.Add(new TableCell { Text = "Quantity" });
            headerRow.Cells.Add(new TableCell { Text = "Category" });
            headerRow.Cells.Add(new TableCell { Text = "Status" });
            headerRow.Cells.Add(new TableCell { Text = "Action" });
            table.Rows.Add(headerRow);

            for (int i = 0; i < products.Count; i++)
            {
                TableRow row = new TableRow();
                //row.Attributes.Add("class", "table-row");

                row.Cells.Add(new TableCell { Text = products[i].Name.ToString() });
                row.Cells.Add(new TableCell { Text = products[i].Price.ToString("C") });
                row.Cells.Add(new TableCell { Text = products[i].Quantity.ToString() });
                row.Cells.Add(new TableCell { Text = products[i].CategoryName.ToString() });
                row.Cells.Add(new TableCell { Text = products[i].Status.ToString() });
                row.Cells.Add(new TableCell { Text = $"<a href='/EditProduct?id={products[i].Id}'>Edit</a>" });


                table.Rows.Add(row);
            }

            phProducts.Controls.Add(table);

        }

        List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            ProductDatabase productDatabase = new ProductDatabase(connectionString);
            products = productDatabase.GetProducts();
            return products;
        }
    }
}