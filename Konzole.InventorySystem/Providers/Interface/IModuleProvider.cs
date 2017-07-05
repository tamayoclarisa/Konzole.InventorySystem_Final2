using Konzole.InventorySystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzole.InventorySystem.Providers.Interface
{
    public interface IModuleProvider
    {
        Module GetByModuleId(int moduleId);
        List<Module> GetList();
        bool Save(Module module);
        bool RemoveById(int id);
    }
}
