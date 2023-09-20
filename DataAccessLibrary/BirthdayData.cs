using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class BirthdayData : IBirthdayData
    {
        private readonly ISqlDataAccess _db;

        public BirthdayData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<BirthdayModel>> GetBirthdays()
        {
            string sql = "select * from dbo.BirthdayDB";

            return _db.LoadData<BirthdayModel, dynamic>(sql, new { });
        }

        public Task InsertBirthday(BirthdayModel birthday)
        {
            string sql = @"insert into dbo.BirthdayDB (Date, EventName)
                        values  (@Date, EventName);";

            return _db.SaveData(sql, birthday);
        }
    }
}
