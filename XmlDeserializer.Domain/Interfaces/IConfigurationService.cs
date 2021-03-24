using Microsoft.Extensions.Configuration;

namespace XmlDeserializer.Domain.Interfaces
{
    public interface IConfigurationService
    {
        IConfiguration Configuration { get; set; }

        string GetConnectionString();
    }
}