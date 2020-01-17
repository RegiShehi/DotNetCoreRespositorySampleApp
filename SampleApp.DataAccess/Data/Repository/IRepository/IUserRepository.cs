using Microsoft.AspNetCore.Mvc.Rendering;
using SampleApp.DataAccess.Data.Repository.IRepository;
using SampleApp.Models;
using System.Collections.Generic;

namespace SampleApp.DataAccess.Data.Repository
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        void LockUser(string userId);

        void UnlockUser(string userId);
    }
}
