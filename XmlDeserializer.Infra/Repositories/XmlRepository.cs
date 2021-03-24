using System;
using System.IO;
using System.Xml.Serialization;
using XmlDeserializer.Domain.Entities;
using XmlDeserializer.Domain.Interfaces;

namespace XmlDeserializer.Infra.Repositories
{
    public class XmlRepository : IXmlRepository
    {
        public Films GetFilms(string company)
        {
            Films films;

            string path = Path.Combine(Environment.CurrentDirectory, $@"Arquivos\{company}.xml");

            var serializer = new XmlSerializer(typeof(Films), new XmlRootAttribute("films"));

            using (var stream = new FileStream(path, FileMode.Open))
            {
                films = (Films)serializer.Deserialize(stream);
            }

            films.FilmsList?.ForEach(f => f.Studio = company);

            return films;
        }
    }
}
