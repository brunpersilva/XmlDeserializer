using System;
using Microsoft.Extensions.DependencyInjection;
using XmlDeserializer.Domain.Interfaces;
using XmlDeserializer.CrossCutting;

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

            var repo = _serviceProvider.GetService<IFilmsRepository>();

            repo.Insert(films);
        }

        private static void BuildServiceProvider()
        {
            var services = new ServiceCollection();
            services.Inject();
            _serviceProvider = services.BuildServiceProvider();
        }

    }
}
