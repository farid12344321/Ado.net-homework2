using Ado.net_homework2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Ado.net_homework2.Data
{
    internal class SpeakersDao
    {
        public int InsertSpeakers(Speakers speakers)
        {
            string connectionStr = ConnectionString.LOCAL;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "insert into Speakers (FullName,Position,Company,ImageUrl) values (@name,@pos,@com,@img)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@name",speakers.FullName);
                    cmd.Parameters.AddWithValue("@pos", speakers.Position);
                    cmd.Parameters.AddWithValue("@com", speakers.Company);
                    cmd.Parameters.AddWithValue("@img", speakers.Image);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public int UpdateSpeakers(Speakers speakers)
        {
            string connectionStr = ConnectionString.LOCAL;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "UPDATE Speakers SET FullName = @name,Position = @pos,Company = @com,ImageUrl = @img  WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", speakers.Id);
                    cmd.Parameters.AddWithValue("@name", speakers.FullName);
                    cmd.Parameters.AddWithValue("@pos", speakers.Position);
                    cmd.Parameters.AddWithValue("@com", speakers.Company);
                    cmd.Parameters.AddWithValue("@img", speakers.Image);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public Speakers GetSpeakersById(int id)
        {
            Speakers speakers = null;
            string connectionStr = ConnectionString.LOCAL;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "select TOP(1) * from Speakers where Id=@id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows) return null;
                    while (reader.Read())
                    {
                        speakers = new Speakers();
                        speakers.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        speakers.FullName = reader.GetString(reader.GetOrdinal("FullName"));
                        speakers.Position = reader.GetString(reader.GetOrdinal("Position"));
                        speakers.Company = reader.GetString(reader.GetOrdinal("Company"));
                        speakers.Image = reader.GetString(reader.GetOrdinal("ImageUrl"));
                    }
                }
            }
            return speakers;
        }
        public List<Speakers> GetAllSpeakers()
        {
            List<Speakers> speakers1 = new List<Speakers>();
            string connectionStr = ConnectionString.LOCAL;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "select Id, FullName, Position,Company,ImageUrl from Speakers";
                SqlCommand cmd = new SqlCommand(query, connection);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Speakers speakers = new Speakers()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            FullName = reader.GetString(reader.GetOrdinal("FullName")),
                            Position = reader.GetString(reader.GetOrdinal("Position")),
                            Company = reader.GetString(reader.GetOrdinal("Company")),
                            Image = reader.GetString(reader.GetOrdinal("ImageUrl"))
                        };
                        speakers1.Add(speakers);
                    }
                }
            }
            return speakers1;
        }
        public int DeleteSpeakersById(int id)
        {
            string connectionStr = ConnectionString.LOCAL;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "Delete From Speakers where Id=@id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
