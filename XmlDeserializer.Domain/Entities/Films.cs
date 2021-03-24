using System.Collections.Generic;
using System.Xml.Serialization;

namespace XmlDeserializer.Domain.Entities
{
    public class Films
    {
        [XmlElement("items")]
        public List<Items> FilmsList { get; set; }
    }
}