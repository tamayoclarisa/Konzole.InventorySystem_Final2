using Konzole.InventorySystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzole.InventorySystem.Providers.Interface
{
    public interface IUOMProvider
    {
        UOM GetByUOMId(int uomId);
        List<UOM> GetList();
        bool Save(UOM _UOM);
  
    }
}
