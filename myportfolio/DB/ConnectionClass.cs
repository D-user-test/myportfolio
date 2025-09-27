namespace Cdoe_SAS.DB
{
    public class ConnectionClass
    {
        public static IConfiguration Configuration { get; set; }

        public string getConnection()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            Configuration = builder.Build();   
            return Configuration.GetConnectionString("defaultconnection");
        }
        

     

        public string GetEncryptkeyvalue()
        {
            if (Configuration == null)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

                Configuration = builder.Build();
            }

            return Configuration["eKey:KEYVALUE"];
        }

        public string GetEncryptivvalue()
        {
            if (Configuration == null)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

                Configuration = builder.Build();
            }

            return Configuration["eKey:IVVALUE"];
        }
    }
}
