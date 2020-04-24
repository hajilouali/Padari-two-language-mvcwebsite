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
    public class PostTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/PostTypes
        public ActionResult Index()
        {
            var postType = db.PostType.Include(p => p.languageType);
            return View(postType.ToList());
        }

        // GET: Admin/PostTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostType postType = db.PostType.Find(id);
            if (postType == null)
            {
                return HttpNotFound();
            }
            return View(postType);
        }

        // GET: Admin/PostTypes/Create
        public ActionResult Create()
        {
            ViewBag.languageType = new SelectList(db.languageType, "Lanid", "Type");
            return PartialView();
        }

        // POST: Admin/PostTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostTypeID,Title,Lanid")] PostType postType)
        {
            if (ModelState.IsValid)
            {
                db.PostType.Add(postType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.languageType = new SelectList(db.languageType, "Lanid", "Type", postType.languageType);
            return PartialView(postType);
        }

        // GET: Admin/PostTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostType postType = db.PostType.Find(id);
            if (postType == null)
            {
                return HttpNotFound();
            }
            ViewBag.languageType = new SelectList(db.languageType, "Lanid", "Type", postType.languageType);
            return PartialView(postType);
        }

        // POST: Admin/PostTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostTypeID,Title,Lanid")] PostType postType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.languageType = new SelectList(db.languageType, "Lanid", "Type", postType.languageType);
            return PartialView(postType);
        }

        // GET: Admin/PostTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostType postType = db.PostType.Find(id);
            if (postType == null)
            {
                return HttpNotFound();
            }
            return PartialView(postType);
        }

        // POST: Admin/PostTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostType postType = db.PostType.Find(id);
            db.PostType.Remove(postType);
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
