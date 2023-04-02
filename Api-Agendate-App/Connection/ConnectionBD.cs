namespace Api_Agendate_App.Connection
{
    public class ConnectionBD
    {
        private string connectionString;

        public ConnectionBD ()
        {
            var appSettings = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            connectionString = appSettings.GetSection("ConnectionStrings:masterconnection").Value;
        }

        public string ConnectionString ()
        {
            return connectionString;
        }
    }
}
