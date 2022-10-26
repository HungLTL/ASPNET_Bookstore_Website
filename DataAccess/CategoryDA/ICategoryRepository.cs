using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CategoryDA
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> getCategories();
        Category getCategory(int id);
    }
}
