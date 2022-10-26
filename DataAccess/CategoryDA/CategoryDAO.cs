using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CategoryDA
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;
        private static readonly object instanceLock = new object();
        public static CategoryDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new CategoryDAO();
                    return instance;
                }
            }
        }

        public IEnumerable<Category> getCategories()
        {
            List<Category> categories;
            try
            {
                var context = new ffmlwpyhContext();
                categories = context.Categories.ToList();
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return categories;
        }

        public Category getCategory(int id)
        {
            Category category = null;
            try
            {
                var context = new ffmlwpyhContext();
                category = context.Categories.SingleOrDefault(c => c.Id == id);
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return category;
        }
    }
}
