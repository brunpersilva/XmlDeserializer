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

            string studio = "marvel";

            //Gets a XmlRepositories from dependency injection using ServiceProvider class
            var xmlRepository = _serviceProvider.GetService<IXmlRepository>();

            //Pass the studio name to the GetFilms method
            var films = xmlRepository.GetFilms(studio);

            //Gets a FilmsRepository from dependency injection using ServiceProvider class
            var filmsRepository = _serviceProvider.GetService<IFilmsRepository>();

            //Pass films to the Insert method
            filmsRepository.Insert(films);

        }

        /// <summary>
        /// Builds services to be used in the app.
        /// </summary>
        private static void BuildServiceProvider()
        {
            //New instance of ServiceCollection
            var services = new ServiceCollection();

            //Adds a singleton service of AppConfiguration
            services.AddSingleton<IAppConfiguration, AppConfiguration>();

            //Injects the remaining services
            services.Inject();

            //Pass services to the private property IServiceProvider
            _serviceProvider = services.BuildServiceProvider();
        }

        
    }
}
