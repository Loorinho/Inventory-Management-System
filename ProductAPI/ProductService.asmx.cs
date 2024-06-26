using System.Web.Services;
using ProductLibrary;

namespace ProductAPI
{
    /// <summary>
    /// Summary description for ProductService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ProductService : System.Web.Services.WebService
    {
        private static string connectionString = "Server=;Database=deruzims;User Id=sa; Password=.inhotesT1234.;";
        private ProductQueue queueProcessor = new ProductQueue();
        private ProductDatabase registrationDB = new ProductDatabase(connectionString);

        [WebMethod]
        public string AddProduct(string product, int quantity, decimal price)
        {
          

            ProductDetails productDetails = new ProductDetails
            {
                Name = product,
                Quantity = quantity,
                Price = price,
                
            };

            queueProcessor.SendMessage(productDetails);

            return "Your product is being processed.";
        }
        [WebMethod]
        public string GetStatus(string name)
        {
            if (queueProcessor.IsProductInQueue(name))
            {
                return "Product addition is pending.";
            }
            if (registrationDB.IsProductRegistered(name))
            {
                return "Product added successfully.";
            }

            return "No product with that name found. Try again!!!";
        }

        //[WebMethod]
        //public 
    }
}
