﻿using SampleApp.DataAccess.Data.Repository.IRepository;

namespace SampleApp.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Service = new ServiceRepository(_db);
            User = new UserRepository(_db);
        }

        public ICategoryRepository Category { get; private set; }

        public IServiceRepository Service { get; private set; }

        public IUserRepository User { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
