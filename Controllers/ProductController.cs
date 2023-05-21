using inventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace inventorySystem.Controllers
{
    public class ProductController : Controller
    {
        // create database object db 
        inv_systemEntities db = new inv_systemEntities();

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }



        // Display Product List Method
        [HttpGet]
        public ActionResult DisplayProduct()
        {
            List<tbl_product> list = db.tbl_product.OrderByDescending(x => x.proID).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {

            return View();
        }

        // Create Product Method
        [HttpPost]
        public ActionResult CreateProduct(tbl_product pro)
        {
            db.tbl_product.Add(pro);
            db.SaveChanges();

            return RedirectToAction("DisplayProduct");
        }
        [HttpGet]
        // Update Product Method
        public ActionResult UpdateProduct(int id)
        {
            tbl_product pr = db.tbl_product.Where(x => x.proID == id).SingleOrDefault();

            return View(pr);
        }

        [HttpPost]
        // Update Product Method
        public ActionResult UpdateProduct(int id,tbl_product pro)
        {
            tbl_product pr = db.tbl_product.Where(x => x.proID == id).SingleOrDefault();
            pr.proName = pro.proName;
            pr.proQty = pro.proQty;
            db.SaveChanges();
            //return View(pr);
            return RedirectToAction("DisplayProduct");
        }

        // Detail or view  Method 
        [HttpGet]
        public ActionResult ViewProduct(int id)
        {
            tbl_product pr = db.tbl_product.Where(x => x.proID == id).SingleOrDefault();        
            return View(pr);
         
        }
        //Delete products 


        [HttpGet]
        // Update Product Method
        public ActionResult DeleteProduct(int id)
        {
            tbl_product pr = db.tbl_product.Where(x => x.proID == id).SingleOrDefault();

            return View(pr);
        }

        [HttpPost]
        // Update Product Method
        public ActionResult DeleteProduct(int id,tbl_product pro)
        {
            
            db.tbl_product.Remove(db.tbl_product.Where(x=>x.proID == id).SingleOrDefault());
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }

    }
} 