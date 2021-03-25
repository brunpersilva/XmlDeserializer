using System;
using Microsoft.Extensions.DependencyInjection;
using XmlDeserializer.Domain.Interfaces;
using XmlDeserializer.CrossCutting;
using XmlDeserializer.AppConfigurations;

namespace XmlDeserializer
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            BuildServiceProvider();

            string company = "marvel";

            var xmlRepository = _serviceProvider.GetService<IXmlRepository>();

            var films = xmlRepository.GetFilms(company);

            var filmsRepository = _serviceProvider.GetService<IFilmsRepository>();           

            filmsRepository.Insert(films);
        }

        private static void BuildServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IAppConfiguration, AppConfiguration>();

            services.Inject();
            _serviceProvider = services.BuildServiceProvider();
        }

        
    }
}
