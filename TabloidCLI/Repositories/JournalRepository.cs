using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI
{
    class JournalRepository : DatabaseConnector, IRepository<Journal>
    {
        public JournalRepository(string connectionString) : base(connectionString) { }

        /// <summary>
        ///  Return all journal entries from the database in a list.
        /// </summary>
        public List<Journal> GetAll()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, Title, Content, CreateDateTime FROM Journal";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Journal> journals = new List<Journal>();

                    while (reader.Read())
                    {
                        Journal journal = new Journal
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Content = reader.GetString(reader.GetOrdinal("Content")),
                            CreateDateTime = reader.GetDateTime(reader.GetOrdinal("CreateDateTime")),
                        };

                        journals.Add(journal);
                    }

                    reader.Close();
                    return journals;
                }
            }
        }

        /// <summary>
        ///  Add a new journal entry to the database
        ///   NOTE: This method sends data to the database,
        ///   it does not get anything from the database, so there is nothing to return.
        /// </summary>
        public void Insert(Journal journal)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Journal (Title, Content, CreateDateTime)
                                        OUTPUT INSERTED.Id
                                        VALUES (@title, @content, @createDateTime)";

                    cmd.Parameters.AddWithValue("@title", journal.Title);
                    cmd.Parameters.AddWithValue("@content", journal.Content);
                    cmd.Parameters.AddWithValue("@createDateTime", journal.CreateDateTime);

                    int id = (int)cmd.ExecuteScalar();

                    journal.Id = id;
                }
            }
        }

        public Journal Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Journal journal)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}