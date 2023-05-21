using inventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace inventorySystem.Controllers
{
    public class PurchaseController : Controller
    {
        // create database object db 
        inv_systemEntities db = new inv_systemEntities();
        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }

        // Display Product List Method
        [HttpGet]
        public ActionResult DisplayPurchase()
        {
            List<tbl_purchase> list = db.tbl_purchase.OrderByDescending(x => x.poID).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult CreatePurchase()
        {

            return View();
        }

        // Create Product Method
        [HttpPost]
        public ActionResult CreatePurchase(tbl_purchase po)
        {
            db.tbl_purchase.Add(po);
            db.SaveChanges();

            return RedirectToAction("DisplayPurchase");
        }
        [HttpGet]
        // Update Product Method
        public ActionResult UpdatePurchase(int id)
        {
            tbl_purchase po = db.tbl_purchase.Where(x => x.poID == id).SingleOrDefault();

            return View(po);
        }

        [HttpPost]
        // Update Product Method
        public ActionResult UpdatePurchase(int id, tbl_purchase pur)
        {
            tbl_purchase pr = db.tbl_purchase.Where(x=>x.poID == id).SingleOrDefault();
            pr.poName = pur.poName;
            pr.poDate = pur.poDate;
            pr.proQty = pur.proQty;
            db.SaveChanges();
            //return View(pr);
            return RedirectToAction("DisplayPurchase");
        }

        // Detail or view  Method 
        [HttpGet]
        public ActionResult ViewPurchase(int id)
        {
            tbl_purchase pr = db.tbl_purchase.Where(x => x.poID == id).SingleOrDefault();
            return View(pr);

        }
        //Delete products 


        [HttpGet]
        // Update Product Method
        public ActionResult DeletePurchase(int id)
        {
            tbl_purchase pr = db.tbl_purchase.Where(x => x.poID == id).SingleOrDefault();

            return View(pr);
        }

        [HttpPost]
        // Update Product Method
        public ActionResult DeletePurchase(int id, tbl_product pro)
        {
      
            db.tbl_purchase.Remove(db.tbl_purchase.Where(x => x.poID == id).SingleOrDefault());
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }
    }
}