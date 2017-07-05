using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Konzole.InventorySystem;
using Konzole.InventorySystem.Providers.Interface;
using Konzole.InventorySystem.Web.Models;

namespace Konzole.InventorySystem.Web.Controllers
{
    public class SetupController : Controller
    {
        private IUOMProvider _UomProvider = null;
        // GET: Setup

        public SetupController(IUOMProvider UomProvider)
        {
            this._UomProvider = UomProvider;
        }

        [ActionName("Index")]
        public ActionResult UOMIndex()
        {
            return View(this._UomProvider.GetList());
        }
    }
}