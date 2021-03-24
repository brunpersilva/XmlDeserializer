using XmlDeserializer.Domain.Entities;

namespace XmlDeserializer.Domain.Interfaces
{
    public interface IXmlRepository
    {
        Films GetFilms(string company);
    }
}