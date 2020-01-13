using SampleApp.DataAccess.Data.Repository.IRepository;
using SampleApp.Models;
using System.Collections.Generic;

namespace SampleApp.DataAccess.Data.Repository
{
    public interface IServiceRepository : IRepository<Service>
    {
        void Update(Service service);
    }
}
