using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.Data.SqlClient;

namespace MærkeDageCalender.Data
{
    public class SqlConnectionCRUD : ICRUDBirthday<BirthdayModel>, ICRUDUser<UserModel>
    {
        private IConfiguration _configuration;
        private string? ConnectionString => _configuration["ConnectionStrings:Default"];

        public SqlConnectionCRUD(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region EventCRUD
        // Create
        public void CreateBirthday(BirthdayModel entity)
        {
            string query = "INSERT INTO BirthdayDB (Date, EventName) values(@Date, @EventName)";
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand(query, sqlConnection);

            cmd.Parameters.AddWithValue("@Date", entity.Date);
            cmd.Parameters.AddWithValue("@EventName", entity.EventName);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
        }

        // Read(All)
        public List<BirthdayModel> ReadAllBirthdays()
        {
            List<BirthdayModel> birthdays = new List<BirthdayModel>();
            string query = "SELECT * FROM BirthdayDB";

            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand(query, sqlConnection);

            sqlConnection.Open();
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                DateTime date = reader.GetDateTime(1);
                string eventName = reader.GetString(2);

                birthdays.Add(new BirthdayModel { Id = id, Date = date, EventName = eventName });
            }

            return birthdays;
        }

        // Get(Single)
        public BirthdayModel GetBirthday(int id)
        {
            BirthdayModel birthday = new BirthdayModel();
            string query = "SELECT Id, Date, EventName FROM BirthdayDB WHERE Id = @Id";

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

                    birthday = new BirthdayModel { Id = id, Date = date, EventName = eventName };
                }
            }
            return birthday;
        }

        // Update
        public void UpdateBirthday(BirthdayModel entity)
        {
            string query = "UPDATE BirthdayDB SET Date = @Date, EventName = @EventName WHERE Id = @Id";
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand(query, sqlConnection);

            cmd.Parameters.AddWithValue("@Id", entity.Id);
            cmd.Parameters.AddWithValue("@Date", entity.Date);
            cmd.Parameters.AddWithValue("@EventName", entity.EventName);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
        }

        // Delete
        public void DeleteBirthday(int id)
        {
            string query = "DELETE FROM BirthdayDB WHERE Id = @Id";
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
