using DataAccessLibrary;
using DataAccessLibrary.Models;

namespace MærkeDageCalender.Data
{
    public class EntityFrameworkCRUD : ICRUDEvent<EventModel>, ICRUDUser<UserModel>
    {
        private readonly EntityFrameworkConnection _dbContext;

        public EntityFrameworkCRUD(EntityFrameworkConnection dbContext)
        {
            _dbContext = dbContext;
        }

        #region EventCRUD
        public void CreateEvent(EventModel entity)
        {
            _dbContext.BirthdayDB.Add(entity);
            _dbContext.SaveChanges();
        }

        public List<EventModel> ReadAllEvents()
        {
            var result = _dbContext.BirthdayDB.ToList();
            return result;
        }

        public EventModel GetEvent(int eventId)
        {
            return _dbContext.BirthdayDB.FirstOrDefault(e => e.Id == eventId);
        }

        public void UpdateEvent(EventModel entity)
        {
            _dbContext.BirthdayDB.Update(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteEvent(int Id)
        {
            var eventToDelete = _dbContext.BirthdayDB.Find(Id);
            if (eventToDelete != null)
            {
                _dbContext.BirthdayDB.Remove(eventToDelete);
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
