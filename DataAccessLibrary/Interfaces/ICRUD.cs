using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface ICRUD<T>
    {
        void CreateBirthday(T entity);
        List<T> ReadAllBirthdays();
        T GetBirthday(int id);
        void UpdateBirthday(T entity);
        void DeleteBirthday(int id);


        //void CreateUser(T entity);
        //void DeleteUser(int id);
    }
}