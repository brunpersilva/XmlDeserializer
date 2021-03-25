using Microsoft.Extensions.DependencyInjection;
using XmlDeserializer.Domain.Entities;
using XmlDeserializer.Domain.Interfaces;
using XmlDeserializer.Infra.Repositories;
using XmlDeserializer.Repositories;

namespace XmlDeserializer.CrossCutting
{
    public static class DependencyInjection
    {
        public static void Inject(this ServiceCollection services)
        {
            services.AddSingleton<IFilmsRepository, FilmsRepository>();
            services.AddSingleton<IXmlRepository, XmlRepository>();
        }
    }
}
