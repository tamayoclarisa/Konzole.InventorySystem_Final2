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


        #region UOM
        //uom
        


        [ActionName("UOMList")]
        public ActionResult UOMList()
        {
            return View(this._UomProvider.GetList());
        }

        [ActionName("UOMDetails")]
        public ActionResult UOMDetails(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UOM _uom = this._UomProvider.GetByUOMId(id);
            if (_uom == null)
            {
                return HttpNotFound();
            }
            return View(_uom);
        }


        [ActionName("CreateUOM")]
        public ActionResult CreateUOM()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUOM([Bind(Include = "Description,Abbreviation")] UOM uom)
        {
            if (ModelState.IsValid)
            {
               
                this._UomProvider.Save(uom);
                return RedirectToAction("UOMList");
            }

            return View(uom);
        }

        [ActionName("UOMEdit")]
        public ActionResult UOMEdit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UOM _uom = _UomProvider.GetByUOMId(id);
            if (_uom == null)
            {
                return HttpNotFound();
            }
            return View(_uom);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UOMEdit([Bind(Include = "Description,Abbreviation")] UOM _UOM)
        {
            if (ModelState.IsValid)
            {
                _UomProvider.Save(_UOM);
                return RedirectToAction("UOMList");
            }
            return View(_UOM);
        }
        #endregion

        #region Category
        [ActionName("CategoryList")]
        public ActionResult CategoryListing()
        {
            return View(this._CategoryProvider.GetList());
        }

        [ActionName("CategoryDetails")]
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category _category = this._CategoryProvider.GetByCategoryId(id);
            if (_category == null)
            {
                return HttpNotFound();
            }
            return View(_category);
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
                category.Recdate = DateTime.Now;
                category.RecUser = "clarisa";
                this._CategoryProvider.Save(category);
                return RedirectToAction("CategoryList");
            }

            return View(category);
        }

        [ActionName("CategoryEdit")]
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category _category = _CategoryProvider.GetByCategoryId(id);
            if (_category == null)
            {
                return HttpNotFound();
            }
            return View(_category);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CategoryEdit([Bind(Include = "CategoryName")] Category _category)
        {
            if (ModelState.IsValid)
            {
                _CategoryProvider.Save(_category);
                return RedirectToAction("CategoryList");
            }
            return View(_category);
        }


        #endregion

        #region Warehouse location
        [ActionName("WarehouseLocList")]
        public ActionResult WarehouseListing()
        {
            return View(this._WarehouseLocProvider.GetList());
        }


        [ActionName("WarehouseDetails")]
        public ActionResult WarehouseDetails(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseLoc _Warehouse = this._WarehouseLocProvider.GetByWarehouseLocId(id);
            if (_Warehouse == null)
            {
                return HttpNotFound();
            }
            return View(_Warehouse);
        }


        [ActionName("CreateWarehouse")]
        public ActionResult CreateWarehouse()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWarehouse([Bind(Include = "LocationAddress")] WarehouseLoc _WarehouseLoc)
        {
            if (ModelState.IsValid)
            {
                _WarehouseLoc.Recdate = DateTime.Now;
                _WarehouseLoc.RecUser = "clarisa";
                this._WarehouseLocProvider.Save(_WarehouseLoc);
                return RedirectToAction("WarehouseLocList");
            }

            return View(_WarehouseLoc);
        }

        [ActionName("WarehouseEdit")]
        public ActionResult WarehouseEdit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseLoc _Warehouse = _WarehouseLocProvider.GetByWarehouseLocId(id);
            if (_Warehouse == null)
            {
                return HttpNotFound();
            }
            return View(_Warehouse);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WarehouseEdit([Bind(Include = "LocationAddress")] WarehouseLoc _WarehouseLoc)
        {
            if (ModelState.IsValid)
            {
                _WarehouseLocProvider.Save(_WarehouseLoc);
                return RedirectToAction("WarehouseLocList");
            }
            return View(_WarehouseLoc);
        }

        #endregion


    }
}