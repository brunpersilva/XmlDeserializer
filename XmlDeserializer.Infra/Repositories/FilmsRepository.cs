using Dapper;
using System.Data;
using System.Data.SqlClient;
using XmlDeserializer.Domain.Entities;
using XmlDeserializer.Domain.Interfaces;

namespace XmlDeserializer.Repositories
{
    /// <summary>
    /// Implementation of IFilmsRepository, this class insert the films information into the database.
    /// </summary>
    public class FilmsRepository : IFilmsRepository
    {
        private IAppConfiguration _appConfiguration;

        /// <summary>
        /// Gets the app configurations through dependency injection.
        /// </summary>
        /// <param name="appConfiguration"></param>
        public FilmsRepository(IAppConfiguration appConfiguration)
        {
            _appConfiguration = appConfiguration;
        }

        public void Insert(Films films)
        {
            //Gets the connection string from the private _appConfiguration
            string connectionString = _appConfiguration.FilmsConnectionString;

            //Connects to the database 
            using (IDbConnection connection = new SqlConnection(connectionString))
            {                
                foreach (Items item in films.FilmsList)
                {
                    //Uses a DynamicParameters instance to hold the films information
                    var p = new DynamicParameters();
                    p.Add("@Id", item.Id);
                    p.Add("@Title", item.Title);
                    p.Add("@Release_date", item.Release_date);
                    p.Add("@Studio", item.Studio);

                    //Using a stored procedure to pass the parameters and insert into the database
                    connection.Execute("spInsertFilms", p, commandType: CommandType.StoredProcedure);
                }
            }

        }
    }
}
