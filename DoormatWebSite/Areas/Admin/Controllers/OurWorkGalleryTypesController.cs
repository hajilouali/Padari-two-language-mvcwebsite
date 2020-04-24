using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoormatWebSite.Models;
using DoormatWebSite.Models.Model;
using IdentitySample.Models;

namespace DoormatWebSite.Areas.Admin.Controllers
{
    public class OurWorkGalleryTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/OurWorkGalleryTypes
        public ActionResult Index()
        {
            var ourWorkGalleryType = db.OurWorkGalleryType.Include(o => o.LanguageType);
            return View(ourWorkGalleryType.ToList());
        }

        // GET: Admin/OurWorkGalleryTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurWorkGalleryType ourWorkGalleryType = db.OurWorkGalleryType.Find(id);
            if (ourWorkGalleryType == null)
            {
                return HttpNotFound();
            }
            return View(ourWorkGalleryType);
        }

        // GET: Admin/OurWorkGalleryTypes/Create
        public ActionResult Create()
        {
            ViewBag.languageType = new SelectList(db.languageType, "Lanid", "Type");
            return PartialView();
        }

        // POST: Admin/OurWorkGalleryTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Title,Lanid")] OurWorkGalleryType ourWorkGalleryType)
        {
            if (ModelState.IsValid)
            {
                db.OurWorkGalleryType.Add(ourWorkGalleryType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.languageType = new SelectList(db.languageType, "Lanid", "Type", ourWorkGalleryType.LanguageType);
            return View(ourWorkGalleryType);
        }

        // GET: Admin/OurWorkGalleryTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurWorkGalleryType ourWorkGalleryType = db.OurWorkGalleryType.Find(id);
            if (ourWorkGalleryType == null)
            {
                return HttpNotFound();
            }
            ViewBag.languageType = new SelectList(db.languageType, "Lanid", "Type", ourWorkGalleryType.LanguageType);
            return PartialView(ourWorkGalleryType);
        }

        // POST: Admin/OurWorkGalleryTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Title,Lanid")] OurWorkGalleryType ourWorkGalleryType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ourWorkGalleryType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.languageType = new SelectList(db.languageType, "Lanid", "Type", ourWorkGalleryType.LanguageType);
            return PartialView(ourWorkGalleryType);
        }

        // GET: Admin/OurWorkGalleryTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurWorkGalleryType ourWorkGalleryType = db.OurWorkGalleryType.Find(id);
            if (ourWorkGalleryType == null)
            {
                return HttpNotFound();
            }
            return PartialView(ourWorkGalleryType);
        }

        // POST: Admin/OurWorkGalleryTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OurWorkGalleryType ourWorkGalleryType = db.OurWorkGalleryType.Find(id);
            db.OurWorkGalleryType.Remove(ourWorkGalleryType);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
