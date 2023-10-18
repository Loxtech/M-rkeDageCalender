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
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime date = reader.GetDateTime(1);
                        string eventName = reader.GetString(2);

                        birthday = new BirthdayModel { Id = id, Date = date, EventName = eventName };
                    }
                }
            }
            return birthday;
        }
        #endregion

        #region UserCRUD
        public void CreateUser(UserModel user)
        {
            throw new NotImplementedException();
        }

        public List<UserModel> ReadAllUsers()
        {
            throw new NotImplementedException();
        }

        public UserModel GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(UserModel user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
