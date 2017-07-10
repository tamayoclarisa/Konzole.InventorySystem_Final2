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
    public class UomProvider : BaseProvider, IUOMProvider
    {
        public UomProvider(ApplicationDbContext context, ILoggingProvider loggingProvider)
        {
            this._db = context;
            this._loggingProvider = loggingProvider;
        }
        public UOM GetByUOMId(int id)
        {
            UOM _UOM = new UOM();
            try
            {
                _UOM = _db.UOM.Find(id);
            }
            catch (Exception ex)
            {
                _loggingProvider.LogError(ex, string.Format("Failed to get a customer by ID: {0}", id));
            }

            if (_UOM == null)
            {
                _UOM = new UOM();
            }
            return _UOM;
        }

        public List<UOM> GetList()
        {
            List<UOM> UOMList = null;

            try
            {
                UOMList = (from UOM in _db.UOM
                                select UOM).ToList();
            }
            catch (Exception ex)
            {
                _loggingProvider.LogError(ex, "Failed to get a customer list");
            }

            if (UOMList == null)
            {
                UOMList = new List<UOM>();
            }

            return UOMList;
        }

        public bool Save(UOM _uom)
        {
            int returnvalue = 0;

            try
            {
                if (_uom.Id == 0)
                {
                    _db.UOM.Add(_uom);
                }
                else
                {
                    _db.Entry(_uom).State = EntityState.Modified;
                }
                returnvalue = _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _loggingProvider.LogError(ex, string.Format("Failed to save a customer - ID: {0}", _uom.Id));
            }
            return (returnvalue > 0);
        }

    }
}
