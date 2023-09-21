using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessLibrary
{
    public class Entity : DbContext
    {

        public DbSet<BirthdayModel> BirthdayDB { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Default");
        }
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
            _dbContext.BirthdayDB.Add(birthdayModel);
            _dbContext.SaveChanges();
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
