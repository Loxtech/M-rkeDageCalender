using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface ICRUDBirthday<T>
    {
        void CreateBirthday(T entity);
        List<T> ReadAllBirthdays();
        T GetBirthday(int id);
        void UpdateBirthday(T entity);
        void DeleteBirthday(int id);
    }

    public interface ICRUDUser<T>
    {
        void CreateUser(T user);
        List<T> ReadAllUsers();
        T GetUser(int id);
        void UpdateUser(T user);
        void DeleteUser(int id);
    }
}