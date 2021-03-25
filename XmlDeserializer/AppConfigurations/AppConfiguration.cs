using Microsoft.Extensions.Configuration;

namespace XmlDeserializer.AppConfigurations
{
    public class AppConfiguration : IAppConfiguration
    {
        public string FilmsConnectionString { get; set; }

        public AppConfiguration()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false);

            var configurationService = builder.Build();

            FilmsConnectionString = configurationService.GetConnectionString("FilmsDatabase");
        }


    }
}
