﻿using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLibrary
{
    public class EntityFrameworkConnection : DbContext
    {
        public EntityFrameworkConnection(DbContextOptions<EntityFrameworkConnection> options) : base(options) { }
        public DbSet<EventModel> BirthdayDB { get; set; }
        public DbSet<UserModel> UserDB { get; set; }
    }
}
