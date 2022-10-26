using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CategoryDA
{
    public class CategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> getCategories() => CategoryDAO.Instance.getCategories();

        public Category getCategory(int id) => CategoryDAO.Instance.getCategory(id);
    }
}
