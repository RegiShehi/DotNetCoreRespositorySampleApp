using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        IServiceRepository Service { get; }

        void Save();
    }
}
