using System;
using Microsoft.Extensions.DependencyInjection;
using XmlDeserializer.Domain.Interfaces;
using XmlDeserializer.CrossCutting;
using Microsoft.Extensions.Configuration;

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
            

            var Configurationservice = _serviceProvider.GetService<IConfiguration>();

            string connectionString = Configurationservice.GetConnectionString("FilmsDatabase");

            filmsRepository.Insert(films, connectionString);
        }

        private static void BuildServiceProvider()
        {
            IConfigurationRoot configuration = ConfigureService();

            var services = new ServiceCollection();
            services.Inject();
            services.AddSingleton(configuration);

            _serviceProvider = services.BuildServiceProvider();
        }

        private static IConfigurationRoot ConfigureService()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false);
            var configurationService = builder.Build();
            return configurationService;
        }
    }
}
