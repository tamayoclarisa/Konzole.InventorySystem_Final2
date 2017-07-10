using Konzole.InventorySystem.Entities;
using Konzole.InventorySystem.Providers.Interface;
using Konzole.InventorySystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzole.InventorySystem.Providers
{
    public class ModuleProvider:BaseProvider,IModuleProvider
    {
        public ModuleProvider(ApplicationDbContext context, ILoggingProvider loggingProvider)
        {
            this._db = context;
            this._loggingProvider = loggingProvider;
        }

        public Module GetByModuleId(int id)
        {
            Module module = new Module();
            try
            {
                module = _db.Modules.Find(id);
            }
            catch (Exception ex)
            {
                _loggingProvider.LogError(ex, string.Format("Failed to get a module by ID: {0}", id));
            }

            if (module == null)
            {
                module = new Module();
            }
            return module;
        }

        public List<Module> GetList()
        {
            List<Module> moduleList = null;

            try
            {
                moduleList = (from module in _db.Modules
                                select module).ToList();
            }
            catch (Exception ex)
            {
                _loggingProvider.LogError(ex, "Failed to get a module list");
            }

            if (moduleList == null)
            {
                moduleList = new List<Module>();
            }

            return moduleList;
        }

        public bool RemoveById(int id)
        {
            int returnvalue = 0;

            Module module= _db.Modules.Find(id);
            try
            {
                _db.Modules.Remove(module);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _loggingProvider.LogError(ex, string.Format("Failed to remove a moudle - ID: {0}", module.Id));
            }
            return (returnvalue > 0);
        }

        public bool Save(Module module)
        {
            int returnvalue = 0;

            try
            {
                if (module.Id == 0)
                {
                    _db.Modules.Add(module);
                }
                else
                {
                    _db.Entry(module).State = EntityState.Modified;
                }
                returnvalue = _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _loggingProvider.LogError(ex, string.Format("Failed to save a module - ID: {0}", module.Id));
            }
            return (returnvalue > 0);
        }
}
}
