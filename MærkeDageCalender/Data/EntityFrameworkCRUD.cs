using DataAccessLibrary;
using DataAccessLibrary.ApiAccess;
using DataAccessLibrary.Models;

namespace MærkeDageCalender.Data
{
    public class EntityFrameworkCRUD : ICRUD<BirthdayModel>
    {
        private readonly EntityFrameworkConnection _dbContext;

        public EntityFrameworkCRUD(EntityFrameworkConnection dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateBirthday(BirthdayModel entity)
        {
            _dbContext.BirthdayDB.Add(entity);
            _dbContext.SaveChanges();
        }

        public List<BirthdayModel> ReadAllBirthdays()
        {
            var result = _dbContext.BirthdayDB.ToList();
            return result;
        }

        public BirthdayModel GetBirthday(int birthdayId)
        {
            return _dbContext.BirthdayDB.FirstOrDefault(e => e.Id == birthdayId);
        }

        public void UpdateBirthday(BirthdayModel entity)
        {
            _dbContext.BirthdayDB.Update(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteBirthday(int Id)
        {
            var birthdayToDelete = _dbContext.BirthdayDB.Find(Id);
            if (birthdayToDelete != null)
            {
                _dbContext.BirthdayDB.Remove(birthdayToDelete);
                _dbContext.SaveChanges();
            }
        }
    }
}
