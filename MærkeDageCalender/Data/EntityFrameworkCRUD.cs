using DataAccessLibrary;
using DataAccessLibrary.ApiAccess;
using DataAccessLibrary.Models;
using static Dapper.SqlMapper;

namespace MærkeDageCalender.Data
{
    public class EntityFrameworkCRUD : ICRUDBirthday<BirthdayModel>, ICRUDUser<UserModel>
    {
        private readonly EntityFrameworkConnection _dbContext;

        public EntityFrameworkCRUD(EntityFrameworkConnection dbContext)
        {
            _dbContext = dbContext;
        }

        #region EventCRUD
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
        #endregion

        #region UserCRUD
        public void CreateUser(UserModel user)
        {
            _dbContext.UserDB.Add(user);
            _dbContext.SaveChanges();
        }

        public List<UserModel> ReadAllUsers()
        {
            var result = _dbContext.UserDB.ToList();
            return result;
        }

        public UserModel GetUser(int userId)
        {
            return _dbContext.UserDB.FirstOrDefault(e => e.Id == userId);
        }

        public void UpdateUser(UserModel user)
        {
            _dbContext.UserDB.Update(user);
            _dbContext.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var userToDelete = _dbContext.UserDB.Find(userId);
            if (userToDelete != null)
            {
                _dbContext.UserDB.Remove(userToDelete);
                _dbContext.SaveChanges();
            }
        }
        #endregion
    }
}
