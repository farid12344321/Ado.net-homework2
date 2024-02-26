using Ado.net_homework2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Ado.net_homework2.Data
{
    internal class EventDao
    {

        //public void CreateEventWithSpeakers(Events events, Speakers[] speakers)
        //{
        //    string connectionString = ConnectionString.LOCAL;
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        string query = "insert into Events (Name,Description,Address,StartDate,StartTime,EndTime) values (@name,@desc,@address,@startdate,@starttime,@endtime)";


        //        SqlCommand cmd = new SqlCommand(query, connection);
        //        cmd.Parameters.AddWithValue("@name", events.Name);
        //        cmd.Parameters.AddWithValue("@desc", events.Description);
        //        cmd.Parameters.AddWithValue("@address", events.Address);
        //        cmd.Parameters.AddWithValue("@startdate", events.StartDate);
        //        cmd.Parameters.AddWithValue("@starttime", events.StartTime);
        //        cmd.Parameters.AddWithValue("@endtime", events.EndTime);
        //        cmd.ExecuteNonQuery();



        //        foreach (var item in speakers)
        //        {
        //            SqlCommand insertEventSpeakerCmd = new SqlCommand("INSERT INTO EventSpeakers (EventsId, SpeakrsId) VALUES (@EventID, @SpeakerID)", connection);
        //            insertEventSpeakerCmd.Parameters.AddWithValue("@EventID", events.Id);
        //            insertEventSpeakerCmd.Parameters.AddWithValue("@SpeakerID", item.Id);
        //            insertEventSpeakerCmd.ExecuteNonQuery();
        //        }
        //    }
        //}
        public int InsertEvent(Events events)
        {
            string connectionStr = ConnectionString.LOCAL;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "insert into Events (Name,Description,Address,StartDate,StartTime,EndTime) values (@name,@desc,@address,@startdate,@starttime,@endtime)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@name", events.Name);
                    cmd.Parameters.AddWithValue("@desc", events.Description);
                    cmd.Parameters.AddWithValue("@address", events.Address);
                    cmd.Parameters.AddWithValue("@startdate", events.StartDate);
                    cmd.Parameters.AddWithValue("@starttime", events.StartTime);
                    cmd.Parameters.AddWithValue("@endtime", events.EndTime);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public Events GetEventsById(int id)
        {
            Events events = null;
            string connectionStr = ConnectionString.LOCAL;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "select TOP(1) * from Events where Id=@id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows) return null;
                    while (reader.Read())
                    {
                        events = new Events();
                        events.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        events.Name = reader.GetString(reader.GetOrdinal("Name"));
                        events.Description = reader.GetString(reader.GetOrdinal("Description"));
                        events.Address = reader.GetString(reader.GetOrdinal("Address"));
                        events.StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate"));
                        events.StartTime = reader.GetDateTime(reader.GetOrdinal("StartTime"));
                        events.EndTime = reader.GetDateTime(reader.GetOrdinal("EndTime"));
                    }
                }
            }
            return events;
        }

        public List<Events> GetAllEvents()
        {
            List<Events> events = new List<Events>();
            string connectionStr = ConnectionString.LOCAL;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "select Id,Name,Description,Address,StartDate,StartTime,EndTime from Events";
                SqlCommand cmd = new SqlCommand(query, connection);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Events events1 = new Events()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Description = reader.GetString(reader.GetOrdinal("Description")),
                            Address = reader.GetString(reader.GetOrdinal("Address")),
                            StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                            StartTime = reader.GetDateTime(reader.GetTimeSpan(4).ToString("HH:mm:ss")),
                            EndTime = reader.GetDateTime(reader.GetTimeSpan(5).ToString("HH:mm:ss")),
                          


                        //     TimeSpan eventTime = reader.GetTimeSpan(0); // Assuming the column index is 0
                        //timeString = eventTime.ToString(@"hh\:mm\:ss"); // Format the TimeSpan as HH:MM:SS
                    };
                        events.Add(events1);
                    }
                }
            }
            return events;
        }
        public int UpdateEvent(Events events)
        {
            string connectionStr = ConnectionString.LOCAL;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "UPDATE Events SET Name = @name,Description = @desc,Address = @address,StartDate = @startdate,StartTime = @starttime,EndTime = @endtime, WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", events.Id);
                    cmd.Parameters.AddWithValue("@name", events.Name);
                    cmd.Parameters.AddWithValue("@desc", events.Description);
                    cmd.Parameters.AddWithValue("@address", events.Address);
                    cmd.Parameters.AddWithValue("@startdate", events.StartDate);
                    cmd.Parameters.AddWithValue("@starttime", events.StartTime);
                    cmd.Parameters.AddWithValue("@endtime", events.EndTime);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        

    }
}
