using System;
using System.Xml.Serialization;
using System.Linq;
using System.IO;
using Atividade.Models;
using Atividade.Connector;

namespace Atividade
{
    class Program
    {
        static void Main(string[] args)
        {            
            Films films;

            Console.WriteLine();

            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            string path = Path.Combine(@"C:\Users\Pichau\source\repos\AtividadeSolution\Atividade\Arquivos\marvel.xml");
            var serializer = new XmlSerializer(typeof(Films), new XmlRootAttribute("Films"));

            using (var stream = new FileStream(path, FileMode.Open))
            {
                films = (Films)serializer.Deserialize(stream);
            }

            films.FilmsList.Count();

            var sql = new SqlConnector();

            sql.SaveFilms(films);

            Console.WriteLine();


        }

    }


}
