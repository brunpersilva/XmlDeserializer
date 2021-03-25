using System;
using System.IO;
using System.Xml.Serialization;
using XmlDeserializer.Domain.Entities;
using XmlDeserializer.Domain.Interfaces;

namespace XmlDeserializer.Infra.Repositories
{
    public class XmlRepository : IXmlRepository
    {
        /// <summary>
        /// Get Films from a Xml File.
        /// </summary>
        /// <param name="studio"></param>
        /// <returns></returns>
        public Films GetFilms(string studio)
        {
            
            Films films;

            //Gets the file path based on the name of the company
            string path = Path.Combine(Environment.CurrentDirectory, $@"Arquivos\{studio}.xml");

            //Instanciate a new XmlSerializer of type films and adds a rootAtribute named "films"
            var serializer = new XmlSerializer(typeof(Films), new XmlRootAttribute("films"));

            //Use a filestrem instance to opem the Xml file
            using (var stream = new FileStream(path, FileMode.Open))
            {
                //Deserializer the content of the Xml file in the films variable
                films = (Films)serializer.Deserialize(stream);
            }

            //Adds the Studio name to every instance that was deserialized from the xml file
            films.FilmsList?.ForEach(f => f.Studio = studio);

            return films;
        }
    }
}
