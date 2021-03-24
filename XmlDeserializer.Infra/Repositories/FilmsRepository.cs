using Dapper;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using XmlDeserializer.Domain.Entities;
using XmlDeserializer.Domain.Interfaces;

namespace XmlDeserializer.Repositories
{
    public class FilmsRepository : IFilmsRepository
    {
        public void InsertFilms(Films films)
        {
            //string connectionString = _configuration.GetConnectionString("FilmsDatabase");

            using (IDbConnection connection = new SqlConnection("Data Source=DESKTOP-LFU4RFH;Initial Catalog=Films;Integrated Security=True"))
            {
                foreach (Items item in films.FilmsList)
                {
                    var p = new DynamicParameters();
                    p.Add("@Id", item.Id);
                    p.Add("@Title", item.Title);
                    p.Add("@Release_date", item.Release_date);
                    p.Add("@Studio", item.Studio);

                    connection.Execute("spInsertFilms", p, commandType: CommandType.StoredProcedure);
                }
            }

        }
    }
}
