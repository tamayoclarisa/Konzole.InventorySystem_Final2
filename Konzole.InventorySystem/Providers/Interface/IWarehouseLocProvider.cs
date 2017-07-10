using Konzole.InventorySystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzole.InventorySystem.Providers.Interface
{
    public interface IWarehouseLocProvider
    {

        WarehouseLoc GetByWarehouseLocId(int warehouseid);
        List<WarehouseLoc> GetList();
        bool Save(WarehouseLoc warehouseloc);
        bool RemoveById(int id);
    }
}
