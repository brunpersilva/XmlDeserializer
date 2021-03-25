using System;
using System.Xml.Serialization;

namespace XmlDeserializer.Domain.Entities
{


    /// <summary>
    /// Represents the information about every film
    /// </summary>
    public class Items
    {
        [XmlElement("id")]
        public int Id { get; set; }
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("release_date")]
        public DateTime Release_date { get; set; }
        public string Studio { get; set; }
    }

}
