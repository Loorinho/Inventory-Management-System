using System;
using System.ServiceProcess;
using System.Timers;
using System.Configuration; 
using ProductLibrary;
using System.IO;
using System.Data.SqlClient;

namespace ProductService
{
    public partial class ProductWindowsService : ServiceBase
    {
        private System.Timers.Timer timer;
        private ProductQueue queueProcessor;
        private ProductDatabase db;
        private string connectionString;
        private string logFilePath = @"C:\Users\Jacobson Loor\source\repos\InentorySystem\Logs\ServiceLogs.txt";


        public ProductWindowsService()
        {
            InitializeComponent();

            queueProcessor = new ProductQueue();


            connectionString = ConfigurationManager.AppSettings["ConnectionString"];

            db = new ProductDatabase(connectionString);
        }

        protected override void OnStart(string[] args)
        {
            timer = new System.Timers.Timer();
            timer.Interval = 30000;
            timer.Elapsed += OnElapsedTime;
            timer.Start();

            Log("Service Started");
        }

        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            try
            {
                ProductDetails details = queueProcessor.ReceiveMessage();
                if (details != null)
                {
                    db.AddProduct(details);
                    Log($"Product added successfully: {details.Name}");
                }
            }
            catch (SqlException sqlEx)
            {
                Log($"SQL Error processing queue message: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                Log($"Error processing queue message: {ex.Message}");
            }
        }

        protected override void OnStop()
        {
            timer.Stop();
            timer.Dispose();
            Log("Service Stopped");
        }

        private void Log(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    string logEntry = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} - {message}";
                    writer.WriteLine(logEntry);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write to log: {ex.Message}");
            }
        }
    }
}