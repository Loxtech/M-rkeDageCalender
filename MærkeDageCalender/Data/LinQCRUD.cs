using DataAccessLibrary;
using DataAccessLibrary.Models;

namespace MærkeDageCalender.Data
{
    public class LinQCRUD : ICRUDBirthday<BirthdayModel>, ICRUDUser<UserModel>
    {
        #region EventCRUD
        public void CreateBirthday(BirthdayModel entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteBirthday(int id)
        {
            throw new NotImplementedException();
        }

        public BirthdayModel GetBirthday(int id)
        {
            throw new NotImplementedException();
        }

        public List<BirthdayModel> ReadAllBirthdays()
        {
            throw new NotImplementedException();
        }

        public void UpdateBirthday(BirthdayModel entity)
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
