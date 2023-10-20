using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface ICRUDEvent<T>
    {
        void CreateEvent(T entity);
        List<T> ReadAllEvents();
        T GetEvent(int id);
        void UpdateEvent(T entity);
        void DeleteEvent(int id);
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