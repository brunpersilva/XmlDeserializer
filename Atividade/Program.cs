﻿using System;
using System.Xml.Serialization;
using System.IO;
using XmlDeserializer.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using XmlDeserializer.Domain.Interfaces;
using XmlDeserializer.CrossCutting;

namespace Atividade
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

            repo.InsertFilms(films);
        }

        private static void BuildServiceProvider()
        {
            var services = new ServiceCollection();
            services.Inject();
            _serviceProvider = services.BuildServiceProvider();
        }
    }


}
