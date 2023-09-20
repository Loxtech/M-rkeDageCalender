using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface IBirthdayData
    {
        Task<List<BirthdayModel>> GetBirthdays();
        Task InsertBirthday(BirthdayModel birthday);
    }
}