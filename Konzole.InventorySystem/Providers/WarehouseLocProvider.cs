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
    public class WarehouseLocProvider : BaseProvider, IWarehouseLocProvider
    {
        public WarehouseLocProvider(ApplicationDbContext context, ILoggingProvider loggingProvider)
        {
            this._db = context;
            this._loggingProvider = loggingProvider;
        }

        public WarehouseLoc GetByWarehouseLocId(int id)
        {
            WarehouseLoc warehouseLoc = new WarehouseLoc();
            try
            {
                warehouseLoc = _db.WarehouseLoc.Find(id);
            }
            catch (Exception ex)
            {
                _loggingProvider.LogError(ex, string.Format("Failed to get a Warehouse by ID: {0}", id));
            }

            if (warehouseLoc == null)
            {
                warehouseLoc = new WarehouseLoc();
            }
            return warehouseLoc;
        }

        public List<WarehouseLoc> GetList()
        {
            List<WarehouseLoc> warehouseLocList = null;

            try
            {
                warehouseLocList = (from warehouseLoc in _db.WarehouseLoc
                                select warehouseLoc).ToList();
            }
            catch (Exception ex)
            {
                _loggingProvider.LogError(ex, "Failed to get a warehouse list");
            }

            if (warehouseLocList == null)
            {
                warehouseLocList = new List<WarehouseLoc>();
            }

            return warehouseLocList;
        }

        public bool RemoveById(int id)
        {
            int returnvalue = 0;

            WarehouseLoc warehouseLoc = _db.WarehouseLoc.Find(id);
            try
            {
                _db.WarehouseLoc.Remove(warehouseLoc);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _loggingProvider.LogError(ex, string.Format("Failed to remove a warehouseLoc - ID: {0}", warehouseLoc.WarehouseLocId));
            }
            return (returnvalue > 0);
        }

        public bool Save(WarehouseLoc warehouseLoc)
        {
            int returnvalue = 0;

            try
            {
                if (warehouseLoc.WarehouseLocId == 0)
                {
                    _db.WarehouseLoc.Add(warehouseLoc);
                }
                else
                {
                    _db.Entry(warehouseLoc).State = EntityState.Modified;
                }
                returnvalue = _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _loggingProvider.LogError(ex, string.Format("Failed to save a customer - ID: {0}", warehouseLoc.WarehouseLocId));
            }
            return (returnvalue > 0);
        }
    }
}
