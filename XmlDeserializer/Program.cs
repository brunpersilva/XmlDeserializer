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

            //Configurando para buscar a connection string
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false);
            var configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("FilmsDatabase");

            filmsRepository.Insert(films, connectionString);
        }

        private static void BuildServiceProvider()
        {
            var services = new ServiceCollection();
            services.Inject();
            _serviceProvider = services.BuildServiceProvider();
        }

    }
}
