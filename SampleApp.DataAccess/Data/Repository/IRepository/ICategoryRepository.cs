using Microsoft.AspNetCore.Mvc.Rendering;
using SampleApp.DataAccess.Data.Repository.IRepository;
using SampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SampleApp.DataAccess.Data.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<SelectListItem> GetCategoryListForDropDown();
        void Update(Category category);
    }
}
