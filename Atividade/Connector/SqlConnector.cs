using Atividade.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Atividade.Connector
{
    public class SqlConnector
    {

        public void SaveFilms(Films films)
        {
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
