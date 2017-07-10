using Konzole.InventorySystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzole.InventorySystem.Providers.Interface
{
    public interface ICategoryProvider
    {
        Category GetByCategoryId(int categoryid);
        List<Category> GetList();
        bool Save(Category category);
        bool RemoveById(int id);
    }
}
