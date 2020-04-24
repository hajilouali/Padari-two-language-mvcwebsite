using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoormatWebSite.Models.Model;
using IdentitySample.Models;

namespace DoormatWebSite.Areas.Admin.Controllers
{
    public class PartnersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Partners
        public ActionResult Index()
        {
            var partner = db.Partner.Include(p => p.LanguageType);
            return View(partner.ToList());
        }

        // GET: Admin/Partners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partner partner = db.Partner.Find(id);
            if (partner == null)
            {
                return HttpNotFound();
            }
            return View(partner);
        }

        // GET: Admin/Partners/Create
        public ActionResult Create()
        {
            ViewBag.Lanid = new SelectList(db.languageType, "Lanid", "Type");
            return View();
        }

        // POST: Admin/Partners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Title,City,Address,PhoneNumer,PhoneNumer2,Mobile,Lanid,BranchOffice")] Partner partner)
        {
            if (ModelState.IsValid)
            {
                db.Partner.Add(partner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Lanid = new SelectList(db.languageType, "Lanid", "Type", partner.Lanid);
            return View(partner);
        }

        // GET: Admin/Partners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partner partner = db.Partner.Find(id);
            if (partner == null)
            {
                return HttpNotFound();
            }
            ViewBag.Lanid = new SelectList(db.languageType, "Lanid", "Type", partner.Lanid);
            return View(partner);
        }

        // POST: Admin/Partners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Title,City,Address,PhoneNumer,PhoneNumer2,Mobile,Lanid,BranchOffice")] Partner partner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Lanid = new SelectList(db.languageType, "Lanid", "Type", partner.Lanid);
            return View(partner);
        }

        // GET: Admin/Partners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partner partner = db.Partner.Find(id);
            if (partner == null)
            {
                return HttpNotFound();
            }
            return View(partner);
        }

        // POST: Admin/Partners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Partner partner = db.Partner.Find(id);
            db.Partner.Remove(partner);
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
