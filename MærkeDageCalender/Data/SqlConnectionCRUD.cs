using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.Data.SqlClient;

namespace MærkeDageCalender.Data
{
    public class SqlConnectionCRUD : ICRUD<BirthdayModel>
    {
        private IConfiguration _configuration;
        private string? ConnectionString => _configuration["ConnectionStrings:Default"];

        SqlConnectionCRUD(IConfiguration configuration)
        {
            _configuration = configuration;
        }

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

        public List<BirthdayModel> ReadAllBirthdays()
        {
            throw new NotImplementedException();
        }

        public void UpdateBirthday(BirthdayModel entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteBirthday(int id)
        {
            throw new NotImplementedException();
        }
    }
}
