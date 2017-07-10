using Konzole.InventorySystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzole.InventorySystem.Providers.Interface
{
    public interface IUserProvider
    {
        User GetByUserId(int userid);
        List<User> GetList();
        bool Save(User customer);
        bool RemoveById(int id);
    }
}
