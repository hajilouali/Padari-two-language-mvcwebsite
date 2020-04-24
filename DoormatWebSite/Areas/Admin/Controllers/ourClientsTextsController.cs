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
    public class ourClientsTextsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ourClientsTexts
        public ActionResult Index()
        {
            var ourClientsText = db.ourClientsText.Include(o => o.languageType);
            return View(ourClientsText.ToList());
        }

        // GET: Admin/ourClientsTexts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ourClientsText ourClientsText = db.ourClientsText.Find(id);
            if (ourClientsText == null)
            {
                return HttpNotFound();
            }
            return View(ourClientsText);
        }

        // GET: Admin/ourClientsTexts/Create
        public ActionResult Create()
        {
            ViewBag.languageCode = new SelectList(db.languageType, "Lanid", "Type");
            return PartialView();
        }

        // POST: Admin/ourClientsTexts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,text,Lanid")] ourClientsText ourClientsText)
        {
            if (ModelState.IsValid)
            {
                db.ourClientsText.Add(ourClientsText);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.languageCode = new SelectList(db.languageType, "Lanid", "Type", ourClientsText.languageType);
            return PartialView(ourClientsText);
        }

        // GET: Admin/ourClientsTexts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ourClientsText ourClientsText = db.ourClientsText.Find(id);
            if (ourClientsText == null)
            {
                return HttpNotFound();
            }
            ViewBag.languageCode = new SelectList(db.languageType, "Lanid", "Type", ourClientsText.languageType);
            return PartialView(ourClientsText);
        }

        // POST: Admin/ourClientsTexts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,text,Lanid")] ourClientsText ourClientsText)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ourClientsText).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.languageCode = new SelectList(db.languageType, "Lanid", "Type", ourClientsText.languageType);
            return PartialView(ourClientsText);
        }

        // GET: Admin/ourClientsTexts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ourClientsText ourClientsText = db.ourClientsText.Find(id);
            if (ourClientsText == null)
            {
                return HttpNotFound();
            }
            return PartialView(ourClientsText);
        }

        // POST: Admin/ourClientsTexts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ourClientsText ourClientsText = db.ourClientsText.Find(id);
            db.ourClientsText.Remove(ourClientsText);
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
