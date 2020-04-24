using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;

namespace DoormatWebSite.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Product
        public ActionResult Index()
        {

            return View(db.Product.OrderByDescending(p=>p.Date).ToList());
        }

        public ActionResult Create()
        {
            ViewBag.ProductTypeID= new SelectList(db.ProductType, "ProductTypeId", "Title");
            ViewBag.UnitType = new SelectList(db.UnitType, "UnitID", "Title");
            return View();
        }
    }
}