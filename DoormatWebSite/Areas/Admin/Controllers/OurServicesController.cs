using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoormatWebSite.Models;
using DoormatWebSite.Models.Model;
using IdentitySample.Models;

namespace DoormatWebSite.Areas.Admin.Controllers
{
    public class OurServicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/OurServices
        public ActionResult Index()
        {
            var ourService = db.OurService.Include(o => o.languageType);
            return View(ourService.ToList());
        }

        // GET: Admin/OurServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurService ourService = db.OurService.Find(id);
            if (ourService == null)
            {
                return HttpNotFound();
            }
            return View(ourService);
        }

        // GET: Admin/OurServices/Create
        public ActionResult Create()
        {
            ViewBag.LanguageCode = new SelectList(db.languageType, "Lanid", "Type");
            return View();
        }

        // POST: Admin/OurServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,image,Title,Subtitle,Url,Lanid")] OurService ourService, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    ourService.image = Guid.NewGuid() + Path.GetExtension(Image.FileName);
                    Image.SaveAs(Server.MapPath("/PageImages/" + ourService.image));
                }
                db.OurService.Add(ourService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LanguageCode = new SelectList(db.languageType, "Lanid", "Type", ourService.languageType);
            return View(ourService);
        }

        // GET: Admin/OurServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurService ourService = db.OurService.Find(id);
            if (ourService == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageCode = new SelectList(db.languageType, "Lanid", "Type", ourService.languageType);
            return View(ourService);
        }

        // POST: Admin/OurServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,image,Title,Subtitle,Url,Lanid")] OurService ourService, HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null)
                {
                    if (ourService.image != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/PageImages/" + ourService.image));
                    }


                    ourService.image = Guid.NewGuid() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/PageImages/" + ourService.image));
                }
                db.Entry(ourService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageCode = new SelectList(db.languageType, "Lanid", "Type", ourService.languageType);
            return View(ourService);
        }

        // GET: Admin/OurServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurService ourService = db.OurService.Find(id);
            if (ourService == null)
            {
                return HttpNotFound();
            }
            return View(ourService);
        }

        // POST: Admin/OurServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OurService ourService = db.OurService.Find(id);
            db.OurService.Remove(ourService);
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
