using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;
using Infrastructure;

namespace LabWebSite.Controllers
{ 
    public class ProductController : Controller
    {
        //private NorthwindContext db = NorthwindContext.GetNorthwindContext();
        private ProductRepository _repo = new ProductRepository();
        CategoryRepository _categoryRepository = new CategoryRepository();
        SupplierRepository _supplierRepository = new SupplierRepository();

        //
        // GET: /Product/

        public ViewResult Index()
        {
            var products = _repo.GetAllProducts();
            //var products = db.Products.Include(p => p.Category).Include(p => p.Supplier);
            return View(products.ToList());
        }

        //
        // GET: /Product/Details/5

        public ViewResult Details(int id)
        {
            Product product = _repo.GetProductById(id);
            return View(product);
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_categoryRepository.GetAllCategories(), "CategoryId", "CategoryName");
            ViewBag.SupplierId = new SelectList(_supplierRepository.GetAllSuppliers(), "SupplierId", "CompanyName");
            return View();
        }

        //
        // POST: /Product/Create

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(product);
                return RedirectToAction("Index");  
            }

            ViewBag.CategoryId = new SelectList(_categoryRepository.GetAllCategories(), "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.SupplierId = new SelectList(_supplierRepository.GetAllSuppliers(), "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }
        
        //
        // GET: /Product/Edit/5
 
        public ActionResult Edit(int id)
        {
            Product product = _repo.GetProductById(id);
            ViewBag.CategoryId = new SelectList(_categoryRepository.GetAllCategories(), "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.SupplierId = new SelectList(_supplierRepository.GetAllSuppliers(), "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(product);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(_categoryRepository.GetAllCategories(), "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.SupplierId = new SelectList(_supplierRepository.GetAllSuppliers(), "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }

        //
        // GET: /Product/Delete/5
 
        public ActionResult Delete(int id)
        {
            Product product = _repo.GetProductById(id);
            return View(product);
        }

        //
        // POST: /Product/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            _repo.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetProductInfo(int id)
        {
            var product = _repo.GetProductById(id);
            var flatObject = new
            {
                id = product.ProductId,
                productName = product.ProductName,
                categoryId = product.CategoryId,
                discontinued = product.Discontinued,
                supplier = product.SupplierId,
                price = product.UnitPrice,
                unitsInStock = product.UnitsInStock
            };
            return Json(flatObject, JsonRequestBehavior.AllowGet);
        }
        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}