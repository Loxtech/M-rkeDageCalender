using DataAccessLibrary;
using DataAccessLibrary.Models;

namespace MærkeDageCalender.Data
{
    public class LinQCRUD : ICRUDEvent<EventModel>, ICRUDUser<UserModel>
    {
        private readonly EntityFrameworkConnection _dbContext;

        public LinQCRUD(EntityFrameworkConnection dbContext)
        {
            _dbContext = dbContext;
        }


        #region EventCRUD
        public void CreateEvent(EventModel entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEvent(int id)
        {
            throw new NotImplementedException();
        }

        public EventModel GetEvent(int id)
        {
            throw new NotImplementedException();
        }

        public List<EventModel> ReadAllEvents()
        {
            throw new NotImplementedException();
        }

        public void UpdateEvent(EventModel entity)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region UserCRUD
        public void CreateUser(UserModel user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserModel> ReadAllUsers()
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(UserModel user)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
