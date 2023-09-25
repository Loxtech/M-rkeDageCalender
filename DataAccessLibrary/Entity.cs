using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessLibrary
{
    public class Entity : DbContext
    {
        public Entity(DbContextOptions<Entity> options) : base(options) { }
        public DbSet<BirthdayModel> BirthdayDB { get; set; }

    }

    public class EntityService
    {
        private readonly Entity _dbContext;

        public EntityService(Entity dbContext)
        {
            _dbContext = dbContext;

        }

        public void CreateBirthday(BirthdayModel birthdayModel)
        {
            try
            {
                _dbContext.BirthdayDB.Add(birthdayModel);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<BirthdayModel> GetAllBirthdays()
        {
            return _dbContext.BirthdayDB.ToList();
        }

        public void UpdateBirthday(BirthdayModel updatedBirthdayModel)
        {
            _dbContext.BirthdayDB.Update(updatedBirthdayModel);
            _dbContext.SaveChanges();
        }

        public void DeleteBirthday(int birthdayId)
        {
            var birthdayToDelete = _dbContext.BirthdayDB.Find(birthdayId);
            if (birthdayToDelete != null)
            {
                _dbContext.BirthdayDB.Remove(birthdayToDelete);
                _dbContext.SaveChanges();
            }
        }

    }
}
