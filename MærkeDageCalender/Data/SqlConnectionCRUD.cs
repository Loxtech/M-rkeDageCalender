using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.Data.SqlClient;

namespace MærkeDageCalender.Data
{
    public class SqlConnectionCRUD : ICRUDEvent<EventModel>, ICRUDUser<UserModel>
    {
        private IConfiguration _configuration;
        private string? ConnectionString => _configuration["ConnectionStrings:Default"];

        public SqlConnectionCRUD(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region EventCRUD
        // Create
        public void CreateEvent(EventModel entity)
        {
            string query = "INSERT INTO EventDB (Date, EventName) values(@Date, @EventName)";
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand(query, sqlConnection);

            cmd.Parameters.AddWithValue("@Date", entity.Date);
            cmd.Parameters.AddWithValue("@EventName", entity.EventName);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
        }

        // Read(All)
        public List<EventModel> ReadAllEvents()
        {
            List<EventModel> Events = new List<EventModel>();
            string query = "SELECT * FROM EventDB";

            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand(query, sqlConnection);

            sqlConnection.Open();
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                DateTime date = reader.GetDateTime(1);
                string eventName = reader.GetString(2);

                Events.Add(new EventModel { Id = id, Date = date, EventName = eventName });
            }

            return Events;
        }

        // Get(Single)
        public EventModel GetEvent(int id)
        {
            EventModel Event = new EventModel();
            string query = "SELECT Id, Date, EventName FROM EventDB WHERE Id = @Id";

            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                sqlConnection.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime date = reader.GetDateTime(1);
                    string eventName = reader.GetString(2);

                    Event = new EventModel { Id = id, Date = date, EventName = eventName };
                }
            }
            return Event;
        }

        // Update
        public void UpdateEvent(EventModel entity)
        {
            string query = "UPDATE EventDB SET Date = @Date, EventName = @EventName WHERE Id = @Id";
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand(query, sqlConnection);

            cmd.Parameters.AddWithValue("@Id", entity.Id);
            cmd.Parameters.AddWithValue("@Date", entity.Date);
            cmd.Parameters.AddWithValue("@EventName", entity.EventName);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
        }

        // Delete
        public void DeleteEvent(int id)
        {
            string query = "DELETE FROM EventDB WHERE Id = @Id";
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand(query, sqlConnection);

            cmd.Parameters.AddWithValue("@Id", id);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
        }
        #endregion

        #region UserCRUD
        public void CreateUser(UserModel user)
        {
            string query = "INSERT INTO UserDB (firstName, lastName, birthday) values(@firstName, @lastName, @birthday)";
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand(query, sqlConnection);

            cmd.Parameters.AddWithValue("@firstName", user.firstName);
            cmd.Parameters.AddWithValue("@lastName", user.lastName);
            cmd.Parameters.AddWithValue("@birthday", user.birthday);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
        }

        public List<UserModel> ReadAllUsers()
        {
            List<UserModel> users = new List<UserModel>();
            string query = "SELECT * FROM UserDB";

            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand(query, sqlConnection);

            sqlConnection.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string firstName = reader.GetString(1);
                string lastName = reader.GetString(2);
                DateTime birthday = reader.GetDateTime(3);

                users.Add(new UserModel { Id = id, firstName = firstName, lastName = lastName, birthday = birthday });
            }

            return users;
        }

        public UserModel GetUser(int id)
        {
            UserModel user = new UserModel();
            string query = "SELECT Id, firstName, lastName, birthday FROM UserDB WHERE Id = @Id";

            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                sqlConnection.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string firstName = reader.GetString(1);
                    string lastName = reader.GetString(2);
                    DateTime birthday = reader.GetDateTime(3);

                    user = new UserModel { Id = id, firstName = firstName, lastName = lastName, birthday = birthday };
                }
            }
            return user;
        }

        public void UpdateUser(UserModel user)
        {
            string query = "UPDATE UserDB SET firstName = @firstName, lastName = @lastName, birthday = @birthday WHERE Id = @Id";
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand(query, sqlConnection);

            cmd.Parameters.AddWithValue("@firstName", user.firstName);
            cmd.Parameters.AddWithValue("@lastName", user.lastName);
            cmd.Parameters.AddWithValue("@birthday", user.birthday);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
        }

        public void DeleteUser(int id)
        {
            string query = "DELETE FROM UserDB WHERE Id = @Id";
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand(query, sqlConnection);

            cmd.Parameters.AddWithValue("@Id", id);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
        }
        #endregion
    }
}
