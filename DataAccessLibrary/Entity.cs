using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessLibrary
{
    public class Entity : DbContext
    {

        public DbSet<BirthdayModel> Birthdays { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Default");
        }
    }

    public class EntityService
    {
        private readonly Entity _dbContext;

        public EntityService()
        {
            _dbContext = new Entity();
            _dbContext.Database.EnsureCreated();
        }

        public void CreateBirthday(BirthdayModel birthdayModel)
        {
            _dbContext.Birthdays.Add(birthdayModel);
            _dbContext.SaveChanges();
        }

        public List<BirthdayModel> GetAllBirthdays()
        {
            return _dbContext.Birthdays.ToList();
        }

        public void UpdateBirthday(BirthdayModel updatedBirthdayModel)
        {
            _dbContext.Birthdays.Update(updatedBirthdayModel);
            _dbContext.SaveChanges();
        }

        public void DeleteBirthday(int birthdayId)
        {
            var birthdayToDelete = _dbContext.Birthdays.Find(birthdayId);
            if (birthdayToDelete != null)
            {
                _dbContext.Birthdays.Remove(birthdayToDelete);
                _dbContext.SaveChanges();
            }
        }

    }
}
