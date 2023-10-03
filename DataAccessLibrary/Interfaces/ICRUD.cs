using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface ICRUD<T>
    {
        void CreateBirthday(T entity);
        List<T> ReadAllBirthdays();
        void GetBirthday(int id);
        void UpdateBirthday(T entity);
        void DeleteBirthday(int id);
    }
}