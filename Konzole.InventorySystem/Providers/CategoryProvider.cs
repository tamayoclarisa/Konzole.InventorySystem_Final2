using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konzole.InventorySystem.Providers.Interface;
using Konzole.InventorySystem.Web.Models;
using Konzole.InventorySystem.Entities;

namespace Konzole.InventorySystem.Providers
{
    public class CategoryProvider : BaseProvider,ICategoryProvider
    {
        public CategoryProvider(ApplicationDbContext context, ILoggingProvider loggingProvider)
        {
            this._db = context;
            this._loggingProvider = loggingProvider;
        }

        public Category GetByCategoryId(int id)
        {
            Category category = new Category();
            try
            {
                category = _db.Category.Find(id);
            }
            catch (Exception ex)
            {
                _loggingProvider.LogError(ex, string.Format("Failed to get a category by ID: {0}", id));
            }

            if (category == null)
            {
                category = new Category();
            }
            return category;
        }

        public List<Category> GetList()
        {
            List<Category> categoryList = null;

            try
            {
                categoryList = (from Category in _db.Category
                                    select Category).ToList();
            }
            catch (Exception ex)
            {
                _loggingProvider.LogError(ex, "Failed to get a warehouse list");
            }

            if (categoryList == null)
            {
                categoryList = new List<Category>();
            }

            return categoryList;
        }

        public bool RemoveById(int id)
        {
            int returnvalue = 0;

            Category category = _db.Category.Find(id);
            try
            {
                _db.Category.Remove(category);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _loggingProvider.LogError(ex, string.Format("Failed to remove a warehouseLoc - ID: {0}", category.CategoryId));
            }
            return (returnvalue > 0);
        }

        public bool Save(Category category)
        {
            int returnvalue = 0;

            try
            {
                if (category.CategoryId == 0)
                {
                    _db.Category.Add(category);
                }
                else
                {
                    _db.Entry(category).State = EntityState.Modified;
                }
                returnvalue = _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _loggingProvider.LogError(ex, string.Format("Failed to save a customer - ID: {0}", category.CategoryId));
            }
            return (returnvalue > 0);
        }
    }
}
