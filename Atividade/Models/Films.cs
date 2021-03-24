using System.Collections.Generic;
using System.Xml.Serialization;

namespace Atividade.Models
{
    public class Films
    {
        private List<Items> _filmsList = null;

        [XmlElement("items")]
        public List<Items> FilmsList
        {
            get { return _filmsList; }
            set { _filmsList = value; }
        }
    }
}