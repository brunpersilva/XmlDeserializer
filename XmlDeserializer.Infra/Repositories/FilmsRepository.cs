﻿using Dapper;
using System.Data;
using System.Data.SqlClient;
using XmlDeserializer.Domain.Entities;
using XmlDeserializer.Domain.Interfaces;

namespace XmlDeserializer.Repositories
{
    public class FilmsRepository : IFilmsRepository
    {
        public void Insert(Films films, string connectionString)
        {

            using (IDbConnection connection = new SqlConnection(connectionString))
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
