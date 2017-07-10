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
using Konzole.InventorySystem.Entities;

namespace Konzole.InventorySystem.Web.Controllers
{
    public class SetupController : Controller
    {
        private IUOMProvider _UomProvider = null;
        private IWarehouseLocProvider _WarehouseLocProvider = null;
        private ICategoryProvider _CategoryProvider = null;
        // GET: Setup

        public SetupController(IUOMProvider UomProvider, ICategoryProvider CategoryProvider, IWarehouseLocProvider WarehouseLocProvider)
        {
            this._UomProvider = UomProvider;
            this._CategoryProvider = CategoryProvider;
            this._WarehouseLocProvider = WarehouseLocProvider;

        }

        //uom
        [ActionName("Index")]
        public ActionResult UOMIndex()
        {
            return View(this._UomProvider.GetList());
        }

        #region Category
        [ActionName("CategoryList")]
        public ActionResult CategoryListing()
        {
            return View(this._CategoryProvider.GetList());
        }

        [ActionName("CreateCategory")]
        public ActionResult CreateCategory()
        {
            return View();
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategory([Bind(Include = "CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {

                this._CategoryProvider.Save(category);
                return RedirectToAction("CategoryList");
            }

            return View(category);
        }

        #endregion


        #region Warehouse location
        [ActionName("WarehouseLocList")]
        public ActionResult WarehouseListing()
        {
            return View(this._WarehouseLocProvider.GetList());
        }
        #endregion


    }
}