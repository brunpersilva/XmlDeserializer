using Microsoft.Extensions.Configuration;

namespace XmlDeserializer.AppConfigurations
{
    /// <summary>
    /// Implementation of IAppConfiguration. This class encapsulates configurations to be used throughout the app.
    /// </summary>
    public class AppConfiguration : IAppConfiguration
    {
        public string FilmsConnectionString { get; set; }

        public AppConfiguration()
        {
            //Instanciate and configure a new ConfigurationBuilder to find the connection string in the appsettings.json file.
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false);
            var configurationService = builder.Build();

            //Pass the connection string to the FilmsConnectionString property.
            FilmsConnectionString = configurationService.GetConnectionString("FilmsDatabase");
        }


    }
}
