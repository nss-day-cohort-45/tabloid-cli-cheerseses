using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI
{
    public class BGColorRepository : DatabaseConnector
    {
        public BGColorRepository(string connectionString) : base(connectionString) { }

        public BGColor Get()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * FROM ColorConfig c WHERE c.id = 1";

                    BGColor bgcolor = null;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (bgcolor == null)
                        {
                            bgcolor = new BGColor()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                ColorOption = reader.GetString(reader.GetOrdinal("ColorOption"))
                            };
                        }
                    }
                    reader.Close();
                    return bgcolor;
                }
            }
        }

        public void Update(BGColor bgcolor)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE ColorConfig
                                           SET ColorOption = @colorOption
                                         WHERE id = 1";
                    cmd.Parameters.AddWithValue("@colorOption", bgcolor.ColorOption);

                    cmd.ExecuteNonQuery();

                }
            }
        }
    }
}
