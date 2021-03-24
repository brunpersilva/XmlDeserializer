using Microsoft.Extensions.Configuration;
using XmlDeserializer.Domain.Interfaces;

namespace XmlDeserializer.Domain.Entities
{
    public class ConfigurationService : IConfigurationService
    {
        public IConfiguration Configuration { get; set; }

        public ConfigurationService()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false);
            Configuration = builder.Build();
        }

        public string GetConnectionString()
        {
            return Configuration.GetConnectionString("FilmsDatabase");
        }
    }
}
