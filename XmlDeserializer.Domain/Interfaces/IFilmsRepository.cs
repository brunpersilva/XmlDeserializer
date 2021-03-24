using XmlDeserializer.Domain.Entities;

namespace XmlDeserializer.Domain.Interfaces
{
    public interface IFilmsRepository
    {
        void InsertFilms(Films films);
    }
}