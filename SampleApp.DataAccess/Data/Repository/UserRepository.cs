﻿using Microsoft.AspNetCore.Mvc.Rendering;
using SampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleApp.DataAccess.Data.Repository
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void LockUser(string userId)
        {
            var userFromDb = _db.ApplicationUser.FirstOrDefault(u => u.Id == userId);

            userFromDb.LockoutEnd = DateTime.Now.AddYears(1000);

            _db.SaveChanges();
        }

        public void UnlockUser(string userId)
        {
            var userFromDb = _db.ApplicationUser.FirstOrDefault(u => u.Id == userId);

            userFromDb.LockoutEnd = DateTime.Now;

            _db.SaveChanges();
        }
    }
}
