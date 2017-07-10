using Konzole.InventorySystem.Providers.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Konzole.InventorySystem.Web.Controllers
{
    
    public class AdminController : Controller
    {
        private IModuleProvider _moduleProvider = null;
        public AdminController(IModuleProvider moduleProvider)
        {
            this._moduleProvider = moduleProvider;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Module()
        {
            return View(this._moduleProvider.GetList());
        }

    }
}