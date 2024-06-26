using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Data;
using System.Globalization;

namespace ProductLibrary
{
    public class ProductDatabase
    {
        private string connectionString;

        public ProductDatabase(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void AddProduct(ProductDetails productDetails)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Product (name, quantity, price, category_id, status) VALUES (@Name, @Quantity, @Price, @Category, @Status)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", productDetails.Name);
                        command.Parameters.AddWithValue("@Quantity", productDetails.Quantity);
                        command.Parameters.AddWithValue("@Price", productDetails.Price);
                        command.Parameters.AddWithValue("@Category", 1);
                        command.Parameters.AddWithValue("@Status", "Saved");

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Log SQL exception
                string errorMessage = $"SQL Error registering user: {sqlEx.Message}, Code: {sqlEx.Number}, State: {sqlEx.State}, Line: {sqlEx.LineNumber}";
                throw new Exception(errorMessage, sqlEx);
            }
            catch (Exception ex)
            {

                throw new Exception("Error registering user", ex);
            }
        }

        public bool IsProductRegistered(string name)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Product WHERE name = @Name";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Log SQL exception
                string errorMessage = $"SQL Error checking user registration: {sqlEx.Message}, Code: {sqlEx.Number}, State: {sqlEx.State}, Line: {sqlEx.LineNumber}";
                throw new Exception(errorMessage, sqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Error checking user registration", ex);
            }
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Product";

                    //     string q2 = "SELECT p.id as ID, p.name as Name, p.quantity as Quantity, p.price as Price, p.status as Status, c.category_name as Category " +
                    //"FROM Product p " +
                    //"JOIN ProductCategory c ON p.category_id = c.id " +
                    //"WHERE p.id = @productId;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Product product = new Product
                                {
                                    Name = reader["name"].ToString(),
                                    Quantity = (int)reader["quantity"],
                                    Price = (decimal)reader["price"],
                                    CategoryName = (int)reader["category_id"] == 1 ? "Electronics" : "Other",
                                    Status = reader["status"].ToString(),
                                    Id = (int)reader["id"]
                                };
                                products.Add(product);
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Log SQL exception
                string errorMessage = $"SQL Error getting products: {sqlEx.Message}, Code: {sqlEx.Number}, State: {sqlEx.State}, Line: {sqlEx.LineNumber}";
                throw new Exception(errorMessage, sqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting products", ex);
            }
            return products;
        }

        public Product GetProductById(int productId)
        {
            Product product = new Product();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Product WHERE id = @productId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@productId", productId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                product.Name = reader["name"].ToString();
                                product.Quantity = (int)reader["quantity"];
                                product.Price = (decimal)reader["price"];
                                product.CategoryName = (int)reader["category_id"] == 1 ? "Electronics" : "Other";
                                product.Status = reader["status"].ToString();
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Log SQL exception
                string errorMessage = $"SQL Error getting product: {sqlEx.Message}, Code: {sqlEx.Number}, State: {sqlEx.State}, Line: {sqlEx.LineNumber}";
                throw new Exception(errorMessage, sqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting product", ex);
            }
            return product;
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Product SET name = @Name, quantity = @Quantity, price = @Price, category_id = @Category, status = @Status WHERE id = @Id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", product.Name);
                        command.Parameters.AddWithValue("@Quantity", product.Quantity);
                        command.Parameters.AddWithValue("@Price", product.Price);
                        command.Parameters.AddWithValue("@Category", 1);
                        command.Parameters.AddWithValue("@Status", "Saved");
                        command.Parameters.AddWithValue("@Id", product.Id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Log SQL exception
                string errorMessage = $"SQL Error updating product: {sqlEx.Message}, Code: {sqlEx.Number}, State: {sqlEx.State}, Line: {sqlEx.LineNumber}";
                throw new Exception(errorMessage, sqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating product", ex);
            }
        }

        public Dictionary<string, string> GetReportDetails()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(
                "SELECT p.id as ID, p.name as Name, p.quantity as Quantity, p.price as Price, c.category_name as Category,p.status as Status FROM Product p JOIN ProductCategory c ON p.category_id = c.id;", connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            int totalProducts = dt.Rows.Count;
            int totalQuantity = 0;
            decimal totalValue = 0;


            foreach (DataRow row in dt.Rows)
            {
                totalQuantity += (int)row["Quantity"];
                totalValue += (decimal)row["Price"] * (int)row["Quantity"];
            }

            CultureInfo ugxCulture = new CultureInfo("en-UG");
            ugxCulture.NumberFormat.CurrencySymbol = "UGX";
            ugxCulture.NumberFormat.CurrencyDecimalDigits = 0; // No decimal digits for UGX

            // Convert to currency format
            string formattedAmount = totalValue.ToString("C", ugxCulture);

            Dictionary<string, string> reportDetails = new Dictionary<string, string>();
            reportDetails.Add("TotalProducts", totalProducts.ToString());
            reportDetails.Add("TotalQuantity", totalQuantity.ToString());
            reportDetails.Add("TotalValue", formattedAmount);

            return reportDetails;

        }
    }
}
